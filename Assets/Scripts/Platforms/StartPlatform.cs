using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{
    private bool moved = false;
    private float timeStartedLerping;
    private float timeSinceLerping;
    private float timeToMove = 1f;
    private float perc = 0f;

    void OnCollisionExit(Collision other)
    {
        
        StartCoroutine(MoveStartPlatform(transform.position, transform.position + new Vector3(0, 0, -10)));
    }

    public IEnumerator MoveStartPlatform(Vector3 moveFromPosition, Vector3 moveToPosition)
    {
        if (!moved)
        {
            timeStartedLerping = Time.time;

            while (perc < 1)
            {
                timeSinceLerping = Time.time - timeStartedLerping;
                perc = timeSinceLerping / timeToMove;
                transform.localPosition = Vector3.Lerp(moveFromPosition, moveToPosition, perc);
                yield return null;
            }
        }
        perc = 0f;
        moved = false;

    }
}
