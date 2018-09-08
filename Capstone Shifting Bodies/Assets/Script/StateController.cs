using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    /// <summary>
    /// Stores the state properties for this object. Defines the position of the object based on time and state. These values should be modified
    /// from the editor. 
    /// </summary>
    public List<StateProperties> stateProperties = new List<StateProperties>(StateProperties.GetDefaultProperties());

    public OnChangeAction OnTimeStateChangeAction;

    /// <summary>
    /// Contains the state properties in a nested dictionary where time and state are the keys
    /// </summary>
    public Dictionary<TimeState, Dictionary<GameShiftState, StateProperties>> stateMap;

    public delegate void OnChangeAction(StateManager manager);

    void Start()
    {
        BuildStateMap();
    }

    void Update()
    {
    }

    /// <summary>
    /// Called by state manager whenever the time state changes
    /// </summary>
    /// <param name="stateManager"></param>
    public void OnTimeStateChange(StateManager stateManager)
    {
        //Change position of object based on time and state.
        var state = stateManager.GameState;
        var timeState = stateManager.GameTimeState;
        var position = stateMap[timeState][state].Position;
        transform.position = position;

        //Call custom function if available
        if (OnTimeStateChangeAction != null)
        {
            OnTimeStateChangeAction(stateManager);
        }
        BuildStateMap();
    }

    /// <summary>
    /// Set state properties
    /// </summary>
    /// <param name="customProperties"></param>
    public void SetCustomProperties(List<StateProperties> customProperties)
    {
        stateProperties = customProperties;
        BuildStateMap();
    }

    /// <summary>
    /// Puts the state properties into a dictionary for ease of access when time state changes. 
    /// </summary>
    void BuildStateMap()
    {
        stateMap = new Dictionary<TimeState, Dictionary<GameShiftState, StateProperties>>();
        stateMap.Add(TimeState.Past, new Dictionary<GameShiftState, StateProperties>());
        stateMap.Add(TimeState.Present, new Dictionary<GameShiftState, StateProperties>());

        foreach (var prop in stateProperties)
        {
            var shiftState = prop.ShiftState;
            var timeState = prop.TimeState;
            stateMap[timeState].Add(shiftState, prop);
        }
    }
}
