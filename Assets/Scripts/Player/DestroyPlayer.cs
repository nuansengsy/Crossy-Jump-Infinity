using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        SoundController.SharedInstance.PlaySound("GameOverSound");
        GetComponent<TraumaInducer>().enabled = true;
        GetComponent<TraumaInducer>().enabled = false;
        EventsMananger.SharedInstance.EndGame();
        gameObject.SetActive(false);
    }
}
