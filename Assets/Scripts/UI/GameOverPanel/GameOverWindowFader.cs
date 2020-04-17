using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWindowFader : MonoBehaviour
{
    public CanvasGroup canvGroup;
    public float duration = 0.5f;

    private void Start()
    {
        EventsMananger.GameOver += FadeIn;
    }
    public void FadeIn()
    {
        StartCoroutine(DoFadeIn(canvGroup, canvGroup.alpha, 1));
        canvGroup.blocksRaycasts = true;
    }

    public IEnumerator DoFadeIn(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);

            yield return null;
        }
    }

    public void FadeOut()
    {
        StartCoroutine(DoFadeOut(canvGroup, canvGroup.alpha, 0));
        canvGroup.blocksRaycasts = false;
    }

    public IEnumerator DoFadeOut(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < 0.01f)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / 0.01f);

            yield return null;
        }
    }
}
