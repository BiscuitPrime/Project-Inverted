using Inverted.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Levels
{
    /// <summary>
    /// Script of the entity that will always restore an object above the ground to avoid losing it
    /// </summary>
    public class RespawnHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.GetComponent<InteractableController>() != null)
            {
                other.gameObject.GetComponent<InteractableController>().ResetSpawn();                
            }
        }
    }
}
