using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Audio
{
    /// <summary>
    /// Scriptable object containing all the voices audio clips
    /// </summary>
    [CreateAssetMenu(fileName ="VoicesDataAsset",menuName ="ScriptableObjects/VoicesDataAsset")]
    public class VoicesDataAsset : ScriptableObject
    {
        public AudioClip[] AudioClips => _audioClips;
        [field: SerializeField, InspectorName("Voices Audio Clips")] private AudioClip[] _audioClips { get; set; }
    }
}
