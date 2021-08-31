using Managers.Menu;
using UnityEngine;

namespace Components.Menu
{
    public class PauseControll : MonoBehaviour
    {
        // private bool isGamePaused = false;
        //
        // private void SetPauseState(bool state)
        // {
        //     isGamePaused = state;
        // }
        //
        // private void Awake()
        // {
        //     PauseManager.onGamePaused += SetPauseState;
        // }
        //
        // private bool ButtonDown() => Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.P);
        //
        // public void Update()
        // {
        //     if (!(ButtonDown() && PauseManager.isCanSetPause))
        //         return;
        //
        //     if (!isGamePaused)
        //         PauseManager.PauseGame();
        //     else
        //         PauseManager.ResumeGame();
        // }
    }
}