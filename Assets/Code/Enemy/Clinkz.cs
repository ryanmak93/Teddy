using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clinkz : MonoBehaviour
{
    public GameObject projectile;
    public float projspeed = 15;
    public float ythrow = 3;
    public float backswing = 1;
    Transform target;
    public float damage = 5f;
    bool attacking = false;
    bool moving = true;

    //public Transform player;
    private NavMeshAgent agent;
    
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("FirstPersonCharacter").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }

    // Update is called once per frame
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
    void attack()
    {
        agent.Stop();        
        moving = false;
        if (!GetComponent<Animation>().IsPlaying("Attack"))
            Invoke("fire", .5f);
        attacking = true;

        GetComponent<Animation>().Play("Attack");
        Invoke("resetAttack", backswing);
    }
    void fire()
    {
        transform.LookAt(target);
        GameObject arrow = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
        arrow.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x * projspeed,
                ythrow + transform.forward.y * projspeed, transform.forward.z * projspeed), ForceMode.Impulse);
    }
    void resetAttack()
    {
        moving = true;
        attacking = false;
        //agent.Resume();
    }
}


