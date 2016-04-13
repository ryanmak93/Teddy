using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class    TEDDYSHOPSCRIPT: MonoBehaviour
{

   private Rigidbody rigid;   



    void Start()
    {
   //  Score.text = "Total Cost: " + cost.ToString();
        rigid = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {


        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 ballmove = new Vector3(Horizontal, 0.0f, Vertical);

        rigid.AddForce(ballmove * 30);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
      void OnCollisionEnter(Collision col)
    
    {
        if (col.gameObject.name == "gun")
        {
            Destroy(col.gameObject);
       //     cost = cost+ 50;
       //     Score.text = "Total Cost: " + cost.ToString(); 
        }
        if (col.gameObject.name == "door")
            SceneManager.LoadScene("shopscene");
    }
        
}
