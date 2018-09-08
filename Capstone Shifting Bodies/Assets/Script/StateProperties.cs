using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Script
{
    [System.Serializable]
    public class StateProperties
    {
        /// <summary>
        /// Shift State for given properties. Will be either A or B
        /// </summary>
        public GameShiftState ShiftState;

        /// <summary>
        /// Time State for given properties. Will be either 'Past' or 'Present'
        /// </summary>
        public TimeState TimeState;

        /// <summary>
        /// Position associated with this time and state.
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// Dialogues associated with this time and state. 
        /// </summary>
        public Dialogue Dialogues;

        public List<Action> TransitionActions = new List<Action>();

        public static ICollection<StateProperties> GetDefaultProperties()
        {
            List<StateProperties> properties = new List<StateProperties>();
            properties.Add(new StateProperties { ShiftState = GameShiftState.A, TimeState = TimeState.Present });
            properties.Add(new StateProperties { ShiftState = GameShiftState.A, TimeState = TimeState.Past });
            properties.Add(new StateProperties { ShiftState = GameShiftState.B, TimeState = TimeState.Present });
            properties.Add(new StateProperties { ShiftState = GameShiftState.B, TimeState = TimeState.Past });
            return properties;
        }
    }
}
