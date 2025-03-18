using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        // Si la salud del enemigo es mayor o igual al 50%, cambia a persecuci�n
        if (enemy.health >= 50)
        {
            enemy.SwitchState(enemy.chaseState);
        }
    }
}
