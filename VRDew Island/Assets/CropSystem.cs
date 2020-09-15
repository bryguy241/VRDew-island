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
    public string produce;

    public GameObject SeedStage;
    public GameObject SproutStage;
    public GameObject AlmostFullStage;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadCropData(string path)
    {
        cropData = JsonUtility.FromJson<CropData>(PlayerPrefs.GetString(path));

        CheckGrowth();


    }

    public void CheckGrowth()
    {
     

        if (cropData.currentDays < cropData.totalDays / 3)
        {
            SeedStage.gameObject.SetActive(true);
            SproutStage.gameObject.SetActive(false);
            AlmostFullStage.gameObject.SetActive(false);

        }
        else if(cropData.currentDays < 2*(cropData.totalDays/3)    && cropData.currentDays > cropData.totalDays / 3)
        {
            SeedStage.gameObject.SetActive(false);
            SproutStage.gameObject.SetActive(true);
            AlmostFullStage.gameObject.SetActive(false);
        }
        else if (cropData.currentDays < cropData.totalDays)
        {
            SeedStage.gameObject.SetActive(false);
            SproutStage.gameObject.SetActive(false);
            AlmostFullStage.gameObject.SetActive(true);
        }
        else if(cropData.currentDays == cropData.totalDays)
        {
            print("CREATE PRODUCE COLLECTABLE");
        }

    }


    public void InitializeCrop()
    {

        cropData.totalDays = totalDays;
        cropData.currentDays = currentDays;
        cropData.produce = produce;
    }

    public void SaveCropData()
    {
        PlayerPrefs.SetString("" + GetInstanceID(), JsonUtility.ToJson(cropData));
    }
}


[Serializable]
public class CropData
{
    public string cropID = "";
    public int totalDays = 1;
    public int currentDays = 0;
    public string produce = "";


}
