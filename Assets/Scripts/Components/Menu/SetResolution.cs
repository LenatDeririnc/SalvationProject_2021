using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Components.Menu
{
    [System.Serializable]
    public struct ResolutionSetting
    {
        public int width;
        public int height;

        public ResolutionSetting(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override string ToString()
        {
            return $"{width}x{height}";
        }
    }
    
    public class SetResolution : MonoBehaviour
    {
        private static string PlayerPrefsSelectedScreenKey = "SelectedScreen";
        
        [SerializeField] private ResolutionSetting[] Resolutions;
        [SerializeField] private TMP_Dropdown DropdownMenu;

        private void Start()
        {
            if (DropdownMenu == null)
                return;

            foreach (var setting in Resolutions)
            {
                var textResolution = setting.ToString();
                DropdownMenu.options.Add(new TMP_Dropdown.OptionData(textResolution));
            }

            if (!PlayerPrefs.HasKey(PlayerPrefsSelectedScreenKey)) return;
            
            var currentResolution = PlayerPrefs.GetInt(PlayerPrefsSelectedScreenKey);
            DropdownMenu.SetValueWithoutNotify(currentResolution);
        }

        public void Set(ResolutionSetting setting)
        {
            if (!Resolutions.Contains(setting))
                return;
            
            Screen.SetResolution(setting.width, setting.height, Screen.fullScreen);
        }

        public void Set(int id)
        {
            if (id > Resolutions.Length)
                return;

            var setting = Resolutions[id];
            Screen.SetResolution(setting.width, setting.height, Screen.fullScreen);
            PlayerPrefs.SetInt("SelectedScreen", id);
        }
    }
}