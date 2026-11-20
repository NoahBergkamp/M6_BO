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

    private bool playerChoiceMade;
    private bool enemyChoiceMade;
    private Attacks playerAttack;
    private Attacks enemyAttack;


    private int attackOrder;
    void Start()
    {
        playerChosenAttack = 1;
        enemyChosenAttack = 3;
        playerAttack = playerAttacks[playerChosenAttack];
        enemyAttack = enemyAttacks[enemyChosenAttack];
    }

    void Update()
    {
        if(playerChoiceMade && enemyChoiceMade)
        {
            CalculateSpeed();
        }
    }

    private void CalculateSpeed()
    {
        if (playerAttack.speed < enemyAttack.speed)
        {
            //StartCoroutine(PlayerAttack());
        }
        else if(playerAttack.speed > enemyAttack.speed)
        {

        }
        else
        {
            attackOrder = UnityEngine.Random.Range(0, 1);
        }
    }
    
    public IEnumerator PlayerAttack()
    {
        calculate.Damage(player.lvl, enemy.defense, playerAttack.damage,player.power, Attacks.AttackType.water , Pokemon.priType.grass, Pokemon.priType.water);
        yield return new WaitForSeconds(2);
    }

    public IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(2);
    }
}
