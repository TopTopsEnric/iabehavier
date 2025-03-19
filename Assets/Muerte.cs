using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : State
{
    public override void EnterState(EnemyAI enemy)
    {
       
        GameObject.Destroy(enemy.gameObject, 2f);
    }

    public override void UpdateState(EnemyAI enemy)
    {
        // No necesita actualización porque el enemigo ya está muriendo
        // Pero si quisieras agregar alguna lógica durante la muerte, iría aquí
    }
}
