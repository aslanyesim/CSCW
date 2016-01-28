using UnityEngine;
using System.Collections;
public class PrinterHeadAnimator : MonoBehaviour
{

    public float speed = 1.0f;
    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(Down());

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    float Lerp(float startposition, float endposition, float speed) {
        return Mathf.Lerp(startposition, endposition, speed);
    }

    IEnumerator Down()
    {
        Debug.Log("DOWN");
        //StopCoroutine(RightX());
        for (; ; )
        {
            transform.position = new Vector3(transform.position.x, Lerp(transform.position.y, -0.13f, Time.time * speed), transform.position.z);
            if (transform.position.y.Equals(-0.13f))
            {
                StartCoroutine(Up());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Up() {
        Debug.Log("UP");
        StopCoroutine(Down());
        for (; ; )
        {
            transform.position = new Vector3(transform.position.x, Lerp(-0.13f, 1.0f, Time.time * speed ), transform.position.z);
            if (transform.position.y.Equals(1.0f))
            {
                StartCoroutine(RightX());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    
    }

    IEnumerator RightX()
    {
        Debug.Log("RIght");
        StopCoroutine(Up());
      //  float x = 0.25f;
        for (; ; )
        {
            Debug.Log("LOOPBAS  " + transform.position.x);
            transform.position = new Vector3(Lerp(transform.position.x, 0.25f, Time.time * speed), transform.position.y, transform.position.z);
            Debug.Log("LOOP  " + transform.position.x);
            if (transform.position.x.Equals(0.25f))
            {
                Debug.Log("STOPRIGHTX   " + transform.position.x);

                StartCoroutine(RightZ());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator RightZ()
    {
        StopCoroutine(RightX());
        for (; ; )
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Lerp(0.25f, 0.55f, Time.time * speed ));
            if (transform.position.z.Equals(0.55f))
            {
                StartCoroutine(Down2());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Down2()
    {
        StopCoroutine(RightZ());
        for (; ; )
        {
            transform.position = new Vector3(transform.position.x, Lerp(transform.position.y, -0.13f, Time.time * speed * 10), transform.position.z);
            if (transform.position.y.Equals(-0.13f))
            {
                StartCoroutine(Up2());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Up2()
    {
        StopCoroutine(Down2());
        for (; ; )
        {
            transform.position = new Vector3(transform.position.x, Lerp(-0.13f, 1.0f, Time.time * speed * 5), transform.position.z);
            if (transform.position.y.Equals(1.0f))
            {
                StartCoroutine(LeftZ());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }


    IEnumerator LeftZ()
    {
        StopCoroutine(Up2());
        for (; ; )
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Lerp(transform.position.z, 0.25f, Time.time * speed));
            if (transform.position.z.Equals(startPosition.z))
            {
                StartCoroutine(LeftX());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator LeftX()
    {
        StopCoroutine(LeftZ());
        for (; ; )
        {
            transform.position = new Vector3(Lerp(transform.position.x, -1.61f, Time.time * speed), transform.position.y, transform.position.z);
            if (transform.position.x.Equals(-1.61f))
            {
                //StartCoroutine(Down());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}