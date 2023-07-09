using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Inverted.Entities
{
    /// <summary>
    /// Script used by clickable objects that react upon a player's click.
    /// </summary>
    public class ClickableController : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        protected void OnMouseDown()
        {
            ObjectClickedTrigger();
        }

        /// <summary>
        /// Function triggered upon click. For non-objective clickable objects, we just play a sound.
        /// </summary>
        protected virtual void ObjectClickedTrigger()
        {
            Debug.Log("[ENTITY] : Object " + gameObject + " clicked");
            _audioSource?.Play();
        }
    }
}
