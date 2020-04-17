using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
    public TextMeshPro textMesh;

    public void SetText(string textToShow)
    {
        this.textMesh.text = textToShow;
    }


    // Update is called once per frame
    void Update()
    {
        Destroy(transform.parent.gameObject, 1.2f);
    }
}
