using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGem : MonoBehaviour
{

    public GameObject gem;
    private int percToSpawn = 15;
    void Start()
    {
        AddGem();
    }

    void AddGem()
    {
        int random = Random.Range(1, 101);
        if(random < percToSpawn)
        {
            Instantiate(gem, transform);
            gem.transform.position = new Vector3(0, 2.5f, 0);
        }

    }
}
