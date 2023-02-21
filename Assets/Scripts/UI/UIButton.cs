using UnityEngine;
using PocketPeople.CursorEntities;

namespace PocketPeople.UI
{
    public class UIButton : MonoBehaviour, ICursorModifier
    {
        private bool pointeOverThis = false;

        public void OnCursorEnter()
        {
            pointeOverThis = true;
            CursorController.SetCursor(CursorController.CursorType.Hover);
        }

        public void OnCursorExit()
        {
            pointeOverThis = false;
            CursorController.SetCursor(CursorController.CursorType.Idle);
        }

        public void OnPointerDown() =>CursorController.SetCursor(CursorController.CursorType.Pressing);
        public void OnPointerUp()
        {
            if(pointeOverThis)
                CursorController.SetCursor(CursorController.CursorType.Hover);
            else
                CursorController.SetCursor(CursorController.CursorType.Idle);
        }

        private void OnDisable()
        {
            if(pointeOverThis)
                CursorController.SetCursor(CursorController.CursorType.Idle);
            pointeOverThis = false;
        }

    }
}
