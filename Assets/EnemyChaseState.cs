using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyChaseState", menuName = "States/chase")]
public class EnemyChaseState : State
{
    public override void EnterState(EnemyAI enemy)
    {
        
    }

    public override void UpdateState(EnemyAI enemy)
    {




        // Mueve al enemigo hacia la posición del jugador
        enemy.MoveTowards(enemy.player.position);
    }

    public override void ExitState(EnemyAI enemy)
    {
        
    }
}
