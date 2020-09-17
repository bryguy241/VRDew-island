using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInventory : MonoBehaviour
{
    public HotBarInventory hotBarInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveInventory()
    {
        hotBarInventory.SaveHotBarData();
    }
    public bool TryAddItem(string name)
    {
        print("going through here");
        if (hotBarInventory.TryAddToHotBar(name))
        {
            return true;
        }
        /// check main inventory;
        return false;
    }

    public bool CheckRequiredMaterials(string[] requirements, int[] amounts)
    {
        if (hotBarInventory.CheckRequiredMaterials(requirements, amounts))
        {
            return true;
        }
        // CHECK MAIN INVENTROY EVENTUALLY


        return false;
    }

}
