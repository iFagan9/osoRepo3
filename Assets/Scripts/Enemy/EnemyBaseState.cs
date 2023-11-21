using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyAI enemy);

    public abstract void UpdateState(EnemyAI enemy);
}
