using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Estados
    public State currentState;
    public EnemyPatrolState patrolState;
    public EnemyChaseState chaseState;
    public EnemyFleeState fleeState;
    public EnemyWaitState waitState;

    // Referencias a otros objetos importantes
    public Transform player;  // El jugador
    public Transform[] patrolPoints;  // Puntos de patrullaje
    public int health = 100;  // Salud del enemigo
    public float fleeSpeed = 5f;  // Velocidad de huida del enemigo
    private bool playerInTrigger = false;

    // Referencia al NavMeshAgent
    private NavMeshAgent agent;

    private void Start()
    {
        // Inicializa los estados
        patrolState = new EnemyPatrolState();
        chaseState = new EnemyChaseState();
        fleeState = new EnemyFleeState();
        waitState = new EnemyWaitState();

        // Obtener el NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // El estado inicial es patrullaje
        SwitchState(patrolState);
    }

    private void Update()
    {
        // Actualiza el estado actual
        currentState.UpdateState(this);

        Debug.Log(currentState);
    }

    // Cambiar de estado
    public void SwitchState(State newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    // Mueve al enemigo hacia un objetivo usando NavMeshAgent
    public void MoveTowards(Vector3 targetPos)
    {
        // Utiliza el NavMeshAgent para moverse hacia el objetivo
        agent.SetDestination(targetPos);
    }

    // Detectar si el enemigo ve al jugador (puedes expandir esta función con Raycast o visión con campo de visión)
    public bool CanSeePlayer()
    {
        return playerInTrigger;
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
            playerInTrigger = true;
        }
        else
        {
            playerInTrigger = false;
        }
    }
}