using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2f;
    public GameObject pointA, pointB;
    public GameObject targetTile;
    private bool hasPlanted;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hasPlanted = false;
    }

    private void OnEnable()
    {
        Vector3 start = pointA.transform.position;
        start.y = gameObject.transform.position.y;
        gameObject.transform.position = start;
        Vector3 lookDir = pointB.transform.position - pointA.transform.position;
        lookDir.y = 0;
        lookDir.Normalize();
        gameObject.transform.rotation = Quaternion.LookRotation(lookDir);
        dir = lookDir;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, pointB.transform.position) > 2f)
        {
            rb.velocity = dir * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            if (!hasPlanted)
            {
                hasPlanted = true;
                targetTile.GetComponent<TileSystem>().TillTile();
                targetTile.GetComponent<TileSystem>().PlantCrop("Yam Seed");
                targetTile.GetComponent<TileSystem>().WaterTile();
            }
        }
    }
}
