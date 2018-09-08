using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
	public PlayerResponses options;

	bool targetted = false;
	bool notYetInteractedWith = true;   // whether or not they have anything new to say/do at the time

	public virtual void TriggerInteraction(bool alreadyInteracting)
	{ 
		FindObjectOfType<DialogueManager>().DisplayOptions(options);
	}


}
