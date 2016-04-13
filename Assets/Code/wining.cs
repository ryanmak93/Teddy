using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wining : MonoBehaviour
{


    public Canvas quitMenu;
  //  public Button startText;
    public Button exitText;
    public Button BuyWeapons;

    // Use this for initialization
    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
      //  startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        BuyWeapons = BuyWeapons.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
     //   startText.enabled = false;
        exitText.enabled = false;
        BuyWeapons.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
     //   startText.enabled = true;
        exitText.enabled = true;
        BuyWeapons.enabled = true;
    }


    public void StartLevel()
    {
        Application.LoadLevel(2);
    } 

    public void Weapons()
    {
        Application.LoadLevel(3);
    }
    public void ExitGame()
    {
        Application.Quit();        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
