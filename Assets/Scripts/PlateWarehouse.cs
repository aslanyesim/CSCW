//changes on 18.01.2016

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;

public class PlateWarehouse : MonoBehaviour
{
    public string ResourceURL = "http://www.mocky.io/v2/5692924f10000092038be2ea";
    public Text amountInfo;
    public float secondsToCheckServer = .1f;

    private JsonData data;
    private string amount = "";

    void Start()
    {

    }
	public void getIP(string address){
		ResourceURL = "http://" + address +"/resources"; 
		Debug.Log("Resource: " + ResourceURL);
		StartCoroutine(checkForInfo());
	}

    IEnumerator checkForInfo()
    {
        for (; ; )
        {
            WWW www = new WWW(ResourceURL);
            yield return www;
            if (www.error == null)
            {

                data = JsonMapper.ToObject(www.text);
                parseData();
            }
            else
            {

                Debug.Log("ERROR: " + www.error);
            }
            yield return new WaitForSeconds(secondsToCheckServer);
        }
    }

    private void parseData()
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i]["name"].ToString() == "plate")
            {
                string temp = data[i]["amount"].ToString();
                //if the information has changed update the tooltip
                if (amount != temp)
                {
                    amount = temp;
                    writeData();
                }
                data = null;
                //go out from the loop if the plate warehouse info is found
                break;
            }
        }
    }
    private void writeData()
    {
        amountInfo.text = "Type: Plates\nAmount: " + amount;
        //data = null;
    }
}
