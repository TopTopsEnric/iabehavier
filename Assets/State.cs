using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class State:ScriptableObject
{
    // Método que se ejecuta cuando el estado es activado
    public abstract void EnterState(EnemyAI enemy);

    // Método que se ejecuta cada frame mientras el estado está activo
    public abstract void UpdateState(EnemyAI enemy);

    public abstract void ExitState(EnemyAI enemy);
}
