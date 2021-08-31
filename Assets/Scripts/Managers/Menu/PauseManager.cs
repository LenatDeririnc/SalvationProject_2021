using System;
using UnityEngine;

namespace Managers.Menu
{
    public static class PauseManager
    {
        // public static bool isGamePaused;
        //
        // public static Action<bool> onGamePaused;
        // public static bool isCanSetPause = false; // решили отказаться от возможности паузы
        //
        // public static void Init()
        // {
        //     onGamePaused = null;
        // }
        //
        // public static void PauseGame()
        // {
        //     if (!isCanSetPause)
        //         return;
        //
        //     isGamePaused = true;
        //     
        //     Time.timeScale = 0;
        //     onGamePaused?.Invoke(true);
        //     Debug.Log("pause on");
        // }
        //
        // public static void ResumeGame()
        // {
        //     if (!isCanSetPause)
        //         return;
        //     
        //     isGamePaused = false;
        //     
        //     Time.timeScale = 1;
        //     onGamePaused?.Invoke(false);
        //     Debug.Log("pause off");
        // }
    }
}