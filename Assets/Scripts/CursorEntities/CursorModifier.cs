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
        public event Action OnPointerEnterCallback = delegate { };
        public event Action OnPointerDownCallback = delegate{ };
        public event Action OnPointerExitCallback = delegate{ };
        public event Action OnPointerUpCallback = delegate{ };
        public event Action OnClickCallback = delegate{ };

        private bool isActive = true;

        public bool IsActive
        {
            get => isActive;

            set
            {
                if(pointerOverThis)
                {
                    if(value == true) //Hey, I could use if(value), but this way I read it easier.(ﾉ◕ヮ◕)ﾉ*:・ﾟ✧
                        CursorController.SetCursor(CursorType.Hover);
                    else
                        CursorController.SetCursor(CursorType.Idle);
                }
                
                isActive = value;
            }
        }

        private bool pointerOverThis = false;

        protected virtual void OnEnable() { }
        protected virtual void OnDisable() => CursorController.SetCursor(CursorType.Idle);

        public void OnPointerEnter(PointerEventData eventData)
        {
            pointerOverThis = true;

            if (!IsActive)
                return;

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
            pointerOverThis = false;

            if (!IsActive)
                return;

            CursorController.SetCursor(CursorType.Idle);
            OnPointerExitCallback();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!IsActive)
                return;

            if (pointerOverThis)
            {
                CursorController.SetCursor(CursorType.Hover);
                OnClickCallback();
            }
            else
                CursorController.SetCursor(CursorType.Idle);
            OnPointerUpCallback();
        }
    }
}
