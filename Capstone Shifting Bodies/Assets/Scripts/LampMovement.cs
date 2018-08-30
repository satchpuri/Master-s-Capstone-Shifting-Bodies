using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMovement : MonoBehaviour {

    // Lamp needs to be able to move by hopping, connect to a power source, and turn the light on and off
    public Rigidbody rbody;
    public int hopDistance;
    public int hopHeight;
    public GameObject light;
    private bool isGrounded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        //hop a short distance in the direction of the key pressed
        if(isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rbody.velocity = new Vector3(0, hopHeight, hopDistance);
                isGrounded = false;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                rbody.velocity = new Vector3(-hopDistance, hopHeight, 0);
                isGrounded = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rbody.velocity = new Vector3(0, hopHeight, -hopDistance);
                isGrounded = false;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rbody.velocity = new Vector3(hopDistance, hopHeight, 0);
                isGrounded = false;
            }
        }
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(light.activeSelf == true)
            {
                light.SetActive(false);
            }
            else
            {
                light.SetActive(true);
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isGrounded)
        {
            if(collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }
    }

}
