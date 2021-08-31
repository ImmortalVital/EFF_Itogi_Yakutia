using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : MonoBehaviour
{
    public enum Language { RU, EN }
    public static Language currentLanguage = Language.RU;
    public bool Toggled = false;

    private void Start()
    {
        SetLanguage(Language.RU);
    }

    public void ToggleLanguage()
    {
        currentLanguage = currentLanguage == Language.RU ? Language.EN : Language.RU;

        SetLanguage(currentLanguage);
    }

    public void SetLanguage(Language targetLanguage)
    {
        Localizable[] localizableObjects = FindObjectsOfType<Localizable>();

        foreach (Localizable localizableObject in localizableObjects)
            localizableObject.Localize(targetLanguage);

        Toggled = true;
    }

    public void SetToggle()
    {
        Toggled = false;
    }
}
