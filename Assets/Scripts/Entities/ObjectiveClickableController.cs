using Inverted.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Entities
{
    /// <summary>
    /// Script used by clickable objects that relate to the objective and trigger failure or success.
    /// </summary>
    public class ObjectiveClickableController : ClickableController
    {
        [SerializeField, InspectorName("WinTarget")] private bool _isTargetWinCondition = false;

        protected override void ObjectClickedTrigger()
        {
            Debug.Log("[ENTITY] : Object " + gameObject + " clicked");
            if (_isTargetWinCondition) //if the objective-categorized object is clicked, and is the objective, then we trigger success
            {
                GameManager.Instance.TriggerLevelSuccess();
            }
            else //if not the objective, we trigger failure
            {
                GameManager.Instance.TriggerLevelFailure();
            }
        }
    }
}
