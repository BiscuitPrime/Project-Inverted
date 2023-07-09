using Inverted.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Entities
{
    /// <summary>
    /// Script used by the sign receiver gameobject, that will change the win condition of the scene if the sign is correctly placed.
    /// </summary>
    public class SignReceiverController : MonoBehaviour
    {
        [SerializeField,InspectorName("Target")] protected GameObject _target;

        protected virtual void OnTriggerEnter(Collider other)
        {
            Debug.Log("[SIGN RECEIVER] : Trigger entered");
            if (other.gameObject == _target) //if it's indeed the sign that enters its range, we update the win condition to success
            {
                EventHandler.Instance.GameEvent.Invoke(GameEventType.ChargeWinConditionSuccess);
            }
        }

        //We want to avoid the situation of the player moving correctly the sign, then moving it again and still winning due to the non-update 
        protected virtual void OnTriggerExit(Collider other)
        {
            Debug.Log("[SIGN RECEIVER] : Trigger exited");
            if (other.gameObject == _target) //if the sign leaves the area, we update the condition to failure
            {
                EventHandler.Instance.GameEvent.Invoke(GameEventType.ChargeWinConditionFailure);
            }
        }
    }
}
