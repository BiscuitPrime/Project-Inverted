using Inverted.Achievements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Levels
{
    /// <summary>
    /// Container of a level's data
    /// </summary>
    [CreateAssetMenu(fileName = "LevelDataAsset", menuName = "ScriptableObjects/LevelDataAsset")]
    public class LevelDataAsset : ScriptableObject
    {
        [SerializeField] public string LevelID;
        [SerializeField] public string NextLevelID;
        [SerializeField] public bool LevelIsSimulated;
        [field: SerializeField] public AchievementRessource AchievementRessource { get; private set; }
    }
}
