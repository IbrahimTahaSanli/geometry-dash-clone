using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicUIButton : MonoBehaviour
{
    [SerializeField] private string musicOnText;
    [SerializeField] private string musicOffText;

    [SerializeField] private TMPro.TMP_Text musicText;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    private void SetText()
    {
        if (ConfigController.Instance.isMusicOn)
            musicText.text = musicOnText;
        else
            musicText.text = musicOffText;
    }

    public void ToggleMusic()
    {
        ConfigController.Instance.SetMusic(!ConfigController.Instance.isMusicOn);
        SetText();
    }
}
