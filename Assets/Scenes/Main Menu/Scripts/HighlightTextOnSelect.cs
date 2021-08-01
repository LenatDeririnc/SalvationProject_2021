using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Scenes.Main_Menu.Scripts
{
    public class HighlightTextOnSelect : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private TMP_Text text;

        public void OnPointerEnter(PointerEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}
