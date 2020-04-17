using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    public TextMeshProUGUI displayCurrentScore;
    void Start()
    {
        EventsMananger.GameStart += ShowScore;
    }

    void ShowScore()
    {
        displayCurrentScore.enabled = true;
    }
}
