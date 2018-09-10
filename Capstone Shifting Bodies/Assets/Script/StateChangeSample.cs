using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeSample : InteractableObject
{
    public override void TriggerInteraction(bool alreadyInteracting)
    {
        //Toggles the state of the game 
        /// Ideally, if x happened, change state to A, if y happened, change state to B etc.
        FindObjectOfType<StateManager>().GameState = FindObjectOfType<StateManager>().GameState == GameShiftState.A ? GameShiftState.B : GameShiftState.A;
    }
}
