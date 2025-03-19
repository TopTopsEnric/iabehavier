using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaitState", menuName = "States/wait")]
public class EnemyWaitState : State
{
    public override void EnterState(EnemyAI enemy)
    {
        // Inicializa el comportamiento de espera, si es necesario
    }

    public override void UpdateState(EnemyAI enemy)
    {
        Vector3 wanderPosition = enemy.transform.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        enemy.MoveTowards(wanderPosition);
    }
    public override void ExitState(EnemyAI enemy)
    {

    }
}

