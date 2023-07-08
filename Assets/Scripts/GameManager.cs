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

        private LevelDataAsset _currentLevelData;

        /// <summary>
        /// Function called by the loading of a level, that will trigger the init of the level (voice acting etc)
        /// </summary>
        private void OnLevelWasLoaded(int level)
        {
            Debug.Log("[GAME MANAGER] : Level was loaded");
            if(LevelData.Instance == null)
            {
                Debug.LogError("[GAME MANAGER] : Failed to find Level Data singleton in the scene");
            }
            _currentLevelData = LevelData.Instance.LevelDataAsset;
        }

        /// <summary>
        /// Function called by elements of the game upon failure of the level that results in the display of the "failed level" UI + achievement
        /// </summary>
        public void TriggerLevelFailure()
        {
            Debug.Log("[GAME MANAGER] : Triggered Level Failure");
            //TODO : TRIGGER VOICE ACTING
            if (!PlayerPrefs.HasKey(_currentLevelData.LevelID)) //if it's the first time that the player lost, we give achievement, otherwise we don't
            {
                Debug.Log("[GAME MANAGER] : CALLING ACHIEVEMENT");
                PlayerPrefs.SetInt(_currentLevelData.LevelID, 1);
                PlayerPrefs.Save();
                UIController.Instance.OnLevelFailure(_currentLevelData.AchievementRessource);
            }
            else
            {
                Debug.Log("[GAME MANAGER] : NOT CALLING ACHIEVEMENT");
                UIController.Instance.OnLevelFailure();
            }
        }

        /// <summary>
        /// Function called by elements of the game upon success of the level that results in the display of the "level success" UI + voice acting + changing level
        /// </summary>
        public void TriggerLevelSuccess()
        {
            Debug.Log("[GAME MANAGER] : Triggered Level Success");
            UIController.Instance.OnLevelSuccess();
        }

        /// <summary>
        /// Function called UI-side that will trigger the simulation if need be of the level
        /// </summary>
        public void TriggerSimulation()
        {
            Debug.Log("[GAME MANAGER] : Triggered Simulation");
            GameObject[] activableGameObjects = GameObject.FindGameObjectsWithTag("Actor");
            foreach (GameObject gameObject in activableGameObjects)
            {
                if (gameObject != null)
                {
                    gameObject.GetComponent<IActorManager>().TriggerAction();
                }
            }
        }
    }
}
