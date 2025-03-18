using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaitState : State
{
    public override void EnterState(EnemyAI enemy)
    {
        // Inicializa el comportamiento de espera, si es necesario
    }

    public override void UpdateState(EnemyAI enemy)
    {
        // Si la salud del enemigo es menor al 50%, hace rondas alrededor del último lugar donde vio al jugador
        if (enemy.health < 50)
        {
            Vector3 wanderPosition = enemy.transform.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
            enemy.MoveTowards(wanderPosition);
        }
        else
        {
            // Si el enemigo tiene toda su salud, regresa a patrullar
            enemy.SwitchState(enemy.patrolState);
        }

        // Si el enemigo detecta al jugador de nuevo, cambia a persecución
        if (enemy.CanSeePlayer())
        {
            enemy.SwitchState(enemy.chaseState);
        }
    }
}
