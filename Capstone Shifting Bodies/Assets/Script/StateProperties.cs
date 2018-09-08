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
        public GameShiftState ShiftState;

        public TimeState TimeState;

        public Vector3 Position;

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
