using UnityEngine;
using System.Collections;
public class PrinterHeadAnimator : MonoBehaviour
{
    public int maxSpeed;
    Animator anim;
    AddBrick Brick;
    int MoveHash = Animator.StringToHash("PrinterHeadMove");

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
      //  anim = GetComponent<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Brick.GetComponent<AddBrick>().xpos;
       // float z = Brick.GetComponent<AddBrick>().zpos;
        MoveVertical();
       // anim.SetTrigger(MoveHash);
    }

    void MoveVertical()
    {
        transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time * maxSpeed), transform.position.z);

        //yield return new WaitForSeconds(1);
        //if(transform.position.y > 4.0f)
        //{
        //	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //}
        //else if(transform.position.y < 2.0f)
        //{
        //	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //}
    }
    void MoveHorizontal()
    {
       // transform.position = new Vector3(Brick.GetComponent<AddBrick>().xpos, transform.position.y, Brick.GetComponent<AddBrick>().zpos);
    }

}