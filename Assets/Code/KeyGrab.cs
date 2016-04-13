using UnityEngine;
using System.Collections;

public class KeyGrab : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    /*
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "player")
        {
            Destroy(key);
        }
    }
    */

    void OnTriggerEnter(Collider c)
    {
        //destroy key in world
        Destroy(gameObject);
    }
}
