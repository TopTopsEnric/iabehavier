using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorStados : MonoBehaviour
{
    public State CurrentState;
    public EnemyAI controlador;
    public bool detectado { get; set; } = false;
    public bool muerto { get; set; } = false;

    public bool ha_buscado { get; set; } = false;


    public List<State> states = new List<State>();
    void Start()
    {
       
    }
    public void seleccionar_estado()
    {
       
        if (muerto)
        {
            GoToState(states[0]);
        }
        else if (ha_buscado)
        {
            GoToState(states[4]);
        }
        else if (detectado)
        {
            if (controlador.health>50) {

                GoToState(states[1]);
            }
            else
            {
                GoToState(states[2]);
            }
        }
        else
        {
            GoToState(states[3]);
        }

    }

    void Update()
    {

        CurrentState.UpdateState(controlador);
    }


    public  void GoToState(State estado) 
    {
            Debug.Log("GO to " + estado);
            CurrentState.ExitState(controlador);
            CurrentState = estado;
            CurrentState.EnterState(controlador);
    }
}
