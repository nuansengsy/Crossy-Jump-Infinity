using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyEffect : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 1.2f);
    }
}
