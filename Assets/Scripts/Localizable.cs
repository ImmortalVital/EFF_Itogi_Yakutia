using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Localizable : MonoBehaviour
{
    public string stringRu;
    public string stringEn;

    public Sprite textureRu;
    public Sprite textureEn;

    public void Localize(LanguageController.Language language)
    {
        Text text = GetComponent<Text>();
        Image image = GetComponent<Image>();

        if (text != null)
            text.text = language == LanguageController.Language.RU ? stringRu : stringEn;

        if (image != null)
            image.sprite = language == LanguageController.Language.RU ? textureRu : textureEn;
    }

    private void OnEnable()
    {
        Localize(LanguageController.currentLanguage);
    }
}
