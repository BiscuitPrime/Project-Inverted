using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Inverted.Events
{
    public enum GameEventType
    {
        ChargeWinConditionSuccess, //requests a change in the win condition that will lead to success
        ChargeWinConditionFailure, //requests a change in the win condition that will lead to failure
    }
    public enum PartialVictoryEventType
    {
        PartialWinConditionSuccess,
        PartialWinConditionFailure,
    }
    public struct PartialVictoryEventArgument
    {
        public PartialVictoryEventType Type;
        public GameObject Sender;
    }
    public class GameEvent : UnityEvent<GameEventType> { }
    public class PartialVictoryEvent : UnityEvent<PartialVictoryEventArgument> { }

    public class EventHandler : MonoBehaviour
    {
        #region SINGLETON DESIGN PATTERN
        private static EventHandler _instance;
        public static EventHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventHandler();
                }
                return _instance;
            }
        }
        private void Awake()
        {
            _instance = this;
            DontDestroyOnLoad(this);
            GameEvent = new GameEvent();
            PartialVictoryEvent = new PartialVictoryEvent();
        }
        #endregion

        public GameEvent GameEvent;
        public PartialVictoryEvent PartialVictoryEvent;
    }
}
