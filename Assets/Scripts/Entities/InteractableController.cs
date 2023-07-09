using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Entities
{
    /// <summary>
    /// Script used by the elements that can be moved and controlled through the player's mouse.
    /// </summary>
    public class InteractableController : MonoBehaviour
    {
        private Vector3 _startingPosition;
        private Vector3 _mouseOffset;
        private float _mouseZCoordinate;

        private void Awake()
        {
            _startingPosition = transform.position;
        }

        /// <summary>
        /// Function that will reset the object to its starting spawn (alongside its speed)
        /// </summary>
        public void ResetSpawn()
        {
            transform.position = _startingPosition;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        private void OnMouseDown()
        {
            _mouseZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            _mouseOffset = gameObject.transform.position - GetMousePosition();
        }

        /// <summary>
        /// Function that returns the position of the object in the world dependent on the mouse
        /// </summary>
        /// <returns>A vector3 containing the position of the object dependent on the mouse's position on the screen</returns>
        private Vector3 GetMousePosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _mouseZCoordinate;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }

        private void OnMouseDrag()
        {
            transform.position = GetMousePosition() + _mouseOffset;
        }
    }
}
