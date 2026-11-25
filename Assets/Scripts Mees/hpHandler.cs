using UnityEngine;
using UnityEngine.UI;

public class hpHandler : MonoBehaviour
{
    private float Maxhealth = 100f;
    private float Health;
    [SerializeField] private Slider HealthSlider;
    [SerializeField] private Graphic FillImage;
    private AttacksManager attacksManager;

    void Start()
    {
        attacksManager = GetComponent<AttacksManager>();


        if (HealthSlider.fillRect != null)
        {
            return;
        }
        else
        {
            FillImage = CreateFill();
        }

        HealthSlider.maxValue = Maxhealth;
    }

    void Update()
    {
        Health = (int)attacksManager.EnemyHealth;
        HealthSlider.maxValue = Maxhealth;
        HealthSlider.value = Health;

        if (HealthSlider.value <= 25)
        {
            FillImage.color = Color.red;
        }
        else if (HealthSlider.value <= 50)
        {
            FillImage.color = Color.yellow;
        }
        else
        {
            FillImage.color = Color.green;
        }
    }
    private Image CreateFill()
    {
        var areaGO = new GameObject("Fill Area", typeof(RectTransform));
        var area = areaGO.GetComponent<RectTransform>();
        area.SetParent(HealthSlider.transform, false);
        area.anchorMin = Vector2.zero;
        area.anchorMax = Vector2.one;
        area.offsetMin = Vector2.zero;
        area.offsetMax = Vector2.zero;

        var fillGO = new GameObject("Fill", typeof(RectTransform), typeof(Image));
        var rt = fillGO.GetComponent<RectTransform>();
        rt.SetParent(area, false);
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        HealthSlider.fillRect = rt;
        return fillGO.GetComponent<Image>();
    }
}