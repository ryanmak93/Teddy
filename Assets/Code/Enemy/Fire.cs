using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Invoke("destroy", 2f);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();
	}
    void destroy()
    {
        Destroy(this.gameObject);
        //Destroy(this);
    }
}
