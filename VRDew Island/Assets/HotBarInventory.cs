using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotBarInventory : MonoBehaviour
{
    public Button[] HotBarButtons = new Button[8];
    public static Text[] Quantities = new Text[8];
    public static GameObject[] equiptItems = new GameObject[8];
    public Image selectionIndicator;
    public static int nextOpen = 0;
    public ItemStruct equiptItem;
    public static HotBarData hotBarData = new HotBarData();


    public GameObject spawnUnderMe; // will be the pill for now, maybe later its the hand of the character.

    public int oldIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
      PlayerPrefs.DeleteKey("" + GetInstanceID());

        for (int i = 0; i < 8; i++)
        {
            print(HotBarButtons[i].GetComponentInChildren<Text>().text);
            Quantities[i] = HotBarButtons[i].GetComponentInChildren<Text>();
        }
        if (PlayerPrefs.GetString("" + GetInstanceID(), "none") != "none") // if we have a save
        {

            hotBarData = JsonUtility.FromJson<HotBarData>(PlayerPrefs.GetString("" + GetInstanceID()));
            print("top route");
            ReadHotBarData();
        }
        else
        {

            //load in starting mats;
            SpawnStartingItems();

       //    PlayerPrefs.SetString("" + GetInstanceID(), JsonUtility.ToJson(hotBarData));
        }

        equiptItem = equiptItems[0].GetComponent<ItemStruct>();

        ActivateItem(0);


    }

    public void ReadHotBarData()
    {
        equiptItems = hotBarData.equiptItems;
        int counter = 0;
        nextOpen = -1;
        foreach(GameObject g in hotBarData.equiptItems)
        {
            try { 
            ItemStruct i = g.GetComponent<ItemStruct>();
            GameObject temp = Instantiate(Resources.Load<GameObject>("Inventory/" + i.Name), spawnUnderMe.gameObject.transform.position, Quaternion.identity, spawnUnderMe.gameObject.transform);
            equiptItems[counter] = temp;
            HotBarButtons[counter].image.sprite = i.Icon;
            }
            catch {
                print("open slot at " + counter);
                nextOpen = counter;
            }
            counter++;
        }
        print("I think my slot is at " + nextOpen);
 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateItem(int index)
    {
        if (equiptItems[oldIndex] != null)
            equiptItems[oldIndex].gameObject.SetActive(false);
        if (equiptItems[index] != null)
        {
         
            equiptItems[index].gameObject.SetActive(true); // set the object true
         

            equiptItem = equiptItems[index].GetComponent<ItemStruct>();
        }
        else
        {
            equiptItem = null;
        }

        oldIndex = index;

    }

    public void SpawnStartingItems()
    {
        /*
        GameObject temp1 = Instantiate(Resources.Load<GameObject>("Inventory/" + "PickAxe"), spawnUnderMe.gameObject.transform.position, Quaternion.identity, spawnUnderMe.gameObject.transform);
        equiptItems[0] = temp1;
        GameObject temp2 = Instantiate(Resources.Load<GameObject>("Inventory/" + "WoodAxe"), spawnUnderMe.gameObject.transform.position, Quaternion.identity, spawnUnderMe.gameObject.transform);
        equiptItems[1] = temp2;
        GameObject temp3 = Instantiate(Resources.Load<GameObject>("Inventory/" + "Hoe"), spawnUnderMe.gameObject.transform.position, Quaternion.identity, spawnUnderMe.gameObject.transform);
        equiptItems[2] = temp3;
        GameObject temp4 = Instantiate(Resources.Load<GameObject>("Inventory/" + "WateringCan"), spawnUnderMe.gameObject.transform.position, Quaternion.identity, spawnUnderMe.gameObject.transform);
        equiptItems[3] = temp4;
        */

        TryAddToHotBar("PickAxe");
        TryAddToHotBar("WoodAxe");
        TryAddToHotBar("Hoe");
        TryAddToHotBar("WateringCan");
        TryAddToHotBar("Yam Seed");

   //     GameObject temp5 = Instantiate(Resources.Load<GameObject>("Inventory/" + "Yam Seed"), spawnUnderMe.gameObject.transform.position, Quaternion.identity, spawnUnderMe.gameObject.transform);
     //   temp5

        equiptItems[4].GetComponent<ItemComponent>().Quantity = 10;

        Quantities[4].text = equiptItems[4].GetComponent<ItemComponent>().Quantity + "";

        hotBarData.equiptItems = equiptItems;
        UpdateAmounts();
    /*
        int indexer = 0;
        foreach (GameObject g in hotBarData.equiptItems)
        {
            try
            {
                ItemStruct i = g.GetComponent<ItemStruct>();

                HotBarButtons[indexer].image.sprite = i.Icon;
                nextOpen++;
            }
            catch { }
            indexer++;

        }
        print("upon start we are at open index:" + nextOpen);
       
    */
    }

    public void SaveHotBarData()
    {
        PlayerPrefs.SetString("" + GetInstanceID(), JsonUtility.ToJson(hotBarData));
        print("I save my hotbar data!");

    }

    public bool TryAddToHotBar(string name)
    {
        print("adding "+ name +" to index " + nextOpen);

        foreach(GameObject g in equiptItems)
        {
            try
            {
                if (g.GetComponent<ItemStruct>().Name == name)
                {
                    g.GetComponent<ItemComponent>().AddOne();
                    return true;
                }

            }
            catch
            {

            }
 
        }


        if (nextOpen < 8)
        {
            GameObject temp = Instantiate(Resources.Load<GameObject>("Inventory/" + name), spawnUnderMe.gameObject.transform.position, Quaternion.identity, spawnUnderMe.gameObject.transform);
            temp.gameObject.SetActive(false);
            equiptItems[nextOpen] = temp;
            try
            {
                ItemStruct i = temp.GetComponent<ItemStruct>();
                HotBarButtons[nextOpen].image.sprite = i.Icon;
            }
            catch { }
            hotBarData.equiptItems = equiptItems;
            int counter = 0;
            bool found = false;
            foreach (GameObject g in equiptItems)
            {
                if (!found)
                {
                    try
                    {
                        if (g != null)
                        {
                        }
                        else
                        {
                            nextOpen = counter;
                            found = true;
                            break;
                        }
                    }
                    catch
                    {
                        nextOpen = counter;
                        found = true;
                        break;
                    }
                    counter++;
                }
            }

            return true;
           
        }

        return false;
    }

    public static void UpdateAmounts()
    {

        int counter = 0;
        
        foreach (GameObject ic in equiptItems)
        {
            try
            {

                if (ic.GetComponent<ItemComponent>() != null)
                {
                    print(ic.GetComponent<ItemComponent>().Quantity);
                    print(hotBarData.equiptItems[counter].GetComponent<ItemComponent>().Quantity);
                 
                        hotBarData.equiptItems[counter].GetComponent<ItemComponent>().Quantity = ic.GetComponent<ItemComponent>().Quantity;
                        Quantities[counter].text = ic.GetComponent<ItemComponent>().Quantity + "";
                        print(Quantities[counter].text);
                    
                }

            }
            catch { }
            counter++;
        }
    }

    public bool CheckRequiredMaterials(string[] requirements, int[] amounts)
    {
        bool[] requirementsMet = new bool[requirements.Length];

        ItemComponent[] chosenOnes = new ItemComponent[requirements.Length];

        for (int i = 0; i < requirementsMet.Length; i++) { 

            requirementsMet[i] = false;
        }

        int truecounter = 0;


        foreach (GameObject g in equiptItems)
        {
            int itemSlot = 0;
            int counter = 0;
            foreach (string s in requirements)
            {
                try
                {
                    if (g.GetComponent<ItemStruct>().Name == s)
                    {
                        print("s: " + s + " g: " + g.GetComponent<ItemStruct>().Name);
                        print("left: " + g.GetComponent<ItemComponent>().Quantity + " right: " + amounts[counter]);
                        if (g.GetComponent<ItemComponent>().Quantity >= amounts[counter])
                        {
                            print("Found item " + g.GetComponent<ItemComponent>().Name);
                            requirementsMet[counter] = true;
                            print("chosenones " + chosenOnes.Length);
                            chosenOnes[counter] = g.GetComponent<ItemComponent>();
                            print("Got here");
                            truecounter++;
                        }
                    }

                }
                catch
                {

                }
                counter++;
            }
            itemSlot++;
           

        }
        
        if(truecounter == requirementsMet.Length)
        {
            for(int i = 0; i < chosenOnes.Length; i++)
            {
                print("chosenones name " + chosenOnes[i].Name);
                chosenOnes[i].Quantity -= amounts[i];
                UpdateAmounts();
            }
        }

        print("true counter: " + truecounter);
        return truecounter == requirementsMet.Length;
    }




}

   


[Serializable]
public class HotBarData
{
    public GameObject[] equiptItems = new GameObject[8];
}
