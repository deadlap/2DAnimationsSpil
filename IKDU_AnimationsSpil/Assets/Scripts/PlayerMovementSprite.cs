using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSprite : MonoBehaviour {
    Vector2 movement;
    Rigidbody2D myBody;
    Animator myAnimator;
    
    [SerializeField] private int speed = 5;
    
    // Start is called before the first frame update
    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void OnMovement(InputValue value){
        movement = value.Get<Vector2>();

        if(movement.x != 0 || movement.y != 0) {
            myAnimator.SetFloat("x", movement.x);
            myAnimator.SetFloat("y", movement.y);
            myAnimator.SetBool("IsWalking", true);
        } else {
            myAnimator.SetBool("IsWalking", false);
        }
    }
    
    void FixedUpdate() {
        myBody.velocity = movement * speed;
    }
}
