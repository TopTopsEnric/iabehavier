using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints; // Puntos de patrulla
    private NavMeshAgent agente;
    private int indiceDestino = 0;
    private Transform jugador; // Referencia al jugador
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
        else if (jugador != null) // Si está persiguiendo o huyendo
        {
            float distancia = Vector3.Distance(transform.position, jugador.position);

            if (vidaJugador > 50f) // Si la vida del jugador está por encima de la mitad, lo persigue
            {
                agente.SetDestination(jugador.position);
            }
            else // Si la vida del jugador está a la mitad o menos, huye
            {
                Vector3 direccionHuir = (transform.position - jugador.position).normalized;
                Vector3 destinoHuir = transform.position + direccionHuir * 10f; // Se mueve 10 unidades en dirección opuesta
                agente.SetDestination(destinoHuir);
            }
        }
    }

    void SiguientePunto()
    {
        if (waypoints.Length == 0) return;

        indiceDestino = (indiceDestino + 1) % waypoints.Length; // Cambia al siguiente waypoint
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
            SiguientePunto(); // Vuelve a patrullar si el jugador se va
        }
    }
}