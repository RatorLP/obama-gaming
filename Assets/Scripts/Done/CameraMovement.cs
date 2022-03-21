using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; //the player or game object which is followed by the camera
    public float smoothTime = 0.3f; //the time the camera takes to to catch up to the player

    private Vector3 velocity = Vector3.zero; //resets velocity vector


    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>(); //create a reference to the player if it doesn't exist
        }
        Vector3 goalPos = target.position; //set the target position to the player position but keep the camera at its z position
        goalPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}
