using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image soundOn;
    public Image soundOff;

    void Start()
    {
        if (PlayerPrefs.GetInt("AudioIsMuted", 0) == 0)
        {
            soundOff.enabled = false;
            soundOn.enabled = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("AudioIsMuted", 0) == 1)
            {
                soundOn.enabled = false;
                soundOff.enabled = true;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        SoundController.SharedInstance.PlaySound("ClickSound");
        SoundController.SharedInstance.MuteSound();
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        if (soundOn.enabled == true)
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }
        else
        {
            soundOff.enabled = false;
            soundOn.enabled = true;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
