using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_movement : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position -= transform.forward * Time.deltaTime * 90.0f;

        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));	
	}
}
