using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    [SerializeField] int maxHp;
    [SerializeField] int Attack;
    [SerializeField] int Defense;
    [SerializeField] int SpecialAttack;
    [SerializeField] int SpecialDefense;
    [SerializeField] int Speed;
}


public enum PokemonType { Fire, Water, Grass, Electric, Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel, Psychic, Ice, Dragon, Dark, Fairy }