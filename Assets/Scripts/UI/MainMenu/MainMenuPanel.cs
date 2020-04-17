using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour
{
    public CanvasGroup canvGroup;

    private bool mainMenuFaded = false;
    public float duration = 0.5f;
    void Start()
    {
        CanvasGroup canvGroup = GetComponent<CanvasGroup>();
        EventsMananger.GameStart += HideMainMenu;
    }

    void HideMainMenu()
    {
        StartCoroutine(DoFadeOut(canvGroup, canvGroup.alpha, 0));
        canvGroup.blocksRaycasts = false;
        mainMenuFaded = !mainMenuFaded;

    }

    public IEnumerator DoFadeOut(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);

            yield return null;
        }
    }
}
