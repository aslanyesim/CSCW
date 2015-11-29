using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class ReadJSON : MonoBehaviour {
	private JsonData bricksData;

	// Use this for initialization
	IEnumerator Start () {
		string url = "http://paultondeur.com/files/2010/UnityExternalJSONXML/books.json";
		//string url = "http://192.168.1.102:8080/brick";
		WWW www = new WWW(url);
		
		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null)
		{
			//Sucessfully loaded the JSON string
			Debug.Log("Loaded following JSON string" + www.text);
			bricksData = JsonMapper.ToObject(www.text);
			Debug.Log (bricksData["book"][0]["title"].ToString());
			//Debug.Log (bricksData[0]["name"].ToString());
		}	
		else
		{
			Debug.Log("ERROR: " + www.error);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
