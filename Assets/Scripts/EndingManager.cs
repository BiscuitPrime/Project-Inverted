using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Levels
{
    public class EndingManager : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.TriggerEnding();
        }
    }
}
