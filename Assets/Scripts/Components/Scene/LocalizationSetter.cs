using System;
using Fungus;
using ScriptableObjects.Scenes;
using UnityEngine;

public class LocalizationSetter : MonoBehaviour
{
    [SerializeField] private Var LocalizationHolder;
    private Localization m_localization;

    private void Start()
    {
        m_localization = GetComponent<Localization>();

        var activeLanguage = (string) LocalizationHolder.GetValue();
        
        Debug.Log(activeLanguage);
        
        m_localization.SetActiveLanguage(activeLanguage);
    }
}
