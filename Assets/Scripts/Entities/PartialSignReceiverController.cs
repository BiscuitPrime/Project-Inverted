using Inverted.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Entities
{
    /// <summary>
    /// Script of the signs receiver when there is MULTIPLE signs that need to be verified for it to work
    /// </summary>
    public class PartialSignReceiverController : SignReceiverController
    {
        protected override void OnTriggerEnter(Collider other)
        {
            Debug.Log("[SIGN RECEIVER] : Trigger entered");
            if (other.gameObject == _target) //if it's indeed the sign that enters its range, we update the win condition to success
            {
                Debug.Log("[SIGN RECEIVER] : Sending success event : ");
                EventHandler.Instance.PartialVictoryEvent.Invoke(new PartialVictoryEventArgument() { Sender=gameObject,Type=PartialVictoryEventType.PartialWinConditionSuccess });
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            Debug.Log("[SIGN RECEIVER] : Trigger exited");
            if (other.gameObject == _target) //if the sign leaves the area, we update the condition to failure
            {
                Debug.Log("[SIGN RECEIVER] : Sending failure event : ");
                EventHandler.Instance.PartialVictoryEvent.Invoke(new PartialVictoryEventArgument() { Sender = gameObject, Type = PartialVictoryEventType.PartialWinConditionFailure });
            }
        }
    }
}
