#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

internal static class PaintStanTerrainBySlope
{
    private const string MenuPath = "Tools/Paint Selected Terrain by Slope";
    private const string UndoLabel = "Paint Grass and Cliff by Slope";

    [MenuItem(MenuPath, true)]
    private static bool CanPaint()
    {
        return Selection.activeGameObject != null &&
            Selection.activeGameObject.GetComponent<Terrain>() != null;
    }

    [MenuItem(MenuPath)]
    private static void Paint()
    {
        Terrain terrain = Selection.activeGameObject.GetComponent<Terrain>();
        TerrainData data = terrain.terrainData;
        TerrainLayer[] layers = data.terrainLayers;
        int grassIndex = Array.FindIndex(layers, layer => layer != null && layer.name == "Grass");
        int cliffIndex = Array.FindIndex(layers, layer => layer != null && layer.name == "Cliff");
        if (grassIndex < 0 || cliffIndex < 0)
        {
            Debug.LogError("The selected terrain needs Terrain Layers named Grass and Cliff.", terrain);
            return;
        }

        int width = data.alphamapWidth;
        int height = data.alphamapHeight;
        var weights = new float[height, width, layers.Length];
        int grassCount = 0;
        int cliffCount = 0;
        int blendCount = 0;

        for (int y = 0; y < height; y++)
        {
            float v = y / (height - 1f);
            for (int x = 0; x < width; x++)
            {
                float u = x / (width - 1f);
                float slope = data.GetSteepness(u, v);
                float blend = Mathf.InverseLerp(35f, 45f, slope);
                float cliffWeight = Mathf.SmoothStep(0f, 1f, blend);
                weights[y, x, grassIndex] = 1f - cliffWeight;
                weights[y, x, cliffIndex] = cliffWeight;
                if (blend == 0f)
                    grassCount++;
                else if (blend == 1f)
                    cliffCount++;
                else
                    blendCount++;
            }
        }

        Undo.RegisterCompleteObjectUndo(data, UndoLabel);
        Undo.RegisterCompleteObjectUndo(data.alphamapTextures, UndoLabel);
        data.SetAlphamaps(0, 0, weights);
        EditorUtility.SetDirty(data);
        AssetDatabase.SaveAssetIfDirty(data);
        Debug.Log($"Slope paint saved. Grass: {grassCount:N0}, cliff: {cliffCount:N0}, blend: {blendCount:N0} texels. {AssetDatabase.GetAssetPath(data)}", terrain);
        SceneView.RepaintAll();
    }
}
#endif
