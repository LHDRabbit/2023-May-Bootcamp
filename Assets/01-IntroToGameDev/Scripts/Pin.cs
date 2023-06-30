using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isFallen;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody pinRigidBody;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        pinRigidBody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (gameObject.activeSelf)
        isFallen = Quaternion.Angle(startRotation, transform.localRotation) > 5;
    }

    public void ResetPin()
    {
        // stopping inertia 
        pinRigidBody.velocity = Vector3.zero;
        pinRigidBody.angularVelocity = Vector3.zero;

        //returning back to position and rotation
        transform.position = startPosition;
        transform.position = startPosition + Vector3.up * 0.01f; 
        transform.rotation = startRotation;

        isFallen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pit"))
            isFallen = true;
                }

}

