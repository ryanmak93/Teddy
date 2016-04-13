using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour
{
    public GameObject attackCollider;
    Transform target;
    //public Transform player;
    private NavMeshAgent agent;
    public float sightrange = 5;
    GameObject patroldest;
    GameObject[] patrol;
    int waypoint = 0;
    bool walking = true;
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("FirstPersonCharacter").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        patrol = GameObject.FindGameObjectsWithTag("Waypoint");
        Debug.Log(patrol.Length);
        patroldest = patrol[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(walking)
            GetComponent<Animation>().Play("Walk");
        float distance = Vector3.Distance(transform.position, target.position);
        float patroldist = Vector3.Distance(transform.position, patroldest.transform.position);
        if (distance < sightrange)
        {
            agent.SetDestination(target.position);

        }
        if (distance > sightrange)
        {
            agent.SetDestination(patroldest.transform.position);
        }
        if (patroldist < 2)
        {
            Debug.Log("waypoint reached");
            if (distance > sightrange)
            {
                waypoint++;
                if (waypoint >= patrol.Length)
                    waypoint = 0;
                patroldest = patrol[waypoint];
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Waypoint")
        {
            Debug.Log("waypoint reached");
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > sightrange)
            {
                waypoint++;
                if (waypoint >= patrol.Length)
                    waypoint = 0;
                patroldest = patrol[waypoint];
            }
        }

    }
}

