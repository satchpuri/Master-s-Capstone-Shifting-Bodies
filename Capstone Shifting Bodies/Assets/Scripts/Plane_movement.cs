using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_movement : MonoBehaviour
{
    public float speed = 0.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speed = Mathf.Lerp(speed, 50.0f, 0.01f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed = Mathf.Lerp(speed, 0.0f, 0.01f);
        }
        transform.position += -transform.forward * Time.deltaTime * speed;
        transform.position += transform.up * Time.deltaTime * speed / 20;
        Vector3 moveCamTo = transform.position + transform.forward * 30.0f + Vector3.up * 5.0f;
        Camera.main.transform.position = moveCamTo;
        Camera.main.transform.LookAt(transform.position);


        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));	
	}
}
