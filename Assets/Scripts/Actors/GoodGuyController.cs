using Inverted.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Actors
{
    public class GoodGuyController : MonoBehaviour, IActorManager
    {
        [SerializeField,InspectorName("Speed")] private float _maxSpeed = 5f;
        private Rigidbody _rb;
        private float _speed = 0f;

        /// <summary>
        /// Function triggered by Game manager when the simulation is run
        /// </summary>
        public void TriggerAction()
        {
            Debug.Log("GOOD GUY : Triggering action");
            _rb = GetComponent<Rigidbody>();
            _rb.isKinematic = true;
            _rb.useGravity = false;
            _speed = _maxSpeed;
        }

        private void Update() 
        {
            transform.position += transform.right * _speed * Time.deltaTime;
        }

        /// <summary>
        /// Function called upon Death of the Good guy, triggered by the gun
        /// </summary>
        public void TriggerDeath()
        {
            Debug.Log("GOOD GUY : Triggered Death");
            //TODO : Implement better death than just disappear
            GameManager.Instance.TriggerLevelFailure(); //Raises a level failure to the game Manager so that it can act upon it
            Destroy(gameObject);
        }

    }
}
