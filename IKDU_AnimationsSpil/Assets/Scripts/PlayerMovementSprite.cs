using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSprite : MonoBehaviour {
    Vector2 movement; //A 2D vector defining which direction the player is moving.
    Rigidbody2D myBody; //A rigidbody to apply our movement to.
    Animator myAnimator; //An animator, controlling the players animation.
    
    [SerializeField] private int speed = 5; //How fast the player moves.
    
    void Awake(){ //Is called when the script is loaded.
        myBody = GetComponent<Rigidbody2D>(); //We get the rigidbody component from our gameobject.
        myAnimator = GetComponent<Animator>(); //We get the animator component from our gameobject.
    }
    //Is called from the Player Input Component
    void OnMovement(InputValue value){
        movement = value.Get<Vector2>(); //Gets the movement vector value from our input

        // We check if the player is moving by checking if
        // either the x or y value is not 0.
        if(movement.x != 0 || movement.y != 0) {
            myAnimator.SetFloat("x", movement.x); //We set the x variable within the animator to what the movement x value is
            myAnimator.SetFloat("y", movement.y); //We set the y variable within the animator to  what the movement y value is
            myAnimator.SetBool("IsWalking", true); //We set the IsWalking variable within the animator to trrue
        } else { //If the player is not moving, we set the IsWalking variable to false
            myAnimator.SetBool("IsWalking", false);
        }
    }
    //FixedUpdate is called based on the frequency of the physics system, and is framerate independent.
    void FixedUpdate() {
        myBody.velocity = movement * speed; //We calculate velocity by multiplying the movement vector with our speed integer.
    }
}
