using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour
{
    public int damage = 50;
    public float range = 5;
    public float toTarget;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Attack"))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                toTarget = hit.distance;
                if(toTarget < range)
                {
                    hit.transform.SendMessage("DeductPoints", damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
	}
}
