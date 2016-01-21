using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class TooltipController : MonoBehaviour 
{
    public Camera m_Camera;

    // Use this for initialization
    void Start () {
        
    }
     void Update()
     {
         transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                      m_Camera.transform.rotation * Vector3.up);
        
        
     }
} 

