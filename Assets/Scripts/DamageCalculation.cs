using System;
using UnityEngine;
using static Attacks;

public class DamageCalculation : MonoBehaviour
{
    [SerializeField] private AttacksManager attacksManager;
        [SerializeField] private TypeEffectiveness TypeMult;
    private float typeMult;
    private float baseDamage;
    private float damageDealt;
    private float STAB;
    private float critChance = 6.25f;
    private float crit;
    private float dmgMult;
    private float critMult;
    private float lvlMult;
    private float defenseMult;
    public float Damage(float lvl, float defense, float attack ,float power, Enum attackType, Enum defenderType, Enum AttackerType)
    {
        typeMult = TypeMult.TypeEffectivenessCalculator(attackType, defenderType);
        CritCalc();
        STAB = attackType.Equals(AttackerType) ? 1.5f : 1f;
        dmgMult = UnityEngine.Random.Range(0.85f, 1f);
        defenseMult = attack / defense;
        lvlMult = (2 * lvl) / 5f + 2f;  
        baseDamage = ((lvlMult * power * defenseMult)/50) + 2;
        critMult = baseDamage * crit + 2; // never fixing this again fuckkkkkkkkkk all of you especially kareem
        damageDealt = critMult * typeMult * STAB * dmgMult;

        Debug.Log($"lvl: {lvl}\ndefense: {defense}\n damage:{power}\n typeMult: {typeMult}\n critMult:{critMult}\n baseDamage:{baseDamage}\n defenseMult: {defenseMult}\n LvlMult:{lvlMult}\n damage Dealt" );

        return damageDealt;
    }
    private void CritCalc()
    {
        if (UnityEngine.Random.value < critChance / 100)
        {
            crit = 1.5f;
        }
        else
        {
            crit = 1f;
        }
    }


}

