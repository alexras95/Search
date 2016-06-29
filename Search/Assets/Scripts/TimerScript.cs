using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    private float runTimeMinutes;
    private float runTimeSeconds;
    private float runTimeCentiseconds;

    public Text runtimeText;
    // Use this for initialization
    void Start () {
        StartCoroutine(Timer());
	}
	
	// Update is called once per frame
	void Update () {
        runtimeText.text = GetTime();
	}

    public IEnumerator Timer()
    {
            yield return new WaitForSeconds(0.01f);
                runTimeCentiseconds++;
                if (runTimeCentiseconds >= 100)
                {
                    runTimeCentiseconds = 0;
                    runTimeSeconds++;
                }
                if (runTimeSeconds >= 60)
                {
                    runTimeSeconds = 0;
                    runTimeMinutes++;
                }
                if (runTimeMinutes >= 60)
                {
                    runTimeCentiseconds = 0;
                    //Game Over
                }
        StartCoroutine(Timer());
    }

    public string GetTime()
    {
        return String.Format("{0:00}:{1:00}:{2:00}", runTimeMinutes, runTimeSeconds, runTimeCentiseconds);
    }

    public int GetTotalRunTime()
    {
        return Convert.ToInt32((runTimeMinutes * 60 + runTimeSeconds) * 100 + runTimeCentiseconds);
    }
}
