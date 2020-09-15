﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileSystem : MonoBehaviour
{
    public TileData tileData = new TileData();

    public GameObject tree;
    public GameObject crop;
    public GameObject collectable;
    public GameObject rock;

    public GameObject tilledAddon;
    public Material wateredMat;
    public Material notWateredMat;

    public string tileType;

    // Start is called before the first frame update
    void Start()
    {
        tileData.type = tileType;
        print("id for tile is :" + GetInstanceID());
        if(PlayerPrefs.GetString(""+ GetInstanceID(),"none") != "none") // if we have a save
        {

            // pull in the data stored with this

            tileData = JsonUtility.FromJson<TileData>(PlayerPrefs.GetString("" + GetInstanceID()));
            /*
          tileData.watered = PlayerPrefs.GetInt("watered" + GetInstanceID()); 
            tileData.tilled = PlayerPrefs.GetInt("tilled"+ GetInstanceID());
            tileData.treeID = PlayerPrefs.GetString("treeID" + GetInstanceID());
          tileData.cropID = PlayerPrefs.GetString("cropID" + GetInstanceID());
          tileData.rockID = PlayerPrefs.GetString("rockID" + GetInstanceID());
          tileData.collectableID = PlayerPrefs.GetString("collectableID" + GetInstanceID());
          */
            ReadTileData();

         

        }
        else
        {
            tileData.type = tileType;
            PlayerPrefs.SetString("" + GetInstanceID(), JsonUtility.ToJson(tileData));
        }
    }

    public void SaveTileData()
    {
        PlayerPrefs.SetString("" + GetInstanceID(), JsonUtility.ToJson(tileData));
    }

    public void ReadTileData()
    {
        TillTile();
        WaterTile();
        


        // things on tile
        if (tileData.rockID != "-1")
        {

        }
        else if(tileData.cropID != "-1")
        {
            if(crop == null)
            {
                crop = Instantiate(Resources.Load<GameObject>("Crops/" + tileData.cropType), transform.position, Quaternion.identity, transform);

            }
            //left off trying to get some form of planting mechanic in

            //  crop.GetComponent<CropSystem>().ReadCropData(tileData.cropID);



        }
        else if(tileData.collectableID != "-1")
        {

        }
        else if(tileData.treeID != "-1")
        {

        }
    }

    public void TillTile()
    {
        if (tileData.tilled == 1)
        {
            tilledAddon.gameObject.SetActive(true);
        }
        else
        {
            tilledAddon.gameObject.SetActive(false);
        }
    }
    public void WaterTile()
    {
        if (tileData.watered == 1)
        {
            GetComponent<MeshRenderer>().material = wateredMat;
        }
        else
        {
            GetComponent<MeshRenderer>().material = notWateredMat;
        }

    }
    public void CheckDestroyCrop()
    {
        if (crop != null)
        {
            PlayerPrefs.DeleteKey(tileData.cropID);
            tileData.cropID = "-1";
            tileData.cropType = "";
            Destroy(crop);
        }
        tileData.tilled = 0;
        TillTile();

    }
    public void PlantCrop(string plantName)
    {
        
        crop = Instantiate(Resources.Load<GameObject>("Crops/" + plantName), transform.position,Quaternion.identity, transform); //load in the crop
        tileData.cropID = "" + crop.gameObject.GetInstanceID();
        tileData.cropType = plantName;
        crop.GetComponent<CropSystem>().InitializeCrop();
        print("didnt error");


    }
    public void GrowTile()
    {
        if(tileData.watered == 1)
        {
            if (crop != null)
            {
                print("I should grow the crop");
               // crop.GetComponent<CropComponent>().GrowMe();
            }
            tileData.watered = 0;
        

        }
    }

    public void HitMe(string hitObj, int tier)
    {
        if (hitObj.Contains("Hoe"))
        {
           tileData.tilled = 1;

       

            TillTile();
        }
        else if (hitObj.Contains("WoodAxe"))
        {
            CheckDestroyCrop();
        }
        else if (hitObj.Contains("PickAxe"))
        {
            CheckDestroyCrop();
        }
        else if (hitObj.Contains("WateringCan"))
        {
            tileData.watered = 1;
            WaterTile();
        }
        else if (hitObj.Contains("Seed"))
        {
            if(tileData.tilled == 1 && tileData.rockID == "-1" && tileData.cropID == "-1" && tileData.type =="farm" && tileData.treeID == "-1" && tileData.collectableID == "-1")
            {
            
                PlantCrop(hitObj);
            }


        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable]
public class TileData
{
   // implement these later. Scope Bryan
    //public TreeComponent tree;
    //  public RockComponent rock;
    //  public GameObject collectable;
    //public CropComponent crop;

    public int watered = 0;
    public int tilled = 0;
    public string type = "";

    public string treeType = "";
    public string treeID = ""+ -1;

    public string cropType = "";
    public string cropID = "" + -1;

    public string rockType = "";
    public string rockID = "" + -1;

    public string collectableType = "";
    public string collectableID = "" + -1;

}


