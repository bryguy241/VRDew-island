using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateTiles()
    {
        foreach (TileSystem ts in transform.GetComponentsInChildren<TileSystem>())
        {

            ts.GrowTile();
            ts.SaveTileData();
            ts.ReadTileData();
        }

    }
}
