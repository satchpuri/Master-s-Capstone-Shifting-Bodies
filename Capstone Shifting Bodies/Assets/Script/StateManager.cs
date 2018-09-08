using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameShiftState { A, B };
public enum TimeState { Past, Present };

public class StateManager : MonoBehaviour {

    public Text StateText;

    /// <summary>
    /// The state of the game. This state should change based on the interactions of the players. 
    /// </summary>
    public GameShiftState GameState = GameShiftState.A;

    /// <summary>
    /// The time state of the game. Only 'Past' and 'Present' available right now. 
    /// </summary>
    public TimeState GameTimeState = TimeState.Present;

    private List<StateController> stateObjects;

	void Start () {
        stateObjects = new List<StateController>(FindObjectsOfType<StateController>());
	}

    public void ToggleTimeState()
    {
        GameTimeState = (GameTimeState == TimeState.Present) ? TimeState.Past : TimeState.Present;
        UpdateStateObjects();
    }

    public void ToggleGameState()
    {
        GameState = (GameState == GameShiftState.A) ? GameShiftState.A : GameShiftState.B;
        UpdateStateObjects();
    }

    /// <summary>
    /// Updates all state controller objects. Calls the OnTimeStateChange delegate function for each object. 
    /// </summary>
    public void UpdateStateObjects()
    {
        foreach (var stObject in stateObjects)
        {
            stObject.OnTimeStateChange(this);
        }
    }
	
	void Update () {

        // Change time state when left shift is pressed.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleTimeState();
        }

        UpdateText();
	}

    void UpdateText()
    {
        StateText.text = "Time: " + GameTimeState.ToString() + ";  Shift State: " + GameState.ToString();
    }
}
