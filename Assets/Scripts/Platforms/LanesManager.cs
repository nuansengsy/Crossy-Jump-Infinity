using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public  class LaneData
{
    public GameObject laneObject;
    public int laneId;
}
public class LanesManager : MonoBehaviour
{
    public List<LaneData> lanesList;

    public GameObject startPlatform;
    public float laneLength;
    public float zLanesDistance;
    public float yLanesDistance;

    public int stationaryLanesPercent;

    private void Awake()
    {
        for(int i = 0; i < lanesList.Count; i++)
        {
            SetLanesParameters(i);
            SetLanesType(i);
            SetMoveParameters(i);
        }
    }
 
    void SetLanesParameters(int i)
    {  
        Vector3 lanePos;

        //set parameters
        lanesList[i].laneId = i;
        lanesList[i].laneObject.GetComponent<PlatformsController>().laneId = lanesList[i].laneId;
        lanesList[i].laneObject.GetComponent<PlatformsController>().xMinPos = startPlatform.transform.position.x - laneLength / 2;
        lanesList[i].laneObject.GetComponent<PlatformsController>().xMaxPos = startPlatform.transform.position.x + laneLength / 2;

        //set position
        lanePos.x = startPlatform.transform.position.x;
        //lanePos.y = (startPlatform.transform.localScale.y / 2 + 0.5f / 2) * (i+1);
        lanePos.y = startPlatform.transform.position.y;
        lanePos.z = (startPlatform.transform.localScale.z / 2 + 2f / 2 + zLanesDistance) * (i+1);
        lanesList[i].laneObject.transform.position = lanePos;
    }

    void SetLanesType(int i)
    {
        int random = Random.Range(0, 101);
        //Debug.Log(random);

        if (random > stationaryLanesPercent)
        {
            lanesList[i].laneObject.GetComponent<PlatformsController>().isStationary = false;
            //Debug.Log(random + ">" + stationaryLanesPercent);
        }
        else
        {
            lanesList[i].laneObject.GetComponent<PlatformsController>().isStationary = true;
            //Debug.Log(random + "<" + stationaryLanesPercent);
        }
    }

    void SetMoveParameters(int i)
    {
        PlatformsController currentLane;
        PlatformsController previuosLane;

        //set move direction of first lane
        if (i == 0)
        {
            currentLane = lanesList[0].laneObject.GetComponent<PlatformsController>();
            
            if (!currentLane.isStationary)
            {
                int random = Random.Range(0, 2);
                if (random == 0)
                {
                    currentLane.moveDirection = Vector3.left;
                }
                if (random == 1)
                {
                    currentLane.moveDirection = Vector3.right;
                }
            }
        }

        //set move direction for other lanes
        else
        {
            currentLane = lanesList[i].laneObject.GetComponent<PlatformsController>();
            previuosLane = lanesList[i - 1].laneObject.GetComponent<PlatformsController>();

            if (!currentLane.isStationary)
            {
                if (previuosLane.isStationary)
                {
                    int random = Random.Range(0, 2);
                    if (random == 0)
                    {
                        currentLane.moveDirection = Vector3.right;
                    }
                    if (random == 1)
                    {
                        currentLane.moveDirection = Vector3.left;
                    }
                }

                if (!previuosLane.isStationary && previuosLane.moveDirection == Vector3.left)
                {
                    currentLane.moveDirection = Vector3.right;
                }

                if (!previuosLane.isStationary && previuosLane.moveDirection == Vector3.right)
                {
                    currentLane.moveDirection = Vector3.left;
                }
            }
            else
            {
                currentLane.moveDirection = new Vector3(0, 0, 0);
            }
        }
    }



    public void RelocateLane(int laneID)
    {
        lanesList[laneID].laneObject.GetComponent<PlatformsController>().RemovePlatforms();
        SetLanesType(laneID);
        SetMoveParameters(laneID);
        lanesList[laneID].laneObject.GetComponent<PlatformsController>().PlacePlatforms();
        lanesList[laneID].laneObject.GetComponent<PlatformsController>().SetPlatformsParameters();

        float yPos = startPlatform.transform.position.y;
        float zPos = (2 / 2 + zLanesDistance + 2 / 2) * lanesList.Count;

        Vector3 moveToPos = lanesList[laneID].laneObject.transform.position + new Vector3(0, yPos, zPos);
        lanesList[laneID].laneObject.transform.position = lanesList[laneID].laneObject.transform.position + new Vector3(0, yPos - 20, zPos);
        iTween.MoveTo(lanesList[laneID].laneObject, iTween.Hash("position", moveToPos, "time", 1f, "easetype", "easeOutCubic"));

        if (laneID == 0)
        {
            if(!lanesList[lanesList.Count - 1].laneObject.GetComponent<PlatformsController>().isStationary)
            {
                lanesList[laneID].laneObject.GetComponent<PlatformsController>().moveDirection =
                Vector3.Scale(lanesList[lanesList.Count - 1].laneObject.GetComponent<PlatformsController>().moveDirection, new Vector3(-1, 0, 0));
                lanesList[laneID].laneObject.GetComponent<PlatformsController>().UpdateMoveDirection();
            }

        }
        else
        {
            if(!lanesList[laneID - 1].laneObject.GetComponent<PlatformsController>().isStationary)
            {
                lanesList[laneID].laneObject.GetComponent<PlatformsController>().moveDirection =
                Vector3.Scale(lanesList[laneID - 1].laneObject.GetComponent<PlatformsController>().moveDirection, new Vector3(-1, 0, 0));
                lanesList[laneID].laneObject.GetComponent<PlatformsController>().UpdateMoveDirection();
            }

        }
    }
}
