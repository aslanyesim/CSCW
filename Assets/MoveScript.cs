using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
    private float move = -0.5f;

    void OnAnimatorMove() {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            Vector3 newPosition = transform.position;
            newPosition.y += move * Time.deltaTime;
            transform.position = newPosition;
            if(transform.position.y < -2.0f){
                move = 0.5f;
            }
        }
    
    }
}
