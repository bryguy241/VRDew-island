using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ItemStruct
{

    string Name { get; set; }
    int Tier { get; set; }
    Sprite Icon { get; set; }
    GameObject MyPrefab { get; set; }

}
