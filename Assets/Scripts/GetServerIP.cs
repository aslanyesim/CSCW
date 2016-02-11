using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetServerIP : MonoBehaviour {
	
	public string serverURL;

	public void getIP(string address){
		serverURL = address;
		Canvas canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
}
