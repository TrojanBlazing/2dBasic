using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10f);
    private float TimeToReachTarget = 0.2f;
    private Vector3 velocity = Vector3.zero;
    public Transform targetpos;


    void Start()
    {


    }


    void Update()
    {
        Vector3 targetPosition = targetpos.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, TimeToReachTarget);
    }
}

