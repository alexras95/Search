using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageScript : MonoBehaviour
{
    public LostObjectScript lostObject;
    public string message;
    public string message2;
    public string message3;
    public Text messageText;
    private Vector3 originalPos;
    bool movingUp;
    private float moving;

    // Use this for initialization
    void Start()
    {
        originalPos = this.gameObject.transform.position;
        StartCoroutine(FlowMoving());

        if(lostObject.state == 1)
        {
            if(message == "")
            {
                this.gameObject.SetActive(false);
            }
        }else if(lostObject.state == 2)
        {
            if(message2 == "")
            {
                this.gameObject.SetActive(false);
            }
        }else if(lostObject.state == 3)
        {
            if(message3 == "")
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

        if (lostObject.state == 1)
        {
            messageText.text = message;
            this.gameObject.SetActive(false);
            //Show message in messagebox
        }
        else if (lostObject.state == 2)
        {
            messageText.text = message2;
            this.gameObject.SetActive(false);
            //Show message in messagebox
        }
        else if (lostObject.state == 3)
        {
            messageText.text = message3;
            this.gameObject.SetActive(false);
            //Show message in messagebox
        }
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
