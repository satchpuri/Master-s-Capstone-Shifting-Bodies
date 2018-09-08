using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameShiftState { A, B };
public enum TimeState { Past, Present };

public class StateManager : MonoBehaviour {

    public GameShiftState GameState = GameShiftState.A;
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

    public void UpdateStateObjects()
    {
        foreach (var stObject in stateObjects)
        {
            stObject.OnTimeStateChange(this);
        }
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleTimeState();
        }
	}
}
