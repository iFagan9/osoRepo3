using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{

    public override void EnterState(EnemyAI enemy)
    {
        //Debug.Log("Entered Chase State");
    }

    public override void UpdateState(EnemyAI enemy)
    {
        if (Vector3.Distance(enemy.transform.position, enemy.playerObject.transform.position) > enemy.detectionRadius)
        {
            enemy.SwitchState(enemy.roamState);
        } else if (Vector3.Distance(enemy.transform.position, enemy.playerObject.transform.position) < enemy.attackRadius)
        {
            enemy.SwitchState(enemy.attackState);
        }

        Vector3 playerDir = Vector3.Normalize(enemy.playerObject.transform.position - enemy.transform.position);
        enemy.pDir = playerDir;
        enemy.transform.rotation = Quaternion.LookRotation(playerDir);
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.playerObject.transform.position, enemy.speed * Time.deltaTime);
        //enemy.rb.MovePosition(enemy.transform.forward * enemy.speed * Time.deltaTime);
    }
}
