using Inverted.Achievements;
using Inverted.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace Inverted.UI
{
    public struct LevelAssetDataAggregator
    {
        public LevelDataAsset LevelDataAsset;
        public GameObject UIAchivementAsset;
    }
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
        [SerializeField] private GameObject _endLevelSuccessUI;
        [Header("IN GAME UI")]
        [SerializeField] private GameObject _inGameUI;
        [SerializeField] private GameObject _achievementPopupUI;
        [Header("MAIN MENU UI")]
        [SerializeField] private GameObject _mainMenuUI;
        [SerializeField] private GameObject _quitButton;
        [Header("ACHIEVEMENT MENU UI")]
        [SerializeField] private GameObject _achievementMenuUI;
        [SerializeField] private GameObject _achAsset1;
        [SerializeField] private LevelDataAsset _level1;
        [SerializeField] private GameObject _achAsset2;
        [SerializeField] private LevelDataAsset _level2;
        [SerializeField] private GameObject _achAsset3;
        [SerializeField] private LevelDataAsset _level3;
        [SerializeField] private GameObject _achAsset4;
        [SerializeField] private LevelDataAsset _level4;
        [SerializeField] private GameObject _achAsset5;
        [SerializeField] private LevelDataAsset _level5;
        [SerializeField] private GameObject _achAsset6;
        [SerializeField] private LevelDataAsset _level6;
        [Header("CREDITS MENU UI")]
        [SerializeField] private GameObject _creditsMenuUI;
        #endregion

        private PopupController _popupController;
        private Dictionary<string, LevelAssetDataAggregator> _levelAssets;

        private void Start() //Should only be called at the start of the main menu, since the UI is dontdestroyonload it will allow us to have full control on what is displayed at all times
        {
            _endLevelUI.SetActive(false);
            _endLevelSuccessUI.SetActive(false);
            _inGameUI.SetActive(false);
            _achievementMenuUI.SetActive(false);
            _creditsMenuUI.SetActive(false);
            _mainMenuUI.SetActive(true);
            _popupController = _achievementPopupUI.GetComponent<PopupController>();
            if(Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _quitButton.SetActive(false);
            }
            _levelAssets = new Dictionary<string, LevelAssetDataAggregator>
            {
                { _level1.LevelID, new LevelAssetDataAggregator(){ LevelDataAsset=_level1,UIAchivementAsset=_achAsset1 } },
                { _level2.LevelID, new LevelAssetDataAggregator(){ LevelDataAsset=_level2,UIAchivementAsset=_achAsset2 } },
                { _level3.LevelID, new LevelAssetDataAggregator(){ LevelDataAsset=_level3,UIAchivementAsset=_achAsset3 } },
                { _level4.LevelID, new LevelAssetDataAggregator(){ LevelDataAsset=_level4,UIAchivementAsset=_achAsset4 } },
                { _level5.LevelID, new LevelAssetDataAggregator(){ LevelDataAsset=_level5,UIAchivementAsset=_achAsset5 } },
                { _level6.LevelID, new LevelAssetDataAggregator(){ LevelDataAsset=_level6,UIAchivementAsset=_achAsset6 } }
            };
            HideAllAchievements();
        }

        /// <summary>
        /// Function called upon the failure of the level, displays the end level screen along the achievements
        /// </summary>
        public void OnLevelFailure(AchievementRessource achievementRessource=null)
        {
            _endLevelUI.SetActive(true); //TODO : SHOULD BE A LITTLE MORE ANIMATED
            _achievementPopupUI.SetActive(true);
            if (achievementRessource != null)
            {
                _popupController.TriggerPopup(achievementRessource);
            }
            else
            {
                _achievementPopupUI.SetActive(false);
            }
        }

        /// <summary>
        /// Function called upon the success of the level, only displays the end level screen
        /// </summary>
        public void OnLevelSuccess()
        {
            _endLevelSuccessUI.SetActive(true);
            _achievementPopupUI.SetActive(false);
        }

        private void OnLevelWasLoaded()
        {
            _inGameUI.SetActive(true);
        }

        private void HideAllAchievements()
        {
            foreach (var levelAssetData in _levelAssets.Keys)
            {
                _levelAssets[levelAssetData].UIAchivementAsset.SetActive(false);
            }
        }

        #region BUTTON FUNCTIONS
        public void OnStartButtonPressed()
        {
            Debug.Log("[UI] : Start Button pressed");
            //load the loading screen
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
            _endLevelUI.SetActive(false);
            _endLevelSuccessUI.SetActive(false);
            _inGameUI.SetActive(false);
            HideAllAchievements();
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
            foreach(var levelAssetData in _levelAssets.Keys)
            {
                if (PlayerPrefs.HasKey(_levelAssets[levelAssetData].LevelDataAsset.LevelID))
                {
                    _levelAssets[levelAssetData].UIAchivementAsset.SetActive(true);
                    _levelAssets[levelAssetData].UIAchivementAsset.GetComponent<PopupController>().TriggerAchievementDisplay(_levelAssets[levelAssetData].LevelDataAsset.AchievementRessource);
                }
            }
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
            _endLevelSuccessUI.SetActive(false);
            HideAllAchievements();
            _inGameUI.SetActive(true);
        }

        public void OnReturnToMainMenuButtonPressed()
        {
            Debug.Log("[UI] : Menu Button pressed");
            _endLevelUI.SetActive(false);
            _endLevelSuccessUI.SetActive(false);
            _inGameUI.SetActive(false);
            _achievementMenuUI.SetActive(false);
            _creditsMenuUI.SetActive(false);
            HideAllAchievements();
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
