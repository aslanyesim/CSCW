using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class TooltipController : MonoBehaviour 
{
    public Camera m_Camera;
	public bool isErrorAnimation;
    // Use this for initialization
    void Start () {
        
    }
     void Update()
     {
         transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                      m_Camera.transform.rotation * Vector3.up);
		if(isErrorAnimation){
			transform.localPosition = new Vector3(-1.50488f, -0.198f, -1.205265f);
		}
     }
} 

