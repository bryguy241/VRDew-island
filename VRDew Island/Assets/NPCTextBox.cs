using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTextBox : MonoBehaviour
{

    public GameObject npc, player;
    public GameObject canvas;
    public Text page;
    public string text1, text2;
    private bool gotItems;

    // Start is called before the first frame update
    void Start()
    {
        page.text = text1;
        canvas.SetActive(false);
        gotItems = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gotItems && Vector3.Distance(npc.transform.position, player.transform.position) <= 3f)
        {
            if (!canvas.activeSelf)
            {
                canvas.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (page.text.Equals(text1))
                {
                    page.text = text2;
                }
                else if (page.text.Equals(text2))
                {
                    player.GetComponent<MainInventory>().TryAddItem("Yam Seed");
                    canvas.SetActive(false);
                    gotItems = true;
                }
            }
        }
        else if (canvas.activeSelf)
        {
            canvas.SetActive(false);
        }
    }
}
