using UnityEngine;
using System.Collections;

public class CreateBrick : MonoBehaviour
{
    public GameObject BrickNew;
    public GameObject PrinterHead;
    private Joint theJoint;
    public GameObject Cube;
    public Rigidbody rb;

    public Vector3 temp;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(addBrick2());

    }

    IEnumerator addBrick2()
    {

        Vector3 pos = new Vector3(0.34f, 1.29f, -0.27f);
        temp = transform.TransformPoint(pos);
        GameObject a = (GameObject)Instantiate(BrickNew, temp, Quaternion.identity);
        a.transform.parent = transform;
        yield return new WaitForSeconds(3);

    }
}
