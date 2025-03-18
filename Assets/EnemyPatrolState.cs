using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : State
{
    private int currentPointIndex;

    public override void EnterState(EnemyAI enemy)
    {
        currentPointIndex = 0;  // Comienza a patrullar desde el primer punto
        MoveToNextPoint(enemy);
    }

    public override void UpdateState(EnemyAI enemy)
    {
        // Si la salud del enemigo es menor o igual al 50%, cambia a fuga
        if (enemy.health <= 50)
        {
            enemy.SwitchState(enemy.fleeState);
            return;
        }

        // Si el enemigo ve al jugador, cambia a persecución
        if (enemy.CanSeePlayer())
        {
            enemy.SwitchState(enemy.chaseState);
            return;
        }

        if (!enemy.GetComponent<NavMeshAgent>().pathPending &&
     enemy.GetComponent<NavMeshAgent>().remainingDistance < 0.5f)
        {
            currentPointIndex = (currentPointIndex + 1) % enemy.patrolPoints.Length;
            MoveToNextPoint(enemy);
        }
    }

    // Mueve al enemigo hacia el siguiente punto de patrullaje
    private void MoveToNextPoint(EnemyAI enemy)
    {
        Debug.Log("esta pasando de objetivo");
        Vector3 targetPos = enemy.patrolPoints[currentPointIndex].position;
        enemy.GetComponent<NavMeshAgent>().SetDestination(targetPos);  // Usamos SetDestination para mover al enemigo
    }
}