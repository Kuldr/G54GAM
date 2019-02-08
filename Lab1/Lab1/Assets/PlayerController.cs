﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float xMin = -10.0f;
    public float xMax = 10.0f;
    public float zMin = -10.0f;
    public float zMax = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Debug.Log("Input: " + horizontalMovement + " " + verticalMovement);

        Rigidbody r = GetComponent<Rigidbody>();

        r.velocity = new Vector3(
            horizontalMovement * speed,
            0.0f,
            verticalMovement * speed);

        r.position = new Vector3(
            Mathf.Clamp(r.position.x, xMin, xMax),
            r.position.y,
            Mathf.Clamp(r.position.z, zMin, zMax));
    }
}
