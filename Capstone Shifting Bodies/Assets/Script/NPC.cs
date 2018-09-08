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
            stateController.OnTimeStateChangeAction = (StateManager stateManager) =>
            {
                Debug.Log("Test");
                var state = stateManager.GameState;
                var timeState = stateManager.GameTimeState;
                dialogue = stateController.stateMap[timeState][state].Dialogues;
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
