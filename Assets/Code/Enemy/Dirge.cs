using UnityEngine;
using Image = UnityEngine.UI.Image;
using System.Collections;

public class Dirge : MonoBehaviour
{
    private NavMeshAgent agent;
    Transform target;
    public GameObject attackCollider;
    //bool dead = false;
    bool attacking = false;
    bool moving = true;
    float backswing = 1;

    void Update()
    {


    }
    void move()
    {
        GetComponent<Animation>().Play("Walk");
        transform.LookAt(target.transform);
        agent.Resume();
        //GetComponent<Animation>().Play("Walk");
        agent.SetDestination(target.transform.position);
    }

    // Use this for initialization
    void Start()
    {
        disableCollider();
        target = GameObject.Find("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }
    void attack()
    {
        agent.Stop();
        moving = false;
        attacking = true;
        transform.LookAt(target);
        GetComponent<Animation>().Play("Attack");
        Invoke("enableCollider", .5f);
        Invoke("resetAttack", backswing);

    }
    void resetAttack()
    {
        moving = true;
        attacking = false;
    }

    void enableCollider()
    {
        attackCollider.SetActive(true);  

        //Debug.Log("collider active");
        Invoke("disableCollider", .3f);
    }
    void disableCollider()
    {
        attackCollider.SetActive(false);
        //Debug.Log("collider inactive");

    }
}
