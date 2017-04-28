using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKontroller : MonoBehaviour {

    public Rigidbody rb;
    GameObject player;
    private int speed = 10;
    private float moveJump = 30f;
    private bool grounded;
    private int count;
    public Text countText;
    public Text winText;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grounded = true;
        count = 0;
        setCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        Vector3 jumpVector = new Vector3(moveHorizontal, moveJump, moveVertical);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            double height = rb.velocity.y;

            if (height == 0)
            {
               rb.AddForce(jumpVector * speed);
            }
        
        }
        if(rb.velocity.y < -6)
        {
           winText.text= "You lose!";

        }
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Pick Up"))
            {
               other.gameObject.SetActive(false);
               count = count + 1;
               setCountText();
            }
    }
    
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 15)
        {
            winText.text = "You Win!";
        }
    }
}
