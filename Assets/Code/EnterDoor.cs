using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    public string scene;

    private bool canEnter = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("Key") == null)
        {
            canEnter = true;
        }
    }

    void OnTriggerEnter()
    {

        if(canEnter)
            Application.LoadLevel(scene);
    }
}
