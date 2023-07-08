using Inverted.Levels;
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
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region UI VARIABLES
        [Header("END LEVEL UI")]
        [SerializeField] private GameObject _endLevelUI;
        [Header("IN GAME UI")]
        [SerializeField] private GameObject _inGameUI;
        [SerializeField] private GameObject _achievementPopupUI;
        [Header("MAIN MENU UI")]
        [SerializeField] private GameObject _mainMenuUI;
        [SerializeField] private GameObject _quitButton;
        [Header("ACHIEVEMENT MENU UI")]
        [SerializeField] private GameObject _achievementMenuUI;
        [Header("CREDITS MENU UI")]
        [SerializeField] private GameObject _creditsMenuUI;
        #endregion

        private void Start() //Should only be called at the start of the main menu, since the UI is dontdestroyonload it will allow us to have full control on what is displayed at all times
        {
            _endLevelUI.SetActive(false);
            _inGameUI.SetActive(false);
            _achievementMenuUI.SetActive(false);
            _creditsMenuUI.SetActive(false);
            _mainMenuUI.SetActive(true);
            if(Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _quitButton.SetActive(false);
            }
        }

        /// <summary>
        /// Function called upon the failure of the level, displays the end level screen along the achievements
        /// </summary>
        public void OnLevelFailure()
        {
            _endLevelUI.SetActive(true); //TODO : SHOULD BE A LITTLE MORE ANIMATED
            //_achievementPopupUI.SetActive(true);
        }

        /// <summary>
        /// Function called upon the success of the level, only displays the end level screen
        /// </summary>
        public void OnLevelSuccess()
        {
            _endLevelUI.SetActive(true);
        }

        private void OnLevelWasLoaded()
        {
            _inGameUI.SetActive(true);
        }


        #region BUTTON FUNCTIONS
        public void OnStartButtonPressed(string nextLevelName)
        {
            Debug.Log("[UI] : Start Button pressed");
            //load the loading screen
            SceneManager.LoadSceneAsync(nextLevelName);
            _endLevelUI.SetActive(false);
            _inGameUI.SetActive(false);
            _achievementMenuUI.SetActive(false);
            _creditsMenuUI.SetActive(false);
            _mainMenuUI.SetActive(false);
        }

        public void OnQuitButtonPressed()
        {
            Debug.Log("[UI] : Quit Button pressed");
            Application.Quit();
        }

        public void OnAchievementButtonPressed()
        {
            Debug.Log("[UI] : Achievement Button pressed");
            _mainMenuUI.SetActive(false);
            _achievementMenuUI.SetActive(true);
        }

        public void OnCreditsButtonPressed()
        {
            Debug.Log("[UI] : Credits Button pressed");
            _mainMenuUI.SetActive(false);
            _creditsMenuUI.SetActive(true);
        }

        public void OnRestartButtonPressed()
        {
            Debug.Log("[UI] : Restart Button pressed");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            _endLevelUI.SetActive(false);
            _inGameUI.SetActive(true);
        }

        public void OnReturnToMainMenuButtonPressed()
        {
            Debug.Log("[UI] : Menu Button pressed");
            _endLevelUI.SetActive(false);
            _inGameUI.SetActive(false);
            _achievementMenuUI.SetActive(false);
            _creditsMenuUI.SetActive(false);
            _mainMenuUI.SetActive(true);
        }

        public void OnTriggerSimulationButton()
        {
            _inGameUI.SetActive(false);
            GameManager.Instance.TriggerSimulation();
        }
        #endregion
    }
}
