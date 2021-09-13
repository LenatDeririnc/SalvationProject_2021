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

        private static Vector2 Vector2Pow(Vector2 vector2, int pow)
        {
            Vector2 resultVector = vector2;
            
            for (int i = 1; i < pow; ++i)
            {
                resultVector *= vector2;
            }

            return resultVector;
        }

        public static Vector2 LookAxis()
        {
            var mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            var gamepadInput = new Vector2(Input.GetAxis("Gamepad X"), Input.GetAxis("Gamepad Y"));

            var mouseInputResult = mouseInput * m_mouseSensivity;
            var gamepadInputResult = Vector2Pow(gamepadInput, 3) * m_gamepadSensivity * Time.deltaTime;

            if (gamepadInput.magnitude < m_gamepadDeadzone)
                gamepadInputResult = Vector2.zero;

            return mouseInputResult + gamepadInputResult;
        }
    }
}