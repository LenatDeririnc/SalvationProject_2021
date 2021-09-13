using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Components.Menu
{
    public class SetMonitor : MonoBehaviour
    {
        private static string PlayerPrefsSelectedDisplayKey = "UnitySelectMonitor";
        
        [SerializeField] private TMP_Dropdown DropdownMenu;

        private DisplayChanger DisplayChanger;
        
        private void Start()
        {
            DisplayChanger = GetComponent<DisplayChanger>();
            
            if (DropdownMenu == null)
                return;

            for (int i = 1; i <= Display.displays.Length; ++i)
            {
                var option = new TMP_Dropdown.OptionData(i.ToString());
                DropdownMenu.options.Add(option);
                DropdownMenu.SetValueWithoutNotify(i - 1);
            }

            if (!PlayerPrefs.HasKey(PlayerPrefsSelectedDisplayKey))
            {
                Set(0);
                DropdownMenu.SetValueWithoutNotify(0);
            }
            else
            {
                var display = PlayerPrefs.GetInt(PlayerPrefsSelectedDisplayKey);
                Set(display);
                DropdownMenu.SetValueWithoutNotify(display);
            }
        }

        public void Set(int id)
        {
            if (!Screen.fullScreen)
                return;
            
            if (id >= Display.displays.Length)
                return;
            
            PlayerPrefs.SetInt(PlayerPrefsSelectedDisplayKey, id);
            DisplayChanger.SetDisplay(id);
        }
    }
}