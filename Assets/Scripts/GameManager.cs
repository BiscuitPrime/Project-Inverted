using Inverted.Actors;
using Inverted.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Levels
{
    public class GameManager : MonoBehaviour
    {
        #region SINGLETON DESIGN PATTERN
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }
        private void Awake()
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        #endregion

        [Header("DEBUG")]
        [SerializeField] private bool TriggerSimulation = false;

        private void Update()
        {
            if (TriggerSimulation) //DEBUG, TO BE DELETED
            {
                TriggerSimulation = false;
                GameObject[] activableGameObjects = GameObject.FindGameObjectsWithTag("Actor");
                foreach(GameObject gameObject in activableGameObjects)
                {
                    if (gameObject != null)
                    {
                        gameObject.GetComponent<IActorManager>().TriggerAction();
                    }
                }
            }
        }

        /// <summary>
        /// Function called by the loading of a level, that will trigger the init of the level (voice acting etc)
        /// </summary>
        private void OnLevelWasLoaded(int level)
        {
            Debug.Log("[GAME MANAGER] : Level was loaded");
        }

        /// <summary>
        /// Function called by elements of the game upon failure of the level that results in the display of the "failed level" UI + achievement
        /// </summary>
        public void TriggerLevelFailure()
        {
            Debug.Log("[GAME MANAGER] : Triggered Level Failure");
            //TODO : TRIGGER VOICE ACTING
            UIController.Instance.OnLevelFailure();
        }

        public void TriggerLevelSuccess()
        {
            Debug.Log("[GAME MANAGER] : Triggered Level Success");
            UIController.Instance.OnLevelSuccess();
        }
    }
}
