using UnityEngine;
using Image = UnityEngine.UI.Image;
using System.Collections;

public class Nevermore : MonoBehaviour
{
    Transform target;
    public GameObject attackCollider;
    public float movespeed;
    public float backswing;
    public float damage = 5f;
    bool dead = false;
    bool attacking = false;
    bool moving = true;
    public GameObject fireball;
    public float projspeed = 5;
    public float ythrow = 3;
    void Update()
    {
    }
    void move()
    {
        transform.LookAt(target);
        transform.position += transform.forward * movespeed * Time.deltaTime;
    }
    // Use this for initialization
    void Start()
    {
        disableCollider();
        target = GameObject.Find("PlayerTarget").transform;
    }
    void attack()
    {
        moving = false;
        
        transform.LookAt(target);
        if(!GetComponent<Animation>().IsPlaying("Attack"))
        {
            attacking = true;
            GetComponent<Animation>().Play("Attack");
            Invoke("enableCollider", .5f);
            Invoke("resetAttack", backswing);
        }


    }
    void resetAttack()
    {
        moving = true;
        attacking = false;
    }
   
    void enableCollider()
    {
        attackCollider.SetActive(true);
        GameObject newfire = (GameObject) Instantiate(fireball, transform.position, transform.rotation);
        newfire.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x * projspeed,
                ythrow + transform.forward.y * projspeed, transform.forward.z * projspeed), ForceMode.Impulse);

        //Debug.Log("collider active");
        Invoke("disableCollider", .3f);
    }
    void disableCollider()
    {
        attackCollider.SetActive(false);
        //Debug.Log("collider inactive");
        
    }
}


