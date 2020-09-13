using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("inside this thing: " + collision.gameObject.name);
    }
}
