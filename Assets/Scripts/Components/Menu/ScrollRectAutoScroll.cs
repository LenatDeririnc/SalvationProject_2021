using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Components.Menu
{
    public class ScrollRectAutoScroll : MonoBehaviour {
 
        List<Selectable> selectables = new List<Selectable>();
 
        int elementCount;
 
        #region Properties
        ScrollRect ScrollRectComponent { get; set; }
        #endregion
 
        void OnEnable() {
            if(ScrollRectComponent) {
                ScrollRectComponent.content.GetComponentsInChildren(selectables);
                elementCount = selectables.Count;
            }
        }
 
        void Awake() {
            ScrollRectComponent = GetComponent<ScrollRect>();
        }
 
        void Start() {
            ScrollRectComponent.content.GetComponentsInChildren(selectables);
            elementCount = selectables.Count;
        }
 
        void Update() {
            if(elementCount > 0)
                if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {
                    int selectedIndex = -1;
                    Selectable selectedElement = EventSystem.current.currentSelectedGameObject ? EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>() : null;
 
                    if(selectedElement)
                        selectedIndex = selectables.IndexOf(selectedElement);
 
                    if(selectedIndex > -1)
                        ScrollRectComponent.verticalNormalizedPosition = 1 - (selectedIndex / ((float)elementCount - 1));
                }
        }
    }
}