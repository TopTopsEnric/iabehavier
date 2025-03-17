using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints; // Puntos de patrulla
    private NavMeshAgent agente;
    private int indiceDestino = 0;
    private int direccion = 1; // 1 para avanzar, -1 para retroceder
    private Transform jugador;
    private bool persiguiendo = false;

    private float vidaJugador = 100f; // Vida del jugador (debe actualizarse desde el Player)

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            agente.SetDestination(waypoints[indiceDestino].position);
        }
    }

    void Update()
    {
        if (!persiguiendo) // Si no está persiguiendo, patrulla
        {
            if (!agente.pathPending && agente.remainingDistance < 0.5f)
            {
                SiguientePunto();
            }
        }
        else if (jugador != null)
        {
            float distancia = Vector3.Distance(transform.position, jugador.position);
            if (vidaJugador > 50f)
            {
                agente.SetDestination(jugador.position);
            }
            else
            {
                Vector3 direccionHuir = (transform.position - jugador.position).normalized;
                Vector3 destinoHuir = transform.position + direccionHuir * 10f;
                agente.SetDestination(destinoHuir);
            }
        }
    }

    void SiguientePunto()
    {
        if (waypoints.Length == 0) return;

        // Cambia de waypoint en la dirección actual
        indiceDestino += direccion;

        // Si llega al final o al principio, invierte la dirección de manera segura
        if (indiceDestino >= waypoints.Length)
        {
            indiceDestino = waypoints.Length - 1;
            direccion = -1;
        }
        else if (indiceDestino < 0)
        {
            indiceDestino = 0;
            direccion = 1;
        }

        agente.SetDestination(waypoints[indiceDestino].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugador = other.transform;
            persiguiendo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            persiguiendo = false;
            jugador = null;
            SiguientePunto();
        }
    }
}