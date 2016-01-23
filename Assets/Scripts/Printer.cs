//changes on 18.01.2016

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;

public class Printer : MonoBehaviour
{
    public string ResourceURL = "http://www.mocky.io/v2/5692924f10000092038be2ea";
    public string PrinterURL = "http://www.mocky.io/v2/5696324a1300004e36f9e3cd";
    public Text printerAndBrickInfo;
    public float secondsToCheckServer = .1f;

    private JsonData printerdata;
    private JsonData brickdata;
    private string status = "";
    private string statusSentence = "";
    private string brickAmount = "";
    private string brickSentence = "";

    private bool statusChanged = false;
    private bool brickChanged = false;

    public AddBrick brick = new AddBrick();

    // Use this for initialization
    void Start()
    {
        StartCoroutine(checkForInfo());
    }
    IEnumerator checkForInfo()
    {
        for (; ; )
        {
            WWW www = new WWW(PrinterURL);
            yield return www;
            if (www.error == null)
            {
                printerdata = JsonMapper.ToObject(www.text);
                parsePrinterData();
            }
            else
            {
                Debug.Log("ERROR: " + www.error);
            }

            www = new WWW(ResourceURL);
            yield return www;
            if (www.error == null)
            {
                brickdata = JsonMapper.ToObject(www.text);
                parseBrickData();

            }
            else
            {
                Debug.Log("ERROR: " + www.error);
            }
            writeData();
            yield return new WaitForSeconds(secondsToCheckServer);
        }
    }

    private void parsePrinterData()
    {
        string temp = printerdata["status"].ToString();
        if (status != temp)
        {
            statusChanged = true;
            status = temp;
            statusSentence = "Status: " + status;
        }
        else
        {
            statusChanged = false;
        }


        if (status == "printing")
        {
            string letter = printerdata["letter"].ToString();
            int index = (int)printerdata["index"];

            //CALL PRINTERHEAD animation
           // brick.addBrickAnimation(letter,index);
            //CALL PRiNTiNG ANiMATiON
        }
        else if (status == "error")
        {
            AddBrick.status = false;

            //CALL ERROR ANiMATiON
            //erroranim1(int index);
        }
        else if (status == "waiting")
        { 
            //reset index and letter
        }
    }
    private void parseBrickData()
    {
        for (int i = 0; i < brickdata.Count; i++)
        {
            if (brickdata[i]["name"].ToString() == "brick")
            {
                string temp = brickdata[i]["amount"].ToString();
                if (brickAmount != temp)
                {
                    brickChanged = true;
                    brickAmount = temp;
                    brickSentence = "\nBrick amount: " + brickAmount;
                }
                else
                {
                    brickChanged = false;
                }

            }
        }
    }
    private void writeData()
    {
        if (brickChanged || statusChanged)
            printerAndBrickInfo.text = statusSentence + brickSentence;
        printerdata = null;
        brickdata = null;
    }
}
