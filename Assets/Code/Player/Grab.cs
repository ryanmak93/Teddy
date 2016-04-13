using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Grab : MonoBehaviour {

    public Transform target;
    Collider collide;

	// Use this for initialization
	void Start ()
    {
        //start with gravity
        collide = GetComponent<Collider>();
        collide.attachedRigidbody.useGravity = true;
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnMouseOver()
    {
        //only grab when e pressed and over object
        if(Input.GetKeyDown(KeyCode.E))
        {
            //move object ahead of player
            this.transform.position = target.position;
            this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;

            //no gravity
            collide.attachedRigidbody.useGravity = false;
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {            
            //release object
            this.transform.parent = null;
            //gravity
            collide.attachedRigidbody.useGravity = true;            
        }
    }

    void OnMouseExit()
    {
        //release object
        this.transform.parent = null;
        //gravity
        collide.attachedRigidbody.useGravity = true;
    }


    /*
    void OnMouseDown()
    {
        //move object ahead of player
        this.transform.position = target.position;
        this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
    }
      */
   
  

}
