using Inverted.Achievements;
using Inverted.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Levels
{
    /// <summary>
    /// Script that will act as the level's singular storage of data, that acts as the container/access point of all the necessary data of the level needed by GameManager and other scripts, and can be called by every other script of the scene
    /// </summary>
    public class LevelData : MonoBehaviour
    {
        #region SINGLETON DESIGN PATTERN
        private static LevelData _instance;
        public static LevelData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LevelData();
                }
                return _instance;
            }
        }
        private void Awake()
        {
            _instance = this;
        }
        #endregion

        [SerializeField] public LevelDataAsset LevelDataAsset;
    }
}
