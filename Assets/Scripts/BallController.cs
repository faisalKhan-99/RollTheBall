using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class BallController : MonoBehaviour
{

    private Rigidbody rb; //needed this to apply force on the rigidbody used in the game.This holds a reference to the body we need access to

    private float movementX;
     private float movementY;

     //to display scores
     public TextMeshProUGUI countText;
    public GameObject winTextObject;
  

     public float speed=0;
     private int count; // private variables need to be intialised here cant be done from the inspector


    // Start is called before the first frame update
    void Start() 
    {
        //Start() is the very first frame of the game



        //sets value by getting it from the rigibody component attached with the GameObject
        rb = GetComponent<Rigidbody>();
        

        count = 0; //initial score

        SetCountText ();


         // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);

    }

    //this is the method name that InputPackage gives us to use
    void OnMove(InputValue movementValue){
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
            movementY = movementVector.y;
    }



        void SetCountText()
    {
        countText.text = "Tester's Count: " + count.ToString();

        if (count >= 6) 
        {
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
                    countText.text = ""; 

        }
    }




    void FixedUpdate(){
        //to add force to the playerGameObject rigid body

        Vector3 movement = new Vector3(movementX,0.0f,movementY);
    rb.AddForce(movement*speed); // we made new variables for addForce method because it takes a vector3 in its input only
    }

    private void OnTriggerEnter(Collider other){
        //to detect collisions

        if(other.gameObject.CompareTag("Collectible")){ //tag check done before disabling objects
            other.gameObject.SetActive(false);//this will disable objects,but which one? unity tag will help 
        
            count = count+1;//add score

            // Run the 'SetCountText()' function (see below)
            SetCountText ();
        }
        //other.gameObject.SetActive(false);//this will disable objects,but which one? unity tag will help 
    }

}
