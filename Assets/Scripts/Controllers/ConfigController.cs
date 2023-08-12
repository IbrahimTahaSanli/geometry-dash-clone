using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    [HideInInspector] public static ConfigController Instance
    {
        get;
        private set;
    }


    [SerializeField] private string musicPrefKey;
    [HideInInspector] public bool isMusicOn;

    [HideInInspector] public int deathCounter {
        get;
        private set;
    } = 0;

    public void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(this);
        }

        Instance = this;
        Object.DontDestroyOnLoad(this);
        isMusicOn = getMusicOn();
    }

    private bool getMusicOn()
    {
        return PlayerPrefs.GetInt(musicPrefKey, 1) == 1;
    }

    public void SetMusic(bool isOn)
    {
        PlayerPrefs.SetInt(musicPrefKey, isOn ? 1 : 0);
        isMusicOn = isOn;
    }

    public void ResetDeathCounter()
    {
        deathCounter = 0;
    }

    public void IncDeathCounter()
    {
        deathCounter++;
    }
}
