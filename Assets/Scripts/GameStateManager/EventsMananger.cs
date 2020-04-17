using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsMananger : MonoBehaviour
{
    public static EventsMananger SharedInstance;

    public delegate void OnGameStart();
    public static event OnGameStart GameStart;

    public delegate void OnGameOver();
    public static event OnGameOver GameOver;

    void Start()
    {
        SharedInstance = this;
    }

    public void StartGame()
    {
        GameStart();
    }

    public void EndGame()
    {
        GameOver();
    }

    private void OnDestroy()
    {
        EventsMananger.GameStart = null;
        EventsMananger.GameOver = null;
    }
}
