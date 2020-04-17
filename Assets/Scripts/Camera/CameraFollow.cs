using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 distance;
    public Vector3 moveToPos;
    private bool gameIsOn;


    void Start()
    {
        gameIsOn = true;
        EventsMananger.GameOver += StopFollow;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOn)
        {
            //if (Vector3.Distance(player.transform.position, transform.position) > 10f)
            //{
            //    moveToPos = new Vector3(distance.x, player.transform.position.y + distance.y, player.transform.position.z + distance.z);
            //    iTween.MoveTo(gameObject, iTween.Hash("position", moveToPos, "time", 1f, "easetype", "easeOutCubic"));
            //}

            transform.position = new Vector3(distance.x, player.transform.position.y + distance.y, player.transform.position.z + distance.z);
        }

    }

    public void StopFollow()
    {
        gameIsOn = false;
    }
}
