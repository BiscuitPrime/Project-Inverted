using Inverted.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Debugging
{
    public class Debugger : MonoBehaviour
    {
        [Header("DEBUG BUTTONS")]
        [SerializeField] private bool _logAllPlayerPrefs = false;
        [SerializeField] private bool _resetAllPlayerPrefs = false;
        [Header("DEBUG VARIABLES")]
        [SerializeField] private LevelDataAsset[] _levelAssets;

        private void Awake() //we make sure the debugger is never considered for the builds
        {
            if(Application.isEditor)
            {
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
        private void Update()
        {
            if(_logAllPlayerPrefs)
            {
                _logAllPlayerPrefs = false;
                Debug.Log("[DEBUG] : Starting display of all player prefs");
                foreach (var levelAsset in _levelAssets)
                {
                    if (PlayerPrefs.HasKey(levelAsset.LevelID))
                    {
                        Debug.Log("[DEBUG] : Key : " + levelAsset.LevelID + " | Value : " + PlayerPrefs.GetInt(levelAsset.LevelID));
                    }
                }
            }
            if (_resetAllPlayerPrefs)
            {
                _resetAllPlayerPrefs = false;
                Debug.Log("[DEBUG] : Reseting all player prefs");
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
            }
        }
    }
}
