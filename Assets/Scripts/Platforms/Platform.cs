using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 size;

    public int laneId;
    [SerializeField]
    private float platformsDistance = 4f;

    public Rigidbody rb;
    public float leftBorder, rightBorder;
    public Vector3 moveDirection;
    public float speed;

    public GameObject pointDisplayPrefab;
    private GameObject pointDisplay;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightBorder + size.x / 2 && moveDirection == Vector3.right)
        {
            transform.position = new Vector3(leftBorder + size.x / 2 - platformsDistance, transform.position.y, transform.position.z);
        }

        if (transform.position.x < leftBorder - size.x / 2 && moveDirection == Vector3.left)
        {
            transform.position = new Vector3(rightBorder - size.x / 2 + platformsDistance, transform.position.y, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 pos;
        if (collision.gameObject.tag == "player")
        {
            SoundController.SharedInstance.PlaySound("PlatformSound");
            transform.parent.gameObject.GetComponent<PlatformsController>().SpeedUp(laneId);

            if(pointDisplayPrefab != null)
            {
                pos = transform.position;
                pos.y += size.y / 2;

                pointDisplay = Instantiate(pointDisplayPrefab, pos, Quaternion.identity);

                pointDisplay.transform.GetChild(0).gameObject.GetComponent<PointsDisplay>().SetText("+1");
            }

        }
    }

}
