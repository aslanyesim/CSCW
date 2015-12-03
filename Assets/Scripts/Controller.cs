using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

    public Camera m_Camera;
    private Typer typer;
    private Animator menuAnim;
    private bool menuOn = false;

    void Awake() { 
        typer = GetComponentInChildren<Typer>();
        menuAnim = GetComponent<Animator>();
    }

    public void BeginMenu() {
        if(!menuOn) {
            menuAnim.SetTrigger("FadeIn");
            typer.StartCoroutine("TypeIn");
            menuOn = true;
        }
        else {
           // menuAnim.SetTrigger("FadeOut");
            typer.StartCoroutine("TypeOff");
            menuOn = false;
        }
    }

    public void SubMenu()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                         m_Camera.transform.rotation * Vector3.up);
       // gameObject.SetActive(false);
    }
}
