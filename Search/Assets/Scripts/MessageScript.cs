using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageScript : MonoBehaviour {

    public string message;
    public Text messageText;
    private Vector3 originalPos;
    bool movingUp;
    private float moving;
    public string messageName;
    public bool finish;
    public TimerScript timer;
	// Use this for initialization
	void Start () {
        originalPos = this.gameObject.transform.position;
        StartCoroutine(FlowMoving());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        messageText.text = message;
        if (finish)
        {
            PlayerPrefs.SetInt("TotalRuntime",timer.GetTotalRunTime());
            PlayerPrefs.SetInt("LastPlayedScene", SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Finished with " + PlayerPrefs.GetInt("TotalRuntime"));
            SceneManager.LoadScene(2);
        }
        this.gameObject.SetActive(false);
        //Show message in messagebox
    }

    void OnMouseOver()
    {
        if (movingUp)
        {
            this.gameObject.transform.Translate(new Vector3(0, 0.02f, 0));
        }
        else
        {
            this.gameObject.transform.Translate(new Vector3(0, -0.02f, 0));
        }
            
    }

    void OnMouseExit()
    {
        this.gameObject.transform.position = originalPos;
    }

    private IEnumerator FlowMoving()
    {
        yield return new WaitForSeconds(0.1f);
        if (movingUp)
        {
            movingUp = false;
        }
        else
        {
            movingUp = true;
        }
        StartCoroutine(FlowMoving());
    }
}
