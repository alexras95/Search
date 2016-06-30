using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostObjectScript : MonoBehaviour
{
    public int state;
    public Vector3 position;
    public Vector3 position2;
    public Vector3 position3;
    public Text messageText;
    public bool invisible;
    private Vector3 originalPos;
    bool movingUp;
    private float moving;
    public TimerScript timer;

    // Use this for initialization
    void Start()
    {
        invisible = true;
        state = Random.Range(1, 4);
        if (state == 1)
        {
            this.gameObject.transform.position = position;
        }
        else if (state == 2)
        {
            this.gameObject.transform.position = position2;
        }
        else if (state == 3)
        {
            this.gameObject.transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        originalPos = this.gameObject.transform.position;
        StartCoroutine(FlowMoving());

        if (invisible)
        {
            //
        }
    }

    void OnMouseDown()
    {
        PlayerPrefs.SetInt("TotalRuntime", timer.GetTotalRunTime());
        PlayerPrefs.SetInt("LastPlayedScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Finished with " + PlayerPrefs.GetInt("TotalRuntime"));
        SceneManager.LoadScene(2);

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
