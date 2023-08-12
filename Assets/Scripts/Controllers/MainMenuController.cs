using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartLevel1()
    {
        ConfigController.Instance.ResetDeathCounter();
        SceneManager.LoadScene("Level1");
    }
}
