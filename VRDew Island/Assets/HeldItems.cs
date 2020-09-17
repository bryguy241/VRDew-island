using System.Collections.Generic;
using UnityEngine;

public class HeldItems : MonoBehaviour
{
    public List<GameObject> equiptItems = new List<GameObject>();
    public int oldIndex = 0;
    public string EquiptItem;
    public int EquiptItemTier = 1;
    // Start is called before the first frame update
    void Start()
    {
        EquiptItem = equiptItems[0].GetComponent<ItemStruct>().Name;
        EquiptItemTier = equiptItems[0].GetComponent<ItemStruct>().Tier;
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
            equiptItems[index].gameObject.SetActive(true);
            print(equiptItems[index]);

            EquiptItem = equiptItems[index].GetComponent<ItemStruct>().Name;
            EquiptItemTier = equiptItems[index].GetComponent<ItemStruct>().Tier;
        }
        else
        {
            EquiptItem = "";
        }

        oldIndex = index;

    }
}
