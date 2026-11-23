using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttacksManager : MonoBehaviour
{
    [SerializeField] private Attacks[] playerAttacks, enemyAttacks;
    [SerializeField] private Pokemon enemy, player;
    [SerializeField] private DamageCalculation calculate;

    private int playerChosenAttack;
    private int enemyChosenAttack;

    private bool playerChoiceMade = true;
    private bool enemyChoiceMade = true;
    private Attacks playerAttack;
    private Attacks enemyAttack;

    private float finalDamage;


    private int attackOrder;
    void Start()
    {
        playerChosenAttack = 1;
        enemyChosenAttack = 0;
        playerAttack = playerAttacks[playerChosenAttack];
        enemyAttack = enemyAttacks[enemyChosenAttack];
    }

    void Update()
    {
        if(playerChoiceMade && enemyChoiceMade)
        {
            CalculateSpeed();
            playerChoiceMade = false;
            enemyChoiceMade = false;
        }
    }

    private void CalculateSpeed()
    {
        if (player.speed < enemy.speed)
        {
            StartCoroutine(PlayerAttack());
        }
        else if(player.speed > enemy.speed)
        {
            StartCoroutine(PlayerAttack());
        }
        else
        {
            StartCoroutine(PlayerAttack());
            attackOrder = UnityEngine.Random.Range(0, 1);
        }
    }
    
    public IEnumerator PlayerAttack()
    {
        finalDamage = calculate.Damage(player.lvl, enemy.defense, playerAttack.damage,player.power, playerAttack.attackType , enemy.type1, player.type2);
        Debug.Log(finalDamage);
        yield return new WaitForSeconds(2);
    }

    public IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(2);
    }
}
