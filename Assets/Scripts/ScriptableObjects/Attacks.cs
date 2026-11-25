using UnityEngine;

[CreateAssetMenu(fileName = "Attacks", menuName = "Scriptable Objects/Attacks")]
public class Attacks : ScriptableObject
{
    public string attackName;
    public float power;
    public int accuracy;
    public int critChance;
    public AttackType attackType;

}
public enum AttackType { bug, fire, water, dark, dragon, electric, fairy, fighting, flying, ghost, grass, ground, ice, normal, poison, psychic, rock, steel }
