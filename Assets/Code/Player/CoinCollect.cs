using UnityEngine;
using System.Collections;

public class CoinCollect : MonoBehaviour
{
    //public AudioClip soundEffect;
    AudioSource sound;

    // Use this for initialization
    void Start ()
    {
        sound = GetComponent<AudioSource>();        
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void Awake()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        //play sound effect
        if (c.name == "FirstPersonCharacter")
        {
            sound.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Invoke("destroy", sound.clip.length);

        }
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
}

