using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class VillageTileController : GameTileController
{
    public LayerMask pathLayer;
    public LayerMask tileLayer;
    public Transform spawn;
    public pathController[] paths = new pathController[3];
    [SerializeField] public int playerID = -1;
    [SerializeField] private GameObject dwelling;
    private ResourceManager resourceManager;
    void Start()
    {
        resourceManager = FindFirstObjectByType<ResourceManager>();
        foreach (Collider col in Physics.OverlapSphere(transform.position, 0.1f))
        {
            
            int numPath = 0;
            if (col.gameObject.layer == pathLayer)
            {
                paths[numPath] = col.gameObject.GetComponent<pathController>();
            }
            if (tileLayer == (tileLayer | (1 << col.gameObject.layer)))
            {
                col.gameObject.GetComponent<TileController>().AddNotify(this);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddVillage(int playerID)
    {
        this.playerID = playerID;
    }
    public void NotifyPicked(GameRessourceMaterials.MaterialEnum material)
    {
        if (playerID != -1)
        {
            resourceManager.AwardAssets(playerID);
        }
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
