using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RestartGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public void Restart()
    {
        SceneManager.LoadScene("Crossy Jump");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundController.SharedInstance.PlaySound("ClickSound");
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

}
