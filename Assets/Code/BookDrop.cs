using UnityEngine;
using System.Collections;

public class BookDrop : MonoBehaviour
{
    public GameObject book;

    // Use this for initialization
    void Start()
    {
        //Instantiate(enemy, transform.position, transform.rotation);
        InvokeRepeating("spawn", 0, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        Instantiate(book, transform.position, transform.rotation);
    }
}
