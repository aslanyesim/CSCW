using UnityEngine;
using System.Collections;
public class TouchBrick : MonoBehaviour
{
    public GameObject BrickNew;
    public GameObject PrinterHead;
    private Joint theJoint;
    public GameObject Cube;
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision col)
    {
        Debug.Log("HELLLOGYLKAAAAA22");
        if (col.gameObject.name == "BrickPrefab")
        //if(col.collider.tag == "brick")
        {
            Debug.Log("HELLLOGYLKAAAAA");
            theJoint = gameObject.AddComponent<FixedJoint>();
            theJoint.connectedBody = col.rigidbody;
            //col.transform.parent = PrinterHead.transform;
        }
    }
}