using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Scriptable Objects/Pokemon")]
public class Pokemon : ScriptableObject
{
    public enum priType { bug, fire, water, dark, dragon, electric, fairy, fighting, flying, ghost, grass, ground, ice, normal, poison, psychic, rock, steel }
    public enum secType { bug, fire, water, dark, dragon, electric, fairy, fighting, flying, ghost, grass, ground, ice, normal, poison, psychic, rock, steel }
    public float health;
    public float defense;
    public float power;
    public float lvl;
}
