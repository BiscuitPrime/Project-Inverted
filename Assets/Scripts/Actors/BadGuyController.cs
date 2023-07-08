using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Actors
{
    public class BadGuyController : MonoBehaviour, IActorManager
    {
        private bool _behaviourEnabled = false;

        public void TriggerAction()
        {
            Debug.Log("BAD GUY : Triggering action");
            _behaviourEnabled = true;
        }
    }
}
