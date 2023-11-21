using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamState : EnemyBaseState
{
    private enum ROAMSTATE
    {
        WAIT,
        PICKING,
        MOVING
    };
    private ROAMSTATE currentState;

    private float waitTimer;
    private float waitMaxTime = 2f;
    private Vector3 targetPoint;

    public override void EnterState(EnemyAI enemy)
    {
        Debug.Log("Entered Roam State");
        currentState = ROAMSTATE.WAIT;
        waitTimer = waitMaxTime;
    }

    public override void UpdateState(EnemyAI enemy)
    {
        if (Vector3.Distance(enemy.transform.position, enemy.playerObject.transform.position) < enemy.detectionRadius)
        {
            enemy.SwitchState(enemy.chaseState);
        }
        switch (currentState)
        {
            case (ROAMSTATE.WAIT):
                if (waitTimer <= 0)
                {
                    currentState = chooseNewState();
                } else
                {
                    waitTimer -= Time.deltaTime;
                }
                break;
            case (ROAMSTATE.PICKING):
                targetPoint = pickTarget(enemy);
                currentState = ROAMSTATE.MOVING;
                break;
            case (ROAMSTATE.MOVING):
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPoint, enemy.speed * Time.deltaTime);
                Vector2 enemyPos = new Vector2(enemy.transform.position.x, enemy.transform.position.z);
                Vector2 targetPos = new Vector2(targetPoint.x, targetPoint.z);
                enemy.transform.LookAt(new Vector3(targetPoint.x, enemy.transform.position.y, targetPoint.z));
                if (Vector2.Distance(enemyPos, targetPos) < .1f)
                {
                    currentState = chooseNewState();
                }
                break;
        }

    }

    Vector3 pickTarget(EnemyAI enemy)
    {
        float dist = Random.Range(5, 10);
        float angle = Random.Range(0f, 360f);
        Vector3 localPoint = new Vector3(Mathf.Cos(angle) * dist, 0f, Mathf.Sin(angle) * dist);
        Vector3 worldPoint = enemy.transform.position + localPoint;
        return worldPoint;
    }

    ROAMSTATE chooseNewState()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            waitTimer = waitMaxTime;
            return ROAMSTATE.WAIT;
        }
        else if (rand == 1)
        {
            return ROAMSTATE.PICKING;
        } else
        {
            waitTimer = waitMaxTime;
            return ROAMSTATE.WAIT;
        }
    }
}
