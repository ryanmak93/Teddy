using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Patrol_mec : MonoBehaviour
{

    Transform target;
    //public Transform player;
    private NavMeshAgent agent;
    Animator anim;
    public GameObject coin;
    public Image slider;
    public float maxHealth = 20;
    float currentHealth;
    public float sightrange = 5;
    GameObject patroldest;
    GameObject[] patrol;
    int waypoint = 0;
    bool walking = true;
    bool dead = false;
    public float attackrange = 3;
    float damage = 10;
    Vector3 deathposition;
    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        target = GameObject.Find("FirstPersonCharacter").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        patrol = GameObject.FindGameObjectsWithTag("Waypoint");
        Debug.Log(patrol.Length);
        patroldest = patrol[0];
    }

    // Update is called once per frame
    void Update()
    {
        var wantedPos = Camera.main.WorldToScreenPoint(this.transform.position);
        slider.transform.position = wantedPos;

        transform.LookAt(agent.destination);
        float distance = Vector3.Distance(transform.position, target.position);
        float patroldist = Vector3.Distance(transform.position, patroldest.transform.position);
        if (distance < sightrange)
        {
            agent.SetDestination(target.position);

        }
        if(distance > 3 && !dead)
        {
            agent.Resume();
        }
        if(distance < 3)
        {
            agent.Stop();
            anim.Play("Attack", -1);
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
        if (currentHealth <= 0 && !dead)
        {
            die();
        }
        if (currentHealth >= 0)
        {
            slider.fillAmount = currentHealth / maxHealth;
        }
        if (currentHealth != maxHealth)
        {
            slider.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "Weapon")
        {
            currentHealth -= damage;
        }
        if (other.tag == "Waypoint")
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
    void die()
    {
        dead = true;
        slider.enabled = false;
        deathposition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        slider.transform.parent.gameObject.SetActive(false);
        agent.Stop();
        anim.Play("Die", -1);
        Invoke("stopanim", 2);

        Invoke("fall", 2);
        transform.position -= transform.up * .5f * Time.deltaTime;
        GetComponent<Collider>().enabled = false;
        Invoke("despawn", 5);
    }
    void despawn()
    {
        Destroy(this.gameObject);
    }
    void fall()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GameObject newcoin = (GameObject)Instantiate(coin, deathposition, new Quaternion(90f, 0, 0, 0));
        newcoin.transform.Rotate(90, 0, 0);
    }
    void stopanim()
    {
        anim.Stop();
    }
}

