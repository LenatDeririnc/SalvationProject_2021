using Helpers;
using UnityEngine;

namespace Managers.Player
{
    public static class InputManager
    {
        private static float m_mouseSensivity = 1;
        private static float m_gamepadSensivity = 200;
        private static float m_gamepadDeadzone = 0.19f;
        
        public static Vector2 MovementAxis()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public static Vector2 LookAxis()
        {
            var mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            var gamepadInput = new Vector2(Input.GetAxis("Gamepad X"), Input.GetAxis("Gamepad Y"));

            var mouseInputResult = mouseInput * m_mouseSensivity;
            Vector2 gamepadInputResult = Vector2Helper.Vector2Pow(gamepadInput, 3) * m_gamepadSensivity * Time.deltaTime;

            if (gamepadInput.magnitude < m_gamepadDeadzone)
                gamepadInputResult = Vector2.zero;

            return mouseInputResult + gamepadInputResult;
        }

        public static bool PauseButton()
        {
            return Input.GetButtonDown("ExitButton");
        }
    }
}