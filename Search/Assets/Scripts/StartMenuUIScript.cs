using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuUIScript : MonoBehaviour {

    public Text playerNameText;
	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonLevel1()
    {
        if(playerNameText.text != "")
        {
            PlayerPrefs.SetString("CurrentPlayer", playerNameText.text);
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Fill in a player name!");
        }
    }

    public void ButtonLevel2()
    {
        if (playerNameText.text != "")
        {
            PlayerPrefs.SetString("CurrentPlayer", playerNameText.text);
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("Fill in a player name!");
        }
    }
}
