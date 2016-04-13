using UnityEngine;
using System.Collections;

public class ShopItem : MonoBehaviour
{
    public int cost;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        other.SendMessage("itemobject", this.gameObject.name);
        other.SendMessage("buy", cost);        
        
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
}
