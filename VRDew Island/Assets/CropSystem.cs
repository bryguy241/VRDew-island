using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CropSystem : MonoBehaviour
{
    CropData cropData = new CropData();
    public string cropID;
    public int totalDays;
    public int currentDays;
    public string collectableName;

    public GameObject SeedStage;
    public GameObject SproutStage;
    public GameObject AlmostFullStage;

    public TileSystem parent;


    // Start is called before the first frame update
    void Start()
    {
      //  ReadCropData(GetInstanceID()+"");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadCropData(string path)
    {
        cropData = JsonUtility.FromJson<CropData>(PlayerPrefs.GetString(path));
        print("I have read my data sir: "+ PlayerPrefs.GetString(path));
        parent = GetComponentInParent<TileSystem>();
        CheckGrowth();


    }

    public void CheckGrowth()
    {
        print("I am on day: " + cropData.currentDays + " and I checking vs + " + cropData.totalDays / 3);
        if (cropData.currentDays <= (cropData.totalDays-1) / 3)
        {
            print("stage1");
            SeedStage.gameObject.SetActive(true);
            SproutStage.gameObject.SetActive(false);
            AlmostFullStage.gameObject.SetActive(false);

        }
        else if(cropData.currentDays <= 2*((cropData.totalDays-1)/3))
        {
            print("stage2");
            SeedStage.gameObject.SetActive(false);
            SproutStage.gameObject.SetActive(true);
            AlmostFullStage.gameObject.SetActive(false);
        }
        else if (cropData.currentDays <= cropData.totalDays-1)
        {
            print("stage3");
            SeedStage.gameObject.SetActive(false);
            SproutStage.gameObject.SetActive(false);
            AlmostFullStage.gameObject.SetActive(true);
        }
        else if(cropData.currentDays == cropData.totalDays)
        {
            SeedStage.gameObject.SetActive(false);
            SproutStage.gameObject.SetActive(false);
            AlmostFullStage.gameObject.SetActive(false);
            parent.tileData.cropID = "-1";
            parent.tileData.cropType = "";
            parent.SpawnCollectable(cropData.collectableName);
            PlayerPrefs.DeleteKey(parent.tileData.cropID);
            Destroy(this.gameObject);


            print("CREATE PRODUCE COLLECTABLE");
        }

    }

    public void GrowMe()
    {
        cropData.currentDays += 1;
        CheckGrowth();
    }


    public void InitializeCrop()
    {

        cropData.totalDays = totalDays;
        cropData.currentDays = 0;
        cropData.collectableName = collectableName;
    }

    public void SaveCropData(string path)
    {
        PlayerPrefs.SetString(path, JsonUtility.ToJson(cropData));
        print("I save my crop data!");
    }
}


[Serializable]
public class CropData
{
    public string cropID = "";
    public int totalDays = 1;
    public int currentDays = 0;
    public string collectableName = "";


}
