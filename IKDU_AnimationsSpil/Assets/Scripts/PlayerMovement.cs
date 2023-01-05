using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    Vector2 movement;
    Rigidbody2D myBody;
    Animator myAnimator;
    
    [SerializeField] private int speed = 5;
    
    // Start is called before the first frame update
    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }


    private void OnMovement(InputValue value){
        movement = value.Get<Vector2>();

        if (movement.x > 0) {
            this.transform.localScale = new Vector3(1, 1, 1);
        } else if(movement.x < 0) {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        if(movement.x != 0 || movement.y != 0) {
            myAnimator.SetBool("IsWalking", true);
        } else {
            myAnimator.SetBool("IsWalking", false);
        }
    }
    
    void FixedUpdate() {
        myBody.velocity = movement * speed;
    }
}
