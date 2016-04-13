using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterSneha : MonoBehaviour
{
    public string scene;

  //  private bool canEnter = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

   void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Weapon")
{
       
            Application.LoadLevel("teddyshop");
    }
    
   
}
}

