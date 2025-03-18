using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : State
{
    public override void EnterState(EnemyAI enemy)
    {
        // Aqu� se puede agregar l�gica al entrar al estado de persecuci�n (animaciones, sonidos, etc.)
    }

    public override void UpdateState(EnemyAI enemy)
    {
        // Si la salud del enemigo es menor o igual al 50%, cambia a fuga
        if (enemy.health < 50)
        {
            enemy.SwitchState(enemy.fleeState);
            return;
        }

        // Si el enemigo pierde al jugador de vista, cambia a patrullaje
        if (!enemy.CanSeePlayer())
        {
            enemy.SwitchState(enemy.patrolState);
            return;
        }

        // Mueve al enemigo hacia la posici�n del jugador
        enemy.MoveTowards(enemy.player.position);
    }
}
