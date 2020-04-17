using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // change
    public string ANDROID_RATE_URL = "market://details?id=com.SoFlareStudios.CrossyJumpInfinity";

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundController.SharedInstance.PlaySound("ClickSound");
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        //#if UNITY_ANDROID
        //Application.OpenURL(ANDROID_RATE_URL);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
