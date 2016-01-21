using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;

public class Printer : MonoBehaviour {
	public string ResourceURL = "http://www.mocky.io/v2/5692924f10000092038be2ea";
	public string PrinterURL = "http://www.mocky.io/v2/5696324a1300004e36f9e3cd";
	public Text printerAndBrickInfo;
	public float secondsToCheckServer = .1f;

	private JsonData printerdata;
	private JsonData brickdata;
	private string status = "";
	private string brickAmount = "";



	// Use this for initialization
	void Start () {
		StartCoroutine(checkForInfo());
	}
	IEnumerator checkForInfo(){
		for(;;){
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
	
	private void parsePrinterData(){
			status = printerdata["status"].ToString();
		if(status == "printing"){
			//CALL PRiNTiNG ANiMATiON
		} else if (status == "error"){
			//CALL ERROR ANiMATiON
		}
	}
	private void parseBrickData(){
		for (int i = 0; i < brickdata.Count; i++)
		{ 
			if(brickdata[i]["name"].ToString() == "brick"){
				brickAmount = brickdata[i]["amount"].ToString();
			}
		}
	}
	private void writeData(){
		printerAndBrickInfo.text = "Status: " + status +"\nBrick amount: " + brickAmount;
		printerdata = null;
		brickdata = null;
	}
}
