using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject[] enemy;
    public Text wavetext;
    public int limit = 3;
    int wave = 0;
    int wavelimit = 5;
    bool win = false;
    public bool isOver = false;
    int count;
	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
        wavetext.text = wave.ToString();
        if (wave > wavelimit)
            wavetext.text = "--";
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            wave++;
            if (wave > wavelimit && !win)
            {
                GameObject player = GameObject.Find("FirstPersonCharacter");
                player.SendMessage("win");
                win = true;
            }
            if(!win)
                spawning();
        }
        
            
            
    }
    void spawning()
    {
        if(wave == 1)
        {
            Instantiate(enemy[0], transform.position, transform.rotation);
            Instantiate(enemy[0], transform.position, transform.rotation);
        }
        if (wave == 2)
        {
            Instantiate(enemy[0], transform.position, transform.rotation);
            Instantiate(enemy[0], transform.position, transform.rotation);
            Instantiate(enemy[0], transform.position, transform.rotation);
            Instantiate(enemy[1], transform.position, transform.rotation);
            Instantiate(enemy[1], transform.position, transform.rotation);
        }
        if (wave == 3)
        {
            Instantiate(enemy[2], transform.position, transform.rotation);
            Instantiate(enemy[2], transform.position, transform.rotation);
            Instantiate(enemy[0], transform.position, transform.rotation);
            Instantiate(enemy[1], transform.position, transform.rotation);
            Instantiate(enemy[1], transform.position, transform.rotation);
            Instantiate(enemy[0], transform.position, transform.rotation);
        }
        if (wave == 4)
        {
            Instantiate(enemy[3], transform.position, transform.rotation);
            Instantiate(enemy[3], transform.position, transform.rotation);
            Instantiate(enemy[2], transform.position, transform.rotation);
            Instantiate(enemy[2], transform.position, transform.rotation);
        }
        if (wave == 5)
        {
            Instantiate(enemy[3], transform.position, transform.rotation);
            Instantiate(enemy[2], transform.position, transform.rotation);
            Instantiate(enemy[2], transform.position, transform.rotation);
            Instantiate(enemy[2], transform.position, transform.rotation);
            Instantiate(enemy[0], transform.position, transform.rotation);
            Instantiate(enemy[0], transform.position, transform.rotation);
            Instantiate(enemy[1], transform.position, transform.rotation);
            Instantiate(enemy[1], transform.position, transform.rotation);
            Instantiate(enemy[3], transform.position, transform.rotation);
        }

    }
}
