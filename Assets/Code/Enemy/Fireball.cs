using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{
    AudioSource sound;
    public Vector4 rotate = new Vector4(-90f, 0, 0, 0);
    bool fix = false;

    public GameObject fire;
    // Use this for initialization
    void Start()
    {
        transform.Rotate(rotate);
        sound = GetComponent<AudioSource>();
        Invoke("fixit", .1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" && fix)
        {
            sound.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Invoke("destroy", 3f);
            transform.Rotate(-rotate);
            Instantiate(fire, transform.position, transform.rotation);
        }
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
    void fixit()
    {
        fix = true;
    }
}

