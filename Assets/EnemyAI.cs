using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Estados


    // Referencias a otros objetos importantes
    public Transform player;  // El jugador
    public Transform[] patrolPoints;  // Puntos de patrullaje
    public int health = 100;  // Salud del enemigo
    public float fleeSpeed = 5f;  // Velocidad de huida del enemigo
    public ControladorStados controladorStados;



    // Referencia al NavMeshAgent
    private NavMeshAgent agent;

    private void Start()
    {
        // Obtener el NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

    }


    // Mueve al enemigo hacia un objetivo usando NavMeshAgent
    public void MoveTowards(Vector3 targetPos)
    {
        agent.SetDestination(targetPos);
    }




    // Comprobar si el enemigo está cerca de otros enemigos para evitar colisiones
    public bool IsNearOtherEnemies()
    {
        // Comprobar si el enemigo está cerca de otros enemigos (esto depende de tu implementación de enemigos)
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") && hitCollider != this.GetComponent<Collider>())
            {
                return true;
            }
        }
        return false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controladorStados.detectado = true;
        }
        else
        {
            controladorStados.detectado = false;
        }
    }

    void ha_perseguido()
    {
        controladorStados.ha_buscado = true;
    }

    void no_ha_perseguido()
    {
        controladorStados.ha_buscado = false;
    }
}