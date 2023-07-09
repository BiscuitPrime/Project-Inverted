using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Inverted.Audio
{
    /// <summary>
    /// Script that will control the audio source associated with the tutorial voice
    /// </summary>
    public class VoicesController : MonoBehaviour
    {
        #region SINGLETON DESIGN PATTERN
        private static VoicesController _instance;
        public static VoicesController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VoicesController();
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

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            Assert.IsNotNull(_audioSource);
        }

        /// <summary>
        /// Function that will trigger the voiceline, with the clip passed by the caller, GameManager
        /// </summary>
        /// <param name="clip"></param>
        public void TriggerVoiceLine(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}
