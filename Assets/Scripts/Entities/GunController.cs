using Inverted.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Entities
{
    /// <summary>
    /// Simple script used by the gun : if the player enters the range, it fires and kills it.
    /// </summary>
    public class GunController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("GUN : TRIGGER ENTERED");
            FireGun();
            other.gameObject.GetComponent<GoodGuyController>().TriggerDeath();
        }

        private void FireGun()
        {
            Debug.Log("GUN : Firing");
            //TODO : implement proper firing with bullet and all
        }
    }
}
