using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxHelper : MonoBehaviour
{
    public PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("colided with " + other.name+ "and its tag is: "+ other.tag);
        if(other.tag == "Tile")
        playerInput.currentTarget = other.gameObject;
        if(other.tag == "interactable")
        {
            playerInput.currentInteractable = other.gameObject;
        }
    }
}
