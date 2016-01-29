using UnityEngine;
using System.Collections;
using LitJson;
using UnityEngine.UI;

public class Plate : MonoBehaviour {
	public Text plate;
	public string plateURL = "http://www.mocky.io/v2/56a1027c4200004a3e83eb72";
	public float secondsToCheckServer = .1f;

	private string letter = "";
	private JsonData data;
	// Use this for initialization
	void Start () {
		StartCoroutine(loadPlateData());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator loadPlateData()
	{
		for (; ; )
		{
			WWW www = new WWW(plateURL);
			yield return www;
			if (www.error == null)
			{
				data = JsonMapper.ToObject(www.text);
				string temp = data["letter"].ToString();
				if (letter != temp)
				{
					letter = temp;
					writeLetter();
					//Print the new animation??
				}
			}
			else
			{
				Debug.Log("ERROR: " + www.error);
			}
			yield return new WaitForSeconds(secondsToCheckServer);
		}
	}
	private void writeLetter(){
		plate.text = "Letter: " + letter;
	}
}
