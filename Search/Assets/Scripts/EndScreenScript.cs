using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour {

    public Text runTimeText;
    public Text newBestTime;
    public Text bestTimeText;

    private int bestTime;
    private int lastTime;
	// Use this for initialization
	void Start () {
        bestTime = PlayerPrefs.GetInt("BestTime" + PlayerPrefs.GetInt("LastPlayedScene"));
        Debug.Log(PlayerPrefs.GetInt("LastPlayedScene"));
        lastTime = PlayerPrefs.GetInt("TotalRuntime");
        runTimeText.text = centiSecondsToString(lastTime);
        if(lastTime < bestTime || bestTime == 0)
        {
            PlayerPrefs.SetString("BestTimePlayer" + PlayerPrefs.GetInt("LastPlayedScene"),PlayerPrefs.GetString("CurrentPlayer"));
            PlayerPrefs.SetInt("BestTime" + PlayerPrefs.GetInt("LastPlayedScene"), PlayerPrefs.GetInt("TotalRuntime"));
            newBestTime.text = "New Best Time!";
        }
        else
        {
            newBestTime.text = "You did not beat the record set by " + PlayerPrefs.GetString("BestTimePlayer" + PlayerPrefs.GetInt("LastPlayedScene"));
        }
        bestTimeText.text = "Best Time: " + centiSecondsToString(PlayerPrefs.GetInt("BestTime" + PlayerPrefs.GetInt("LastPlayedScene")));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private string centiSecondsToString(int totalTime)
    {
        Debug.Log(totalTime);

        int runTimeCentiseconds = totalTime % 100;
        int runTimeSeconds = ((totalTime - runTimeCentiseconds) / 100) % 60;
        int runTimeMinutes = ((totalTime / 100) - runTimeSeconds) / 60;

        return String.Format("{0:00}:{1:00}:{2:00}", runTimeMinutes, runTimeSeconds, runTimeCentiseconds);
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
