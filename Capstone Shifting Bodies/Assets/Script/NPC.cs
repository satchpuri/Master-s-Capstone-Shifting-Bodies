using UnityEngine;

// Class for NPCs
public class NPC : MonoBehaviour {

    bool targetted;
    bool notYetInteractedWith;   // whether or not they have anything new to say/do at the time
    public Dialogue dialogue;
    
	void Start () {
        targetted = false;
        notYetInteractedWith = true;
	}

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

	
}
