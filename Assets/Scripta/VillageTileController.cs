using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageTileController : GameTileController
{
    public LayerMask pathLayer;
    public LayerMask tileLayer;
    public Transform spawn;
    public pathController[] paths = new pathController[3];
    // Start is called before the first frame update
    void Start()
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, 20f))
        {
            int numPath = 0;
            if(col.gameObject.layer == pathLayer || col.gameObject.layer == tileLayer)
            {
                col.gameObject.GetComponent<GameTileController>().SetAdhTile(this);
                if(col.gameObject.layer == pathLayer)
                {
                    paths[numPath] = col.gameObject.GetComponent<pathController>();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVillage()
    {
        foreach(pathController con in paths)
        {
            if (con.hasVillageOnEnd)
            {
                return;
            }
        }
        foreach (pathController con in paths)
        {
            con.hasVillageOnEnd = true;
        }
    }
}
