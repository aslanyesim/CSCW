using UnityEngine;
using System.Collections;
public class TouchBrick : MonoBehaviour
{
    public GameObject BrickNew;
    public GameObject PrinterHead;
    private Joint theJoint;
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "BrickNew (5)")
        {
            theJoint = gameObject.AddComponent<FixedJoint>();
            theJoint.connectedBody = col.rigidbody;
        }
    }
}