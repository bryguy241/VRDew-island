using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CollectableSystem : MonoBehaviour
{
    CollectableData collectableData = new CollectableData();
    public int tier = 1;
    public string collectableType = "";
    public string inventoryName= "";
    public string collectableID = "-1";
    public Image collectableImage = null;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadCollectableData(string path)
    {
        collectableData = JsonUtility.FromJson<CollectableData>(PlayerPrefs.GetString(path));
       // parent = GetComponentInParent<TileSystem>();
    }


}

public class CollectableData
{
    public int tier = 1;
    public string collectableType = "";
    public string collectableID = "-1";
    public string inventoryName = "";
    public Image collectableImage = null;

}
