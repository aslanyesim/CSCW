using UnityEngine;
using System.Collections;

public class UiScript : MonoBehaviour {

	public void changeScene(string sceneName){
		Application.LoadLevel(sceneName);
	}
}
