using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class teddymoving: MonoBehaviour
{
    public AudioClip[] purchase;
    /*  public Text Score;
      private Rigidbody rigid;
      private int cost;




      void Start()
      {
       Score.text = "Total Cost: " + cost.ToString();
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
              cost = cost+ 50;
              Score.text = "Total Cost: " + cost.ToString(); 
          }
          if (col.gameObject.name == "door")
              SceneManager.LoadScene("shopscene");
      }

  }*/


    public Text Points_txt;
    private int Points;
    public Text winText;
    float time = 1f;
    public Text dialog;
    int i;
    GameObject item;

    private Rigidbody r;
    // Use this for initialization
    void Start()
    {
        //  speed = 1.5f;
        Points = 0;
        //ScoreUpdate();
        r = GetComponent<Rigidbody>();
        i = purchase.Length - 1;


    }


    


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //r.AddForce(movement * 10);
        //transform.Translate(movement/3);
        GetComponent<CharacterController>().Move(movement/4);
        i--;
        if (i < 0)
            i = purchase.Length - 1;
    }


    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.name == "gun")
    //    {
    //        Destroy(col.gameObject);
    //        Points= Points+50;
    //        ScoreUpdate();
    //        Invoke("DisplayDialog", time);
    //        AudioSource audio = GetComponent<AudioSource>();
    //        audio.clip = purchase[i];
    //        audio.Play();

    //    }
    //    if (col.gameObject.name == "door")
    //        SceneManager.LoadScene("shopscene");


    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "gun")
    //    {
    //        Destroy(other.gameObject);
    //        Points = Points + 50;
    //        ScoreUpdate();
    //        Invoke("DisplayDialog", time);
    //        AudioSource audio = GetComponent<AudioSource>();
    //        audio.clip = purchase[i];
    //        audio.Play();
    //    }
    //    if (other.gameObject.name == "door")
    //        SceneManager.LoadScene("shopscene");


    //}

    void DisplayDialog()
    {
        dialog.text = "That's a powerful weapon you’ve got there!";
    }

    void buy(int cost)
    {
        int score = PlayerPrefs.GetInt("coins");
        Debug.Log(item.name);
        if (item != null && score > cost)
        {
            item.SendMessage("destroy");
            dialog.text = "That's a powerful weapon you’ve got there!";
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = purchase[i];
            audio.Play();

            SendMessage("updateCoins", -cost);
        }
        else
            dialog.text = "Not enough gold!";


        item = null;
            
    }
       
    void itemobject(string itemname)
    {
        item = GameObject.Find(itemname);
        Debug.Log(item.tag);
    }
}