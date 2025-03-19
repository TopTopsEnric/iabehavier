using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "EnemyPatrolState", menuName = "States/patrol")]
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
        if (!enemy.GetComponent<NavMeshAgent>().pathPending &&
            enemy.GetComponent<NavMeshAgent>().remainingDistance < 0.5f)
        {
            currentPointIndex = (currentPointIndex + 1) % enemy.patrolPoints.Length;
            MoveToNextPoint(enemy);
        }
    }
    public override void ExitState(EnemyAI enemy)
    {

    }

    // Mueve al enemigo hacia el siguiente punto de patrullaje
    private void MoveToNextPoint(EnemyAI enemy)
        {
            Debug.Log("esta pasando de objetivo");
            Vector3 targetPos = enemy.patrolPoints[currentPointIndex].position;
            enemy.GetComponent<NavMeshAgent>().SetDestination(targetPos);  // Usamos SetDestination para mover al enemigo
        }
    }
