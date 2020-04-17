using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject startMenuUI;

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundController.SharedInstance.PlaySound("ClickSound");
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        EventsMananger.SharedInstance.StartGame();
    }
}
