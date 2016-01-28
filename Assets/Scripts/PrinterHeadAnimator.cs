using UnityEngine;
using System.Collections;
public class PrinterHeadAnimator : MonoBehaviour
{

    public float speed = 1.0f;
    public float timeTakenDuringLerp = 1f;
    private Vector3 startPosition;
    private float _timeStartedLerping;
    private Vector3 TempPosition;
    public AddBrick brick;
    public bool status = false;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(Down());
    }

    // Update is called once per frame
    void Update()
    {

      //  TempPosition = transform.TransformPoint(brick.temp);

    }

    float Lerp(float startposition, float endposition, float speed)
    {
        return Mathf.Lerp(startposition, endposition, speed);
    }

    IEnumerator Down()
    {
        yield return new WaitForSeconds(3.0f);
        _timeStartedLerping = Time.time;
        for (; ; )
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
            transform.position = new Vector3(transform.position.x, Lerp(transform.position.y, -0.2f, /*Time.time * speed*/percentageComplete), transform.position.z);
            if (percentageComplete >= 1.0f)
            {
                StartCoroutine(Up());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Up()
    {
        _timeStartedLerping = Time.time;
        StopCoroutine(Down());
        for (; ; )
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
            transform.position = new Vector3(transform.position.x, Lerp(-0.13f, 1.0f, /*Time.time * speed*/percentageComplete), transform.position.z);
            if (percentageComplete >= 1.0f)
            {
                StartCoroutine(RightX());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator RightX()
    {
        _timeStartedLerping = Time.time;
        StopCoroutine(Up());
        for (; ; )
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
            transform.position = new Vector3(Lerp(transform.position.x, 0.25f,/* Time.time * speed*/percentageComplete), transform.position.y, transform.position.z);
            if (transform.position.x.Equals(0.25f))
            {
                StartCoroutine(RightZ());
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator RightZ()
    {
        _timeStartedLerping = Time.time;
        StopCoroutine(RightX());
        for (; ; )
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
            transform.position = new Vector3(transform.position.x, transform.position.y, Lerp(0.25f, 0.55f, /*Time.time * speed*/percentageComplete));
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
        _timeStartedLerping = Time.time;
        StopCoroutine(RightZ());
        for (; ; )
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
            transform.position = new Vector3(transform.position.x, Lerp(transform.position.y, -0.13f, /*Time.time * speed * 10*/ percentageComplete), transform.position.z);
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
        _timeStartedLerping = Time.time;
        StopCoroutine(Down2());
        for (; ; )
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
            transform.position = new Vector3(transform.position.x, Lerp(-0.13f, 1.0f,/* Time.time * speed * 5*/percentageComplete), transform.position.z);
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
        _timeStartedLerping = Time.time;
        StopCoroutine(Up2());
        for (; ; )
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
            transform.position = new Vector3(transform.position.x, transform.position.y, Lerp(transform.position.z, 0.25f,/* Time.time * speed*/ percentageComplete));
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
        _timeStartedLerping = Time.time;
        StopCoroutine(LeftZ());
        for (; ; )
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
            transform.position = new Vector3(Lerp(transform.position.x, -1.61f, /*Time.time * speed*/percentageComplete), transform.position.y, transform.position.z);
            if (transform.position.x.Equals(-1.61f))
            {
                status = true;
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}