using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : MonoBehaviour
{
    public LanesManager lanesManager;

    public GameObject[] movingPlatformsArray;
    public GameObject stationaryPlatform;

    public List<GameObject> allPlatformsList = new List<GameObject>();

    public int laneId;
    public float xMinPos, xMaxPos;

    public float xPos;
    [SerializeField]private float platformsDistance = 4f;
    [SerializeField] private float speed = 4f;
    public bool isStationary;
    public Vector3 moveDirection;

    void Start()
    {
        //allPlatformsList = new List<GameObject>();
        
        PlacePlatforms();
        SetPlatformsParameters();
    }



    public void PlacePlatforms()
    {
        GameObject platform;
        
        xPos = xMinPos;

        if (!isStationary)
        {
            while (xPos <= xMaxPos)
            {
                int random = Random.Range(0, movingPlatformsArray.Length);
                Vector3 platformSize = movingPlatformsArray[random].GetComponent<Platform>().size;

                if (xPos + platformSize.x > xMaxPos)
                {
                    break;
                }

                xPos += platformSize.x / 2;
                platform = Instantiate(movingPlatformsArray[random], transform);
                platform.transform.localPosition = new Vector3(xPos, 0, 0);
                platform.GetComponent<Platform>().laneId = this.laneId;
                allPlatformsList.Add(platform);
                xPos += platformSize.x / 2;
                xPos += platformsDistance;
            }
        }
        else
        {
            platform = Instantiate(stationaryPlatform, transform);
        }


    }

    public void SetPlatformsParameters()
    {
        if (!isStationary)
        {
            for (int i = 0; i < allPlatformsList.Count; i++)
            {
                allPlatformsList[i].GetComponent<Platform>().leftBorder = this.xMinPos;
                allPlatformsList[i].GetComponent<Platform>().rightBorder = xPos - platformsDistance;

                allPlatformsList[i].GetComponent<Platform>().moveDirection = this.moveDirection;

                allPlatformsList[i].GetComponent<Platform>().speed = this.speed;
            }
        }

    }

    public void MoveBack()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RelocationTrigger")
        {
            lanesManager.RelocateLane(laneId);
        }
        
    }

    public void UpdateMoveDirection()
    {

        for (int i = 0; i < allPlatformsList.Count; i++)
        {
            allPlatformsList[i].GetComponent<Platform>().moveDirection = this.moveDirection;
        }

    }

    public void RemovePlatforms()
    {
        GameObject platform;
        allPlatformsList.Clear();
        while(transform.childCount > 0)
        {
            platform = transform.GetChild(0).gameObject;
            transform.GetChild(0).SetParent(null);
            Destroy(platform);
        }
    }

    public void SpeedUp(int laneID)
    {
        if (!isStationary)
        {
            for (int i = 0; i < allPlatformsList.Count; i++)
            {
                allPlatformsList[i].GetComponent<Platform>().speed += this.speed * 0.5f;
            }
        }

    }
}