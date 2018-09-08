// Class for NPCs
public class NPC : InteractableObject {

	public Dialogue dialogue;
    
	public override void TriggerInteraction(bool alreadyInteracting)
    { 
		if (!alreadyInteracting)
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogue.speaker);
		else 
			FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

	
}
