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
        // No necesita actualizaci�n porque el enemigo ya est� muriendo
        // Pero si quisieras agregar alguna l�gica durante la muerte, ir�a aqu�
    }
}
