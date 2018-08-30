using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_movement : MonoBehaviour
{
    public float speed = 50.0f;
    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        speed = 50.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
            rb.AddForce(Vector3.up * 0.1f, ForceMode.Impulse);
        }

        transform.position += transform.forward * Time.deltaTime * speed;

        Vector3 moveCamTo = transform.position + -transform.forward * 30.0f + Vector3.up * 5.0f;
        Camera.main.transform.position = moveCamTo;
        Camera.main.transform.LookAt(transform.position);


        transform.Rotate(-Input.GetAxis("Vertical"),  0.0f, -Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.Cross(transform.up, transform.forward) * 0.1f, ForceMode.Impulse);
            transform.Rotate( 0.0f, Input.GetAxis("Horizontal") ,0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Vector3.Cross(transform.up, transform.forward) * 0.1f, ForceMode.Impulse);
            transform.Rotate(0.0f, Input.GetAxis("Horizontal") , 0.0f);
        }
    }

}
