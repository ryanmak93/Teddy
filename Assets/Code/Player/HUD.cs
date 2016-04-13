using UnityEngine;
using Image = UnityEngine.UI.Image;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {
    public Image slider;
    public Image bloodborder;
    float currentHealth;
    public float maxHealth = 100;
    float curr = 1;
    bool lose = false;
    public AudioClip[] hurt;
    public AudioClip[] spawn;
    public AudioClip[] start;
    public AudioClip[] finish_wave;
    public AudioClip[] death;
    public AudioClip[] coin;
    public AudioClip[] victory;
    AudioSource sound;
	// Use this for initialization
	void Start ()
    {
        //bloodborder = GameObject.Find("Canvas").GetComponent<Image>();
        bloodborder.enabled = false;
        slider.fillAmount = 1f;
        currentHealth = maxHealth;
        slider.enabled = true;
        sound = GetComponent<AudioSource>();
        randomline(spawn);
    }
	
	// Update is called once per frame
	void Update ()
    {
        slider.fillAmount = currentHealth / maxHealth;
        //currentHealth -= Time.deltaTime;
        if (currentHealth <= 0 && !lose)
            die();
        if(lose)
        {
            GetComponent<CharacterController>().enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(!bloodborder.enabled)
        {        
            //Debug.Log("HIT player");
            bool damage = false;
            //Debug.Log(other.GetComponent<Collider>().name);
            if (other.tag == "Enemy")
            {
                currentHealth -= 10;
                damage = true;
            }
            
            if(other.name == "arrow(Clone)")
            {
                currentHealth -= 10;
                damage = true;
            }
            if (damage)
                bloodborder.enabled = true;
            Invoke("removeBorder", 2f);
            //Debug.Log(currentHealth);
            if (other.tag == "Fire")
            {
                currentHealth -= 10;
                damage = true;
            }
            if (damage)
            {
                bloodborder.enabled = true;
                randomline(hurt);
            }            
            Invoke("removeBorder", 2f);
            //Debug.Log(currentHealth);
        }
    }
    void removeBorder()
    {
        bloodborder.enabled = false;
    }
    void randomline(AudioClip[] sounds)
    {
        float randfloat = Random.Range(0, sounds.Length);
        int randint = (int)Mathf.Round(randfloat);
        //Debug.Log(randfloat);
        sound.clip = sounds[randint];
        sound.Play();
    }
    void die()
    {
        randomline(death);
        Invoke("endgamelose", sound.clip.length + 2f);
        lose = true;
   
    }
    void endgamelose()
    {
        SceneManager.LoadScene("losing scen");
    }
    void win()
    {
        Debug.Log("win");
        randomline(victory);
        Invoke("endgamewin", sound.clip.length + 2f);
    }
    void endgamewin()
    {
        SceneManager.LoadScene("winningscene");
    }
}
