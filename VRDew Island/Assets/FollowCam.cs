using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
   public  GameObject FollowMe;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = gameObject.transform.position.y - FollowMe.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(FollowMe.transform.position.x, gameObject.transform.position.y, FollowMe.transform.position.z - offset);
    }
}
