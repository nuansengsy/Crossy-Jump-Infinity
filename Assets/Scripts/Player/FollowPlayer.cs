using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 pos;
    public Vector3 offset;

    private void Update()
    {
        pos.x = player.position.x;
        pos.y = player.position.y;
        pos.z = player.position.z - offset.z;
        transform.position = pos;
    }
}
