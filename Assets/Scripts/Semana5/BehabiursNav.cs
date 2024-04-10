using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BehabiursNav : MonoBehaviour
{
    //public Transform target;


    [Header("Arrive")]
    [SerializeField] Transform target;
    [SerializeField] bool ArriveB;
    [Header("Wander")]
    [SerializeField] float range = 10.0f;
    [SerializeField] float distanceToEvade = 2f;
    [SerializeField] bool WanderB;
    [Header("Evade")]
    [SerializeField] float distanceRadius = 2f;
    [SerializeField] bool EvadeB;
    Vector3 evadePoint;
    UnityEngine.AI.NavMeshAgent agent;
    Vector3 rp ;
    // Use this for initialization
    void Start()
    {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        rp = RandowPointInNavMesh(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Arrive(ArriveB);
        Wander(WanderB);
        Evade();

    }
    void Arrive(bool ArriveB)
    {
        if (ArriveB)
        {
            agent.SetDestination(target.position);
        }
    }
    void Evade()
    {
        if((transform.position-target.position).magnitude<= agent.stoppingDistance)
        {
            Debug.Log("Distancia entre los puntos " + (transform.position - target.position).magnitude);
            Vector3 center = (transform.position - ((target.position - transform.position).normalized * 2.5f));
            evadePoint = center + Random.insideUnitSphere * distanceRadius;
            agent.SetDestination(evadePoint);
        }
    }
    void Wander(bool WanderB)
    {
        if (WanderB)
        {
            agent.SetDestination(rp);
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                rp = RandowPointInNavMesh(transform.position);
                Vector3 randomPoint = transform.position + Random.insideUnitSphere * range;
            }
        }
        
       

    }
    
    Vector3 RandowPointInNavMesh(Vector3 center)
    {
           
            for (int i = 0; i < 30; i++)
            {
                Vector3 randomPoint = center + Random.insideUnitSphere * range;
                NavMeshHit hit;
                if(NavMesh.SamplePosition(randomPoint,out hit ,range, NavMesh.AllAreas))
                {
                    
                    return hit.position;
                }
            }
            return Vector3.zero;
          
    }

    private void OnDrawGizmos()
    {
        if (WanderB)
        {
            if (rp != Vector3.zero)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(rp, 1);
                Gizmos.DrawLine(transform.position, rp);
            }

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, range);
        }
        if (EvadeB)
        {
            if (evadePoint != Vector3.zero)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(evadePoint, 1);
                Gizmos.DrawLine(transform.position, evadePoint);
            }
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position-((target.position-transform.position).normalized*2.5f), distanceRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, agent.remainingDistance);
        }

    }
}
