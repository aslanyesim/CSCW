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
        if (col.gameObject.name == "BrickNew")
        {
            theJoint = gameObject.AddComponent<FixedJoint>();
            theJoint.connectedBody = col.rigidbody;
            //col.transform.parent = PrinterHead.transform;
        }
        else
        {
            Cube.SetActive(true);
        }
    }
}