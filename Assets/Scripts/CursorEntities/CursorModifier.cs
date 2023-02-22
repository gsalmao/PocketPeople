using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PocketPeople.CursorEntities
{
    /// <summary>
    /// Base class to modify the mouse cursor.
    /// </summary>
    public class CursorModifier : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ICursorCallbacks
    {
        private bool isActive = false;

        public event Action OnPointerEnterCallback = delegate { };
        public event Action OnPointerDownCallback = delegate{ };
        public event Action OnPointerExitCallback = delegate{ };
        public event Action OnPointerUpCallback = delegate{ };

        public bool IsActive
        {
            get => isActive;

            set
            {
                if (pointeOverThis)
                    CursorController.SetCursor(CursorType.Idle);
                isActive = value;
            }
        }

        private bool pointeOverThis = false;

        private void OnDisable() => CursorController.SetCursor(CursorType.Idle);

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!IsActive)
                return;

            pointeOverThis = true;
            CursorController.SetCursor(CursorType.Hover);
            OnPointerEnterCallback();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!IsActive)
                return;

            CursorController.SetCursor(CursorType.Pressing);
            OnPointerDownCallback();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!IsActive)
                return;

            pointeOverThis = false;
            CursorController.SetCursor(CursorType.Idle);
            OnPointerExitCallback();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!IsActive)
                return;

            if (pointeOverThis)
                CursorController.SetCursor(CursorType.Hover);
            else
                CursorController.SetCursor(CursorType.Idle);
            OnPointerUpCallback();
        }
    }
}
