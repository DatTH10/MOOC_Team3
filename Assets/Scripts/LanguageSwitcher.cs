using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

public class LanguageSwitcher : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            ToggleLanguage();
        }
    }

    async void ToggleLanguage()
    {
        await LocalizationSettings.InitializationOperation.Task;

        var locales = LocalizationSettings.AvailableLocales.Locales;
        var current = LocalizationSettings.SelectedLocale;

        if (current == locales[0])
            LocalizationSettings.SelectedLocale = locales[1];
        else
            LocalizationSettings.SelectedLocale = locales[0];
    }
}
