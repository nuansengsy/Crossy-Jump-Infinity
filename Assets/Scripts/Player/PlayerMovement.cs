using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float jumpVelocity;
    private bool onGround;

    private bool jumpRequest;
    private bool gameStarted = false;
    public float fallMultiplier;


    void Start()
    {
        EventsMananger.GameStart += AlloWToJump;
        EventsMananger.GameOver += StopPlayerMove;
        rb = GetComponent<Rigidbody>();
        onGround = true;

    }

    private void Update()
    {
        //if (Input.GetButton("Jump") && onGround == true)
        //{
            
        //    jumpRequest = true;
        //    gameObject.transform.SetParent(null);
        //}

        if (gameStarted && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && onGround == true)
        {

            jumpRequest = true;
            gameObject.transform.SetParent(null);
        }

        if (transform.position.y < -3)
        {
            SoundController.SharedInstance.PlaySound("GameOverSound");
            EventsMananger.SharedInstance.EndGame();
        }

    }

    void FixedUpdate()
    {
        if (jumpRequest)
        {
            gameObject.transform.SetParent(null);
            rb.velocity = new Vector3(0, 1.4f, 0.8f) * jumpVelocity;
            jumpRequest = false;
            onGround = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
    }

    void OnCollisionEnter(Collision other)
    {
        //checks if collider is tagged "ground"
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("platform"))
        {
            if(transform.position.y >= 1.9f)
            {
                onGround = true;

                if (other.gameObject.CompareTag("platform"))
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    gameObject.transform.SetParent(other.transform);
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
                }
            }

        }
    }

    void AlloWToJump()
    {
        gameStarted = true;
    }

    void StopPlayerMove()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }











































    //public float fallMultiplier = 2.5f;
    //public float lowJumpMultiplier = 2f;
    ////public int forceConst = 10;
    ////private bool canJump;
    //private Rigidbody rb;

    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}
    //void Start()
    //{

    //}

    ////void FixedUpdate()
    ////{
    ////    if (canJump)
    ////    {
    ////        canJump = false;
    ////        rb.AddForce(0, forceConst, 1, ForceMode.Impulse);
    ////    }
    ////}

    //void Update()
    //{
    //    //if (Input.GetKeyUp(KeyCode.Space))
    //    //{
    //    //    canJump = true;
    //    //}
    //    if(rb.velocity.y < 0)
    //    {
    //        rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    //    }
    //}
}
