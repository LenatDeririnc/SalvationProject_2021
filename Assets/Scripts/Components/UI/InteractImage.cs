using System;
using System.ComponentModel;
using Fungus;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Components.UI
{
    public class InteractImage : MonoBehaviour
    {
        private Transform m_transform;
        private static UnityAction<bool> m_showAction;

        [SerializeField] private Transform showPosition;
        [SerializeField] private Transform hidePosition;

        [SerializeField] private float inputXSensitivity;
        [SerializeField] private float inputYSensitivity;

        // Скорость анимации движения мыши
        [SerializeField] private float inputXAlpha;
        [SerializeField] private float inputYAlpha;
        
        // Скорость анимации появления интеракта
        [SerializeField] private float animationXAlpha;
        [SerializeField] private float animationYAlpha;
        
        [SerializeField] float clampValueX; 
        [SerializeField] float clampValueY;
        
        private float startPositionX;
        private float startPositionY;

        private float inputX;
        private float inputY;
        
        private float currentX;
        private float currentY;

        private int windowResolutionX;
        private int windowResolutionY;

        public static UnityAction<bool> ShowAction() => m_showAction;

        private void onInteract(bool state)
        {
            currentY = state ? showPosition.position.y : hidePosition.position.y;
        }

        private void Awake()
        {
            m_showAction = null;
            m_showAction += onInteract;
            
            m_transform = transform;

            var position = m_transform.position;
            startPositionX = position.x;
            startPositionY = hidePosition.position.y;

            currentX = startPositionX;
            currentY = hidePosition.position.y;

            position = new Vector3(startPositionX, startPositionY);
            m_transform.position = position;
        }
        
        private void UpdateAnimation()
        {
            var position = m_transform.position;
            var x = position.x;
            var y = position.y;

            // Анимация рук при движении мыши
            inputX = Mathf.Lerp(inputX, -Input.GetAxisRaw("Mouse X") * inputXSensitivity, inputXAlpha);
            inputY = Mathf.Lerp(inputY, -Input.GetAxisRaw("Mouse Y") * inputYSensitivity, inputYAlpha);

            // Анимация интеракта
            x = Mathf.Lerp(x, currentX, animationXAlpha) + inputX;
            y = Mathf.Lerp(y, currentY, animationYAlpha) + inputY;

            // Ограничение позиции руки, чтобы игроку не было видно нижней границы картинки
            x = Mathf.Clamp(x, currentX -clampValueX, currentX +clampValueX);
            y = Mathf.Clamp(y, hidePosition.position.y -clampValueY, showPosition.position.y +clampValueY);

            var result = new Vector2(x, y);

            position = result;
            m_transform.position = position;
        }
        
        private void FixedUpdate()
        {
            UpdateAnimation();
        }
    }
}
