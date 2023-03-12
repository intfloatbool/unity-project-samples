using System;
using UnityEngine;

namespace Common.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class ClickableCollider : MonoBehaviour
    {
        public event Action<ClickableCollider> OnClick; 

        private void OnMouseDown()
        {
            OnClick?.Invoke(this);
        }
    }
}