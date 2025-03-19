using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFleeState", menuName = "States/flee")]
public class EnemyFleeState : State
{
    public override void EnterState(EnemyAI enemy)
    {
        // Aqu� puedes agregar animaciones o sonidos espec�ficos para la huida
    }

    public override void UpdateState(EnemyAI enemy)
    {
        // Calcula la direcci�n opuesta al jugador
        Vector3 fleeDirection = (enemy.transform.position - enemy.player.position).normalized;
        Vector3 fleePosition = enemy.transform.position + fleeDirection * enemy.fleeSpeed * Time.deltaTime;

        // Mueve al enemigo hacia la posici�n opuesta al jugador
        enemy.MoveTowards(fleePosition);


    }
    public override void ExitState(EnemyAI enemy)
    {

    }
}
