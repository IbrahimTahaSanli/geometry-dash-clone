using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounterText : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private string textForStart;
    // Start is called before the first frame update
    void Start()
    {
        if (ConfigController.Instance.deathCounter == 0)
            text.text = "";
        else
            text.text = textForStart + ConfigController.Instance.deathCounter;
    }
}
