using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;

public class PlateWarehouse : MonoBehaviour {
	public string ResourceURL = "http://www.mocky.io/v2/5692924f10000092038be2ea";
	public Text amountInfo;
	public float secondsToCheckServer = .1f;

	private JsonData data;
	private string amount = "";

	void Start () {
		StartCoroutine(checkForInfo());
	}
	

	IEnumerator checkForInfo(){
		for(;;){
		WWW www = new WWW(ResourceURL);
		yield return www;
		if (www.error == null)
		{
			data = JsonMapper.ToObject(www.text);
			parseData();
			writeData();
		}
		else
		{
			Debug.Log("ERROR: " + www.error);
		}
			yield return new WaitForSeconds(secondsToCheckServer);
		}
	}

	private void parseData(){
		for (int i = 0; i < data.Count; i++)
		{ 
			if(data[i]["name"].ToString() == "plate"){
				amount = data[i]["amount"].ToString();
			}
		}
	}
	private void writeData(){
		amountInfo.text= "Type: Plates\nAmount: " + amount; 
		data = null;
	}
}
