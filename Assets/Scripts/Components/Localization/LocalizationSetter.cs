using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationSetter : MonoBehaviour
{
    [SerializeField] private Var LocalizationHolder;
    private Localization m_localization;

    private static readonly Dictionary<string, int> LocalizationMap = new Dictionary<string, int>
    {
        {"Standard", 0},
        {"ENG", 0},
        {"RU", 1}
    };

    private void Start()
    {
        m_localization = GetComponent<Localization>();

        var activeLanguage = (string) LocalizationHolder.GetValue();

        m_localization.SetActiveLanguage(activeLanguage);
        
        StartCoroutine(SetLanguageUI(activeLanguage));
    }
    
    public IEnumerator SetLanguageUI(string lang) 
    {
        // Wait for the localization system to initialize, loading Locales, preloading, etc.
        yield return LocalizationSettings.InitializationOperation;

        // This variable selects the language.
        // For example, if in the table your first language is English then 0 = English.
        // If the second language in the table is Russian then 1 = Russian etc.
        Debug.Log(lang);
        int i = LocalizationMap[lang];

        // This part changes the language
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];
    }
    
}
