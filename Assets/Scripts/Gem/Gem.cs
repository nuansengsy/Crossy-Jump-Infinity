using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject pointDisplayPrefab;
    public GameObject effect;
    private GameObject pointDisplay;

    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Vector3 pos;
        if (other.gameObject.tag == "player")
        {
            SoundController.SharedInstance.PlaySound("GemSound");
            rend.enabled = false;
            pos = transform.position;
            Instantiate(effect, pos, Quaternion.identity);


            if (pointDisplayPrefab != null)
            {
                pos = transform.position;
                pointDisplay = Instantiate(pointDisplayPrefab, pos, Quaternion.identity);
                pointDisplay.transform.GetChild(0).gameObject.GetComponent<PointsDisplay>().SetText("+3");
            }

            Destroy(gameObject);
        }
        
    }
}
