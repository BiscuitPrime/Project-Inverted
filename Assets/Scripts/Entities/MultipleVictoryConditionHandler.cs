using Inverted.Actors;
using Inverted.Events;
using Inverted.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Inverted.Entities
{
    public class MultipleVictoryConditionHandler : MonoBehaviour, IActorManager
    {
        [SerializeField, InspectorName("Victory Items")] private GameObject[] _victoryObjects;
        private Dictionary<GameObject, bool> _victoryDict;
        private void Start()
        {
            _victoryDict = new Dictionary<GameObject, bool>();
            foreach (GameObject obj in _victoryObjects)
            {
                _victoryDict.Add(obj,false);
            }
            EventHandler.Instance.PartialVictoryEvent.AddListener(OnPartialVictoryEventReceived);
        }

        private void OnDestroy()
        {
            if(EventHandler.Instance.PartialVictoryEvent is not null)
            {
                EventHandler.Instance.PartialVictoryEvent.RemoveListener(OnPartialVictoryEventReceived);
            }
        }

        private void OnPartialVictoryEventReceived(PartialVictoryEventArgument arg)
        {
            if (arg.Type == PartialVictoryEventType.PartialWinConditionSuccess)
            {
                _victoryDict[arg.Sender] = true;
                Debug.Log("[PARTIAL VICTORY HANDLER] : Updating success condition for : " + arg.Sender + " to status : " + _victoryDict[arg.Sender]);
            }
            else
            {
                _victoryDict[arg.Sender] = false;
                Debug.Log("[PARTIAL VICTORY HANDLER] : Updating success condition for : " + arg.Sender + " to status : " + _victoryDict[arg.Sender]);
            }
        }

        private bool TestAllVictoryConditionsAchieved()
        {
            foreach(var item in _victoryDict.Keys)
            {
                Debug.Log("[PARTIAL VICTORY HANDLER] : TESTING success condition for : " + item + " | " + _victoryDict[item]);
                if (_victoryDict[item] == false)
                {
                    return false;
                }
            }
            //if we arrive here, all conditions have been met => trigger success
            return true;
        }

        public void TriggerAction()
        {
            if (TestAllVictoryConditionsAchieved())
            {
                GameManager.Instance.TriggerLevelSuccess();
            }
            else
            {
                GameManager.Instance.TriggerLevelFailure();
            }
        }
    }
}
