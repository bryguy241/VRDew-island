using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class BuildingComponent : MonoBehaviour
{

    public string buildingName;
    public int tier = 0;
    public float maxUpgradeDistance = 5f;
    public GameObject hoverText;
    public GameObject player;
    public GameObject[] upgrades;

    // Start is called before the first frame update
    void Start()
    {
        hoverText.SetActive(false);
        
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (i == tier)
            {
                upgrades[i].SetActive(true);
            }
            else
            {
                upgrades[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if it can be upgraded
        if (tier < upgrades.Length - 1)
        {

            float dist = Vector3.Distance(transform.position, player.transform.position);
            if (dist <= maxUpgradeDistance)
            {
                if (!hoverText.activeSelf)
                {
                    hoverText.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.Return) && CanUpgrade())
                {
                    Upgrade();
                }

            }
            else if (hoverText.activeSelf)
            {
                hoverText.SetActive(false);
            }

        }
        
    }

    private void Upgrade()
    {
        print("Upgrade Building");
        tier++;
        hoverText.SetActive(false);

        upgrades[tier - 1].SetActive(false);
        upgrades[tier].SetActive(true);
    }

    private bool CanUpgrade()
    {
        return true;
    }

}
