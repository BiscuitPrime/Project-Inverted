using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Audio
{
    /// <summary>
    /// Struct used to create the data structure used for start-of-level audioclips
    /// </summary>
    [System.Serializable]
    public struct StartingAudioClips
    {
        public int LevelID;
        public AudioClip AudioClip;
    }
    /// <summary>
    /// Scriptable object containing all the voices audio clips
    /// </summary>
    [CreateAssetMenu(fileName ="VoicesDataAsset",menuName ="ScriptableObjects/VoicesDataAsset")]
    public class VoicesDataAsset : ScriptableObject
    {
        public Dictionary<int,AudioClip> StartingAudioClips { get; private set; }
        public AudioClip[] RandomEndingAudioClips => _randomEndingAudioClips;
        [field: SerializeField, InspectorName("Starting Audio Clips")] private StartingAudioClips[] _startingAudioClips { get; set; }
        [field: SerializeField, InspectorName("Random Ending Audio Clips")] private AudioClip[] _randomEndingAudioClips { get; set; }

        public void SetUpDictionnary()
        {
            StartingAudioClips = new Dictionary<int, AudioClip>();
            foreach(var audioClipStruct in _startingAudioClips)
            {
                StartingAudioClips.Add(audioClipStruct.LevelID,audioClipStruct.AudioClip);
            }
        }

    }
}
