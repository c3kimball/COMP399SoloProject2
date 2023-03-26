using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyClown : MonoBehaviour
{

    public Animator anim;
    public NavMeshAgent agent;
    public Transform[] points;
    private int pointCount;

    // Start is called before the first frame update
    void Start()
    {
        
        int rand = Random.Range(0, points.Length);
        agent.SetDestination(points[rand].position);
        anim.SetTrigger("Walk");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            int rand = Random.Range(0, points.Length);
            agent.SetDestination(points[rand].position);
            ++pointCount;
            Debug.Log("Arrived! point count = " + pointCount);
        }
    }
}
