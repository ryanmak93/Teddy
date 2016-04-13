using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    public AudioClip shoot;
    public AudioClip hit;
    public float projspeed = 10;
    public float ythrow = 3;
    AudioSource sound;
    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
        //this.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x * projspeed,
        //        ythrow + transform.forward.y * projspeed, transform.forward.z * projspeed), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        arrowhit(collision.collider);
    }

    public void OnTriggerEnter(Collider other)
    {
        arrowhit(other);
    }

    void arrowhit(Collider other)
    {
        if ((other.tag == "Obstacle" && other.name != "Terrain") || other.name == "Player")
        {
            if (other.name == "Player")
            {
                sound.clip = hit;
                sound.Play();
            }
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Invoke("destroy", hit.length);

        }
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
}
