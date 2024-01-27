using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTileController : MonoBehaviour
{
    private VillageTileController[] adhVillageTiles = new VillageTileController[6];
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAdhTile(VillageTileController contr)
    {
        for (int i = 0; i < adhVillageTiles.Length; i++)
        {
            if (adhVillageTiles[i] == null)
            {
                adhVillageTiles[i] = contr;
                return;
            }
        }
    }
}
