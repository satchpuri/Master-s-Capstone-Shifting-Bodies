using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeSample : InteractableObject
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void TriggerInteraction(bool alreadyInteracting)
    {
        FindObjectOfType<StateManager>().GameState = FindObjectOfType<StateManager>().GameState == GameShiftState.A ? GameShiftState.B : GameShiftState.A;
    }
}
