using UnityEngine;

// Class for NPCs
public class NPC : InteractableObject
{
    public Dialogue dialogue;

    StateController stateController;

    public void Start()
    {
        stateController = GetComponent<StateController>();
        if (stateController != null)
        {   
            // Assign the time and state's dialogues to NPC to reflect change in state.
            // This delegate function will be invoked whenever the time state changes. 
            stateController.OnTimeStateChangeAction = (StateManager stateManager) =>
            {
                Debug.Log("Test");
                var state = stateManager.GameState;
                var timeState = stateManager.GameTimeState;
                dialogue = stateController.stateMap[timeState][state].Dialogues; // Change NPC's dialogues according to given time and state. 
            };
        }
    }

    public override void TriggerInteraction(bool alreadyInteracting)
    {
        if (!alreadyInteracting)
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogue.speaker);
        else
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }


}
