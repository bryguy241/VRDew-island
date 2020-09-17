using System;
using UnityEngine;

public class BuildingUpgrade : MonoBehaviour
{
    public UpgradeMaterial[] requiredMaterials;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}

[Serializable]
public struct UpgradeMaterial
{
    public string item;
    public int quantity;
}