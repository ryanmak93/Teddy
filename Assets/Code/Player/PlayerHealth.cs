using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public GameObject healthBar;

	// Use this for initialization
	void Start ()
    {
        maxHealth = 100f;
        health = maxHealth;

        //InvokeRepeating("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void decreaseHealth()
    {
        setHealthBar((health -= 2f) / maxHealth);
    }

    void setHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.x);
    }
}
