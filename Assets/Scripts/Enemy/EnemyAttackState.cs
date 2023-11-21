using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float timer;
    private float timeBetweenAttacks = 2f;
    private float bufferBeforeFirstAttack = .5f;

    public override void EnterState(EnemyAI enemy)
    {
        Debug.Log("Entered Attack State");
        timer = bufferBeforeFirstAttack;
    }

    public override void UpdateState(EnemyAI enemy)
    {
        if (Vector3.Distance(enemy.transform.position, enemy.playerObject.transform.position) > enemy.attackRadius)
        {
            enemy.SwitchState(enemy.chaseState);
        }

        Vector3 playerDir = Vector3.Normalize(enemy.playerObject.transform.position - enemy.transform.position);
        enemy.pDir = playerDir;
        enemy.transform.rotation = Quaternion.LookRotation(playerDir);

        if (Vector3.Distance(enemy.transform.position, enemy.playerObject.transform.position) < enemy.repelRadius)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.playerObject.transform.position, -enemy.speed * Time.deltaTime);
        }

        if (timer <= 0)
        {
            attack(enemy, playerDir);
        } else
        {
            timer -= Time.deltaTime;
        }
    }

    private void attack(EnemyAI enemy, Vector3 playerDir)
    {
        Debug.Log("Attacked");
        RaycastHit hitinfo;
        if (Physics.Raycast(enemy.transform.position, playerDir, out hitinfo))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {
                enemy.playerHealth.TakeDamage(enemy.attackDamage);              
            }
            Debug.Log(hitinfo.collider.gameObject.name);
        }
        timer = timeBetweenAttacks;
    }
}
