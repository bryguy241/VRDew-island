using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItems : MonoBehaviour
{
    public List<GameObject> equiptItems = new List<GameObject>();
    public int oldIndex = 0;
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateItem(int index)
    {
        equiptItems[oldIndex].gameObject.SetActive(false);
        equiptItems[index].gameObject.SetActive(true);
        oldIndex = index;

    }
}
