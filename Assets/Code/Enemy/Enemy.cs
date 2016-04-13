using UnityEngine;
using Image = UnityEngine.UI.Image;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Transform target;
    public GameObject coin;
    public float attackrange;
    //public float backswing;
    public float maxHealth;
    public float damage = 5f;
    public Image slider;
    float currentHealth;
    bool dead = false;
    bool attacking = false;
    bool move = true;
    Vector3 deathposition;
    float distance;
    void Update()
    {
        var wantedPos = Camera.main.WorldToScreenPoint(this.transform.position);
        slider.transform.position = wantedPos;

        if (currentHealth <= 0 && !dead)
        {
            die();
        }
        if (currentHealth >= 0)
        {
            //currentHealth -= Time.deltaTime;
            //currentHealth --;
            slider.fillAmount = currentHealth / maxHealth;
        }
        if (currentHealth != maxHealth)
        {
            slider.enabled = true;
        }
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (!GetComponent<Animation>().IsPlaying("Attack") && !dead && distance > attackrange)
        {
            SendMessage("move");            
        }

        if (distance < attackrange && !attacking && !dead)
        {
            SendMessage("attack");
        }
    }

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        slider.fillAmount = 1f;
        //slider.enabled = false;

        slider.transform.position = transform.position;
        target = GameObject.Find("PlayerTarget").transform;
    }


    void die()
    {
        dead = true;
        slider.enabled = false;
        deathposition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        slider.transform.parent.gameObject.SetActive(false);
        GetComponent<Animation>().Play("Die");
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
        GameObject newcoin = (GameObject)Instantiate(coin, new Vector3(deathposition.x, deathposition.y + 1f, deathposition.z), new Quaternion(90f, 0, 0, 0));
        newcoin.transform.Rotate(90, 0, 0);
    }
    void takedamage(float damage)
    {
        //Debug.Log("enemydamage");
        currentHealth -= damage;
    }
}


