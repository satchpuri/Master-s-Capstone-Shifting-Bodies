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
        // using (x, z) to apply to worldspace later
        center = new Vector3(Screen.width / 2, 0, Screen.height / 2);
    }

	void Update () {
        // mouse position relative to viewport
        Vector3 mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);

        // make player look in the accoording to the offset of mousePos - center = vector offset
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
    // to prevent multiple targets of interaction at a time, assign most recently entered trigger as target
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Interactable") return;

        target = other.gameObject;
        Debug.Log("Target is " + target.name);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Interactable") return;

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Interacting with " + target.name);
        }
    }
}