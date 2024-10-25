using UnityEngine;

public class AgentController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private GameObject[] targets;
    [SerializeField] private int indexTarget;
    [SerializeField] private float stopDistance = 0.5f;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = targets[indexTarget].transform.position;
        ChoosingTarget();
    }

    private void Update()
    {
        CheckPointTarget();
    }

    private void CheckPointTarget()
    {
        if (!agent.pathPending && agent.remainingDistance <= stopDistance)
        {
            ChoosingTarget();
        }
    }

    private void ChoosingTarget()
    {
        indexTarget = Random.Range(0, targets.Length);
        agent.SetDestination(targets[indexTarget].transform.position); 
    }
}
