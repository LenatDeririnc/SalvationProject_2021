using UnityEngine;
using UnityEngine.EventSystems;

namespace Thirdparty.Fungus.Scripts.Settings
{
    [AddComponentMenu("Event/PSXInput")]
    /// <summary>
    /// Класс для решения проблемы деселекта кнопок, если игрок нажимал ЛКМ по пустому месту
    /// </summary>
    public class PSXInput : StandaloneInputModule
    {

        protected PSXInput()
        {
        }
        
        protected override void ProcessMouseEvent(int id)
        {
            var mouseData = GetMousePointerEventData(id);
            var leftButtonData = mouseData.GetButtonState(PointerEventData.InputButton.Left).eventData;
        
            var focusData = leftButtonData.buttonData.pointerCurrentRaycast.gameObject;
            
            if (focusData == null)
                return;
            
            m_CurrentFocusedGameObject = focusData;
        
            // Process the first mouse button fully
            ProcessMousePress(leftButtonData);
            ProcessMove(leftButtonData.buttonData);
            ProcessDrag(leftButtonData.buttonData);
        
            // Now process right / middle clicks
            ProcessMousePress(mouseData.GetButtonState(PointerEventData.InputButton.Right).eventData);
            ProcessDrag(mouseData.GetButtonState(PointerEventData.InputButton.Right).eventData.buttonData);
            ProcessMousePress(mouseData.GetButtonState(PointerEventData.InputButton.Middle).eventData);
            ProcessDrag(mouseData.GetButtonState(PointerEventData.InputButton.Middle).eventData.buttonData);
        
            if (!Mathf.Approximately(leftButtonData.buttonData.scrollDelta.sqrMagnitude, 0.0f))
            {
                var scrollHandler = ExecuteEvents.GetEventHandler<IScrollHandler>(leftButtonData.buttonData.pointerCurrentRaycast.gameObject);
                ExecuteEvents.ExecuteHierarchy(scrollHandler, leftButtonData.buttonData, ExecuteEvents.scrollHandler);
            }
        }

        protected override void ProcessMove(PointerEventData pointerEvent)
        {
            var targetGO = (Cursor.lockState == CursorLockMode.Locked ? null : pointerEvent.pointerCurrentRaycast.gameObject);
            HandlePointerExitAndEnter(pointerEvent, targetGO);
            if (pointerEvent.hovered.Count > 0)
            {
                eventSystem.SetSelectedGameObject(targetGO, pointerEvent);
            }
        }
        
        protected override void DeselectIfSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent)
        {
            // деселектить не нужно, поэтому ничего не делаем в этом методе
        }
        
    }
}
