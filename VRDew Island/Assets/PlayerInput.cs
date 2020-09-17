﻿using UnityEngine;

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
    public int hotbarSelected = 0;


    private Transform sphere;
    private float scale;

    public HotBarInventory hotbarInventory;
    public HeldItems heldItems;
    public float TimeBetweenClicks = .5f;
    float time = 0;

    public GameObject currentTarget;
    public GameObject currentInteractable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitPoint = transform.forward;

        //set up initial chosen item
        heldItems.ActivateItem(0);
        hotbarInventory.selectionIndicator.transform.position = hotbarInventory.HotBarButtons[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = Vector3.zero;
        currentDir = transform.forward;
        movementDir = Vector3.zero;
        plane.SetNormalAndPosition(Vector3.up, transform.position);

        #region WASD controls
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

        #endregion

        #region Mouse based looking

        /* if i ever wanna add back in mouse controls
      Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);


     if (Physics.Raycast(cameraRay, out hit, 100000.0f))
     {
         hitPoint = hit.point + Vector3.up * 0.25f;

     }

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
        #endregion

        #region Movemnt based Looking
        if (movementDir != Vector3.zero)
        {

            targetRotation = Quaternion.LookRotation(movementDir);
            print(targetRotation);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        #endregion
        //HotBarSelection

        #region scrolling through hotbar
        if (Input.mouseScrollDelta.y != 0)
        {
            hotbarSelected = (hotbarSelected - (int)Input.mouseScrollDelta.y) % 8;
            if (hotbarSelected == -1)
                hotbarSelected = 7;
            print(hotbarSelected);
            hotbarInventory.selectionIndicator.transform.position = hotbarInventory.HotBarButtons[hotbarSelected].transform.position;
            heldItems.ActivateItem(hotbarSelected);
        }

        #endregion

        #region Click Controls
        if (Input.GetMouseButton(0) && time + TimeBetweenClicks < Time.time)
        {
            time = Time.time;
            if (currentTarget != null)
            {
                print("clicking with the: " + heldItems.EquiptItem + " ||| trying to modify: " + currentTarget.name);
                currentTarget.GetComponent<TileSystem>().HitMe(heldItems.EquiptItem, heldItems.EquiptItemTier);
            }
        }

        if (Input.GetMouseButton(1))
        {

            if (currentTarget != null)
            {

                if (currentTarget.GetComponent<TileSystem>().HarvestableTile())
                {
                    currentTarget.GetComponent<TileSystem>().HarvestCollectable();
                }
            }
        }


        #endregion

    }



}
