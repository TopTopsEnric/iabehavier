using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFleeState", menuName = "States/flee")]
public class EnemyFleeState : State
{
    public override void EnterState(EnemyAI enemy)
    {
        // Aquí puedes agregar animaciones o sonidos específicos para la huida
    }

    public override void UpdateState(EnemyAI enemy)
    {
        // Calcula la dirección opuesta al jugador
        Vector3 fleeDirection = (enemy.transform.position - enemy.player.position).normalized;
        Vector3 fleePosition = enemy.transform.position + fleeDirection * enemy.fleeSpeed * Time.deltaTime;

        // Mueve al enemigo hacia la posición opuesta al jugador
        enemy.MoveTowards(fleePosition);


    }
    public override void ExitState(EnemyAI enemy)
    {

    }
}
