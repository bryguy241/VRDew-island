using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour , ItemStruct
{
    public string Name = "";
    public int Tier = 1;

    string ItemStruct.Name { get => Name; set => Name = value ; }
    int ItemStruct.Tier { get => Tier; set => Tier = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
