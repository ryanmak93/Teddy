using UnityEngine;
using System.Collections;

public class MeleeWeapon : MonoBehaviour
{
    public float damage;
    bool attack;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Animation>().IsPlaying("meleeattack") || GetComponent<Animation>().IsPlaying("meleeswing"))
        {
            attack = true;
        }
        else
        {
            attack = false;
        }
        //Debug.Log(attack);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (attack) 
            other.SendMessage("takedamage", damage);
    }


    //public void OnCollisionEnter(Collision collision)
    //{
    //    if(attack)
    //        collision.gameObject.SendMessage("takedamage", damage, SendMessageOptions.DontRequireReceiver);
    //}

}
