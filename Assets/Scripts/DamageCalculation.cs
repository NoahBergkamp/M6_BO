using System;
using UnityEngine;
using static Attacks;

public class DamageCalculation : MonoBehaviour
{
    [SerializeField] private AttacksManager attacksManager;
        [SerializeField] private TypeEffectiveness TypeMult;
    private float typeMult;
    private float damageDealt;
    private float STAB;
    private float critChance = 6.25f;
    private float crit;
    private float dmgMult;
    private float defenseMult;
    public float Damage(float lvl, float defense, float damage ,float power, Enum attackType, Enum defenderType, Enum AttackerType)
    {
        typeMult = TypeMult.TypeEffectivenessCalculator(attackType, defenderType);
        CritCalc();
        if (attackType == AttackerType)
        {
            STAB = 1.5f;
        }
        else
        {
            STAB = 1f;
        }
        dmgMult = UnityEngine.Random.Range(0.85f, 1);
        damageDealt = damage * STAB * crit * dmgMult;
        defenseMult = defense / power;

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

