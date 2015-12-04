using UnityEngine;
using System.Collections;

public class UiScriptt : MonoBehaviour {

    public void changeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
