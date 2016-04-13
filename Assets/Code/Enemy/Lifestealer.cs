using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lifestealer : MonoBehaviour {
    GameObject target;
    //public Transform player;
    private NavMeshAgent agent;
    bool walking = true;
    float backswing = 1;
    public float damage = 5f;
    bool attacking = false;
    bool moving = true;
    public float ythrow;
    public float leapspeed;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("FirstPersonCharacter");
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);

    }
	
	// Update is called once per frame
	void Update () {

    }

    void move()
    {
        GetComponent<Animation>().Play("Walk");
        transform.LookAt(target.transform);
        agent.Resume();
        GetComponent<Animation>().Play("Walk");
        agent.SetDestination(target.transform.position);
    }

    void attack()
    {
        agent.Stop();
        moving = false;
        if (!GetComponent<Animation>().IsPlaying("Attack") && !attacking)
        {
            attacking = true;
            transform.LookAt(target.transform);
            GetComponent<Animation>().Play("Attack");
            GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x * leapspeed,
                ythrow + transform.forward.y * leapspeed + 3, transform.forward.z * leapspeed), ForceMode.Impulse);
            Invoke("resetAttack", backswing);

        }         

    }
    void resetAttack()
    {
        moving = true;
        attacking = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
   
}
