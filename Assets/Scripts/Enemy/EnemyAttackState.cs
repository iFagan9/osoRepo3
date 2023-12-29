using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAttackState : EnemyBaseState
{
    private float timer;
    private float timeBetweenAttacks = 2f;
    private float bufferBeforeFirstAttack = .5f;
    private float strafeDuration = 10f; // Adjust this value based on how long you want the enemy to strafe
    private float strafeTimer;

    public override void EnterState(EnemyAI enemy)
    {
        // Debug.Log("Entered Attack State");
        timer = bufferBeforeFirstAttack;
        strafeTimer = strafeDuration;
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
        else
        {
            // Check if it's time to strafe
            if (strafeTimer > 0)
            {
                Strafe(enemy);
                strafeTimer -= Time.deltaTime;
            }
            else
            {
                // If strafe time is over, attack
                if (timer <= 0)
                {
                    Attack(enemy, playerDir);
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
    }

    private void Attack(EnemyAI enemy, Vector3 playerDir)
    {
        // Debug.Log("Attacked");
        RaycastHit hitinfo;
        if (Physics.Raycast(enemy.transform.position, playerDir, out hitinfo))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {
                enemy.playerHealth.TakeDamage(enemy.attackDamage);
            }
            // Debug.Log(hitinfo.collider.gameObject.name);
        }
        timer = timeBetweenAttacks;
        strafeTimer = strafeDuration; // Reset strafe timer after an attack
    }

    private void Strafe(EnemyAI enemy)
    {
        // Strafe in random directions
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0; // Keep the direction in the horizontal plane
        enemy.transform.Translate(randomDirection * 1.2f * Time.deltaTime);
    }
}
