using UnityEngine;
using System;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    [SerializeField] StandardWorldGenScriptableObject worldGenOption;
    [SerializeField] public Dictionary<int, (Material, GameRessourceMaterials.MaterialEnum, int)> materials;
    [SerializeField] private int[] amount = new int[6];
    void Start()
    {
        materials = new Dictionary<int, (Material, GameRessourceMaterials.MaterialEnum, int)>();
        for (int i = 0; i < 6; i++)
        {
            materials.Add(i, (worldGenOption.materials[i], worldGenOption.materialNames[i], worldGenOption.biomes[i]));
        }
    }

    public (Material, GameRessourceMaterials.MaterialEnum material) getBiome(int i)
    {
        (Material, GameRessourceMaterials.MaterialEnum, int) materialInfo;
        materials.TryGetValue(i, out materialInfo);
        if (materialInfo.Item3 > amount[i])
        {
            amount[i] ++;
            return (materialInfo.Item1, materialInfo.Item2 );
        }
        return (null, GameRessourceMaterials.MaterialEnum.Desert);
    }

    public (Material, GameRessourceMaterials.MaterialEnum material) getDessert()
    {
        (Material, GameRessourceMaterials.MaterialEnum, int) materialInfo;
        materials.TryGetValue(5, out materialInfo);
        return (materialInfo.Item1, materialInfo.Item2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
