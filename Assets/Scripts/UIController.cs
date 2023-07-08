using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Inverted.UI
{
    public class UIController : MonoBehaviour
    {
        #region SINGLETON DESIGN PATTERN
        private static UIController _instance;
        public static UIController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UIController();
                }
                return _instance;
            }
        }
        private void Awake()
        {
            _instance = this;
        }
        #endregion

        #region UI VARIABLES
        [SerializeField] private GameObject _endLevelUI;
        //[SerializeField] private GameObject _achievementUI;
        #endregion

        private void Start()
        {
            _endLevelUI.SetActive(false);
            //_achievementUI.SetActive(false);
        }

        /// <summary>
        /// Function called upon the failure of the level, displays the end level screen along the achievements
        /// </summary>
        public void OnLevelFailure()
        {
            _endLevelUI.SetActive(true); //TODO : SHOULD BE A LITTLE MORE ANIMATED
            //_achievementUI.SetActive(true);
        }

        /// <summary>
        /// Function called upon the success of the level, only displays the end level screen
        /// </summary>
        public void OnLevelSuccess()
        {
            _endLevelUI.SetActive(true);
        }


        #region BUTTON FUNCTIONS
        public void OnStartButtonPressed()
        {
            Debug.Log("[UI] : Start Button pressed");
        }

        public void OnRestartButtonPressed()
        {
            Debug.Log("[UI] : Restart Button pressed");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

        public void OnMenuButtonPressed()
        {
            Debug.Log("[UI] : Menu Button pressed");
        }
        #endregion
    }
}
