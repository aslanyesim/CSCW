using UnityEngine;
using System.Collections;

public class PHeadScript : StateMachineBehaviour {
    public GameObject PrinterHead;
    public int maxSpeed;
    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        Debug.Log(" PRINTERRRRRRRRRRRRRRSECONDBEGINGINGGLOOOP");
        //  anim = GetComponent<Animator>();
        startPosition = PrinterHead.GetComponent<Transform>().position;
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
        Debug.Log(" PRINTERRRRRRRRRRRRRRSECONDBEGINGINGGLOOOP");
        PrinterHead.GetComponent<Transform>().position = new Vector3(PrinterHead.GetComponent<Transform>().position.x, startPosition.y + Mathf.Sin(Time.time * maxSpeed), PrinterHead.GetComponent<Transform>().position.z);
    }

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
    //
    //}

    // OnStateMachineExit is called when exiting a statemachine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
    //
    //}
}
