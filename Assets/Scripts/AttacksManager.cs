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
            StartCoroutine(EnemyAttack());
            StartCoroutine(PlayerAttack());
        }
        else if(player.speed > enemy.speed)
        {
            StartCoroutine(PlayerAttack());
            StartCoroutine(EnemyAttack());

        }
        else
        {
            StartCoroutine(PlayerAttack());
            attackOrder = UnityEngine.Random.Range(0, 1);
            if(attackOrder == 0)
            {
                StartCoroutine(EnemyAttack());
                StartCoroutine(PlayerAttack());
            }
            else
            {
                StartCoroutine(PlayerAttack());
                StartCoroutine(EnemyAttack());
            }
        }
    }
    
    public IEnumerator PlayerAttack()
    {
        finalDamage = calculate.Damage(
            player.lvl,
            enemy.defense,
            player.attack,
            playerAttack.power,
            playerAttack.attackType,
            enemy.type1,
            player.type2);
        Debug.Log(finalDamage);
        yield return new WaitForSeconds(2);
    }

    public IEnumerator EnemyAttack()
    {
        finalDamage = calculate.Damage(
            enemy.lvl, 
            player.defense,
            enemy.attack,
            enemyAttack.power, 
            enemyAttack.attackType, 
            player.type1, 
            enemy.type2);
        Debug.Log(finalDamage);
        yield return new WaitForSeconds(2);
    }
}
