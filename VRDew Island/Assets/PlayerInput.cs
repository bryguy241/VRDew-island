﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Speed = 1;
    Rigidbody rb;
    Vector3 movementDir;
    Vector3 currentDir;
    private RaycastHit hit;
    public Camera followCam;
    private Plane plane;
    public Vector3 hitPoint;
    private Quaternion targetRotation;
    float turnSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitPoint = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        currentDir = transform.forward;
        movementDir = Vector3.zero;
        plane.SetNormalAndPosition(Vector3.up, transform.position);

        if (Input.GetKey(KeyCode.A))
            // rb.AddForce(Vector3.left * Speed);
            movementDir += Vector3.left * Speed;
            if (Input.GetKey(KeyCode.D))
            movementDir += Vector3.right * Speed;
            if (Input.GetKey(KeyCode.W))
            movementDir += Vector3.forward * Speed;
            if (Input.GetKey(KeyCode.S))
            movementDir += Vector3.back * Speed;
            rb.velocity = movementDir;

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float intersectionDistance = 0f;


        if (Physics.Raycast(cameraRay, out hit, 100000.0f))
        {
            hitPoint = hit.point + Vector3.up * 0.25f;


        }
        /* if i ever wanna add back in mouse controls
        if (plane.Raycast(cameraRay, out intersectionDistance))
        {
            hitPoint = cameraRay.GetPoint(intersectionDistance);
            targetRotation = Quaternion.LookRotation(hitPoint - transform.position);
            print("hitpoint:" + hitPoint);
        }
          if (movementDir!= Vector3.zero)
         {
      
          transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
         }
         */
        if (movementDir != Vector3.zero)
        {

            targetRotation = Quaternion.LookRotation(movementDir);
            print(targetRotation);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
    }
}
