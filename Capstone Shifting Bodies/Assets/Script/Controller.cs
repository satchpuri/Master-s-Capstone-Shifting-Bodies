using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour {

	public float moveSpeed = 6;

	Rigidbody rigidbody;
	Camera viewCamera;
	Vector3 velocity;
    Vector3 center;

    private GameObject target;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		viewCamera = Camera.main;

        // point at centre of viewport
        center = new Vector3(Screen.width / 2, 0, Screen.height / 2);
    }

	void Update () {
        // mouse position relative to viewport
        Vector3 mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        transform.LookAt (mousePos - center,  Vector3.up);
		velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * moveSpeed;

		// reset scene
		if (Input.GetKeyDown (KeyCode.LeftShift))
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }

	void FixedUpdate() {
		rigidbody.MovePosition (rigidbody.position + velocity * Time.fixedDeltaTime);
	}

    // used for interacting with things in front of player
    // to prevent multiple targets of interaction at a time, assign most recently entered trigger as target (finicky)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Interactable") return;

        // if previous target existed, unhighlight
        if (target) target.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);


        // set new target
        target = other.gameObject;
        Debug.Log("Target is " + target.name);

        // highlight new target
        target.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);

    }

    private void OnTriggerExit(Collider other)
    {
        if (target) target.GetComponent<Renderer>().material.SetColor("_Color", Color.gray); 
    }

    // handle interactions with current target in range
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Interactable") return;

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Interacting with " + target.name);
            if (target.GetComponent<NPC>())
                target.GetComponent<NPC>().TriggerDialogue();
        }
    }
}