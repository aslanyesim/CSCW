using UnityEngine;
using System.Collections;
public class PrinterHeadAnimator : MonoBehaviour
{
    public int maxSpeed;
    public float speed = 0.1f;
    private Vector3 startPosition;
    private Vector3 tempPosition;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
       // anim = GetComponent<Animator>();
        startPosition = transform.position;

        //Temp();
        //StartCoroutine(DownUp());

    }
    void Temp() {
        if (transform.position.y.Equals(1.0f))
        {
            Debug.Log("ANIMATIOONN");
            anim = GetComponent<Animator>();
            anim.enabled = true;
            anim.Play("PrinterHEad 1");
        }
    }


    // Update is called once per frame
    void Update()
    {

        
        //transform.position = new Vector3(transform.position.x, PingPong(Time.time * speed, -0.13f, 1.0f), transform.position.z);
       // float x = ;

       // float z = Brick.zpos;
        //move the cube from (0, 0, 0) to (5, 0, 0) and back to (0, 0, 0) and so on.
        //use the same Mathf.PingPong function to the other axes if you need to move in those axes as well

        //transform.position = new Vector3(PingPong(Time.time * speed, -5, 5), transform.position.y, transform.position.z);
       // anim.SetTrigger(MoveHash);
    }

    IEnumerator MoveVertical()
    {
        float time = 0.0f;
        for (; ; ) {
            transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time * maxSpeed), transform.position.z);

            yield return new WaitForSeconds(0.1f);
            time += 0.1f;
            if(time == 5.0f)
                break;
 }
        time = 0.0f;
         for (; ; ) {
           //transform.position = new Vector3(PingPong(Time.time * speed, startPosition.x, Brick.xpos), startPosition.y, startPosition.z);
            yield return new WaitForSeconds(0.1f);
            time += 0.1f;
            if(time == 5.0f)
                break;
 }
           

        }
            
        //yield return new WaitForSeconds(1);
        //if(transform.position.y > 4.0f)
        //{
        //	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //}
        //else if(transform.position.y < 2.0f)
        //{
        //	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //}
    
    //void MoveHorizontal()
  //  {
       // transform.position = new Vector3(Brick.GetComponent<AddBrick>().xpos, transform.position.y, Brick.GetComponent<AddBrick>().zpos);
   // }

   //function to change the default starting value of (0, 0, 0) to any value
   float PingPong(float t, float minLength, float maxLength)
   {
            return Mathf.PingPong(t, maxLength - minLength) + minLength;
   }



   IEnumerator DownUp()
   {
       for (; ; )
       {
           transform.position = new Vector3(transform.position.x, PingPong(Time.time * speed, -0.13f, 1.0f ), transform.position.z);
           Debug.Log("DOWNNNUPPPP");
          // transform.position = new Vector3(transform.position.x, PingPong(Time.time * speed, transform.position.y, 1.0f), transform.position.z);
          /* if (transform.position.y.Equals(1.0f))
           {
               Debug.Log("ENDLOOPGLYKAAAA");
           }*/
           yield return new WaitForSeconds(0.1f);
       }
       //Debug.Log("ENDLOOPGLYKAAAA");
   }
}