using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    //// [access modifier] [data type] [variable name] [variable value]
    //[SerializeField]
    //private float bowlingBallSpeed = 5f;

    //public float mouseSensitivity = 100;

    //public Vector3 axis;

    //public Transform pointATransform;

    //public Transform pointBTransform;

    //private void Awake()
    //{
    //    Debug.Log("Hello Universe!");
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    Debug.Log("Hello World!");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // moving forward
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.Translate(transform.forward * Time.deltaTime * bowlingBallSpeed);
    //    }
    //    // moving backward
    //    else if (Input.GetKey(KeyCode.S))
    //    {
    //        transform.Translate(-transform.forward * Time.deltaTime * bowlingBallSpeed);
    //    }
    //    // moving left
    //    else if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.Translate(-transform.right * Time.deltaTime * bowlingBallSpeed);
    //    }
    //    // moving right
    //    else if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.Translate(transform.right * Time.deltaTime * bowlingBallSpeed);
    //    }

    //    // mouse movement
    //    float mouseX = Input.GetAxis("Mouse X");
    //    float mouseY = Input.GetAxis("Mouse Y");

    //    transform.Rotate(Vector3.up * mouseX * Time.deltaTime * mouseSensitivity);


    //    float xRotation = -mouseY * Time.deltaTime * mouseSensitivity;
    //    xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    //    transform.Rotate(Vector3.right * xRotation);
    //}

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {   if(collision.gameObject.CompareTag("pin"))
        {
            Debug.Log("collided with pin");
            // tell the game manager to set the next throw
            gameManager.SetNextThrow();
            //destroy this gameobject
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pit"))
        {
            Debug.Log("entered the PIT");
        }
    }
}