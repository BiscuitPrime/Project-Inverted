using Inverted.Events;
using Inverted.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Actors
{
    public class GoodGuyController : MonoBehaviour, IActorManager
    {
        public bool IsGoodGuy = true;
        [SerializeField,InspectorName("Speed")] private float _maxSpeed = 5f;
        private Rigidbody _rb;
        private float _speed = 0f;

        private void Start()
        {
            EventHandler.Instance.GameEvent.AddListener(OnGameEventChangeWinConditionReceived);
        }

        private void OnDestroy()
        {
            EventHandler.Instance.GameEvent?.RemoveListener(OnGameEventChangeWinConditionReceived);
        }

        /// <summary>
        /// Function triggered by Game manager when the simulation is run
        /// </summary>
        public void TriggerAction()
        {
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
            if (IsGoodGuy) //if, at its death, the green guys is STILL considered the good guy by the sign => we fail.
            {
                GameManager.Instance.TriggerLevelFailure(); //Raises a level failure to the game Manager so that it can act upon it
            }
            else
            {
                GameManager.Instance.TriggerLevelSuccess();
            }
            Destroy(gameObject);
        }

        private void OnGameEventChangeWinConditionReceived(GameEventType arg)
        {
            Debug.Log("[GOOD GUY] : Received event with arg : " + arg);
            IsGoodGuy = arg == GameEventType.ChargeWinConditionSuccess ? false : true;
            Debug.Log("[GOOD GUY] : Changed IsGoodGuy bool to : "+IsGoodGuy);
        }

    }
}
