using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;


    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
        Vector3 goalPos = target.position;
        goalPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}
