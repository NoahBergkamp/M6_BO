using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Scriptable Objects/Pokemon")]
public class Pokemon : ScriptableObject
{
    public float health;
    public float defense;
    public float attack;
    public float speed;
    public float lvl;
    public Type type1;
    public Type type2;
}
public enum Type { bug, fire, water, dark, dragon, electric, fairy, fighting, flying, ghost, grass, ground, ice, normal, poison, psychic, rock, steel }
