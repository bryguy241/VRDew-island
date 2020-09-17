using UnityEngine;
using UnityEngine.UI;

public class BuildingComponent : MonoBehaviour
{

    public string buildingName;
    public int tier = 0;
    public float maxUpgradeDistance = 5f;
    public Text requiredMaterialText;
    public Text pressEnterText;
    public GameObject buildingCanvas;
    public GameObject player; 
    public GameObject[] upgrades;

    // Start is called before the first frame update
    void Start()
    {
        buildingCanvas.SetActive(false);

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

        UpdateRequiredMaterialsText();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if it has additional upgrades
        if (tier < upgrades.Length - 1)
        {

            bool withinRange = Vector3.Distance(transform.position, player.transform.position) <= maxUpgradeDistance;
            // Displays the appropriate overheard text
            if (withinRange && !buildingCanvas.activeSelf)
            {
                buildingCanvas.SetActive(true);
                requiredMaterialText.color = Color.white;
                pressEnterText.color = Color.white;
            }/* If the text should change color
            else if (withinRange && !buildingCanvas.activeSelf && !canUpgrade)
            {
                buildingCanvas.SetActive(true);
                requiredMaterialText.color = Color.red;
                pressEnterText.color = Color.grey;
            }*/
            else if (!withinRange && buildingCanvas.activeSelf)
            {
                buildingCanvas.SetActive(false);
            }

            if (withinRange)
            {
                if (Input.GetKeyDown(KeyCode.Return) && CanUpgrade())
                {
                    Upgrade();
                }
            }

        }

    }

    private void Upgrade()
    {
        print("Upgrade Building");
        tier++;
        buildingCanvas.SetActive(false);

        upgrades[tier - 1].SetActive(false);
        upgrades[tier].SetActive(true);

        UpdateRequiredMaterialsText();
    }

    private bool CanUpgrade()
    {
        UpgradeMaterial[] requiredMaterials = upgrades[tier + 1].GetComponent<BuildingUpgrade>().requiredMaterials;
        string[] items = new string[requiredMaterials.Length];
        int[] counts = new int[requiredMaterials.Length];
        for (int i = 0; i < requiredMaterials.Length; i++)
        {
            items[i] = requiredMaterials[i].item;
            counts[i] = requiredMaterials[i].quantity;
        }

        return player.GetComponent<MainInventory>().CheckRequiredMaterials(items, counts);
    }

    private void UpdateRequiredMaterialsText()
    {
        string material = "";
        if (tier + 1 < upgrades.Length)
        {
            UpgradeMaterial[] requiredMaterials = upgrades[tier + 1].GetComponent<BuildingUpgrade>().requiredMaterials;
            for (int i = 0; i < requiredMaterials.Length; i++)
            {
                material += requiredMaterials[i].quantity + " " + requiredMaterials[i].item;

                if (i < requiredMaterials.Length - 1)
                {
                    material += "\n";
                }
            }
        }

        requiredMaterialText.text = material;
    }

}
