using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolComponent : MonoBehaviour, ItemStruct
{
    public string Name = "";
    public int Tier = 1;

    public Sprite Icon;
    public GameObject MyPrefab;

    string ItemStruct.Name { get => Name; set => Name = value; }
    int ItemStruct.Tier { get => Tier; set => Tier = value; }
    Sprite ItemStruct.Icon { get => Icon; set => Icon = value; }
    GameObject ItemStruct.MyPrefab { get => MyPrefab; set => MyPrefab = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
