using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField] private StandardWorldGenScriptableObject worldGenOption;
    private Dictionary<(int,int,int), TileController> fields;
    public Material oceanMaterial;
    private int fieldSize;
    public GameObject tile;
    public Vector3 q = new Vector3(0.35f, 0, 0);
    public Vector3 r = new Vector3(-0.5f, 0, -0.5f);
    public Vector3 s = new Vector3(-0.5f, 0, 0.5f);
    private int[] biomes = new int[] { 3, 4, 4, 4, 3, 1 };
    private int numberOfTiles;
    [SerializeField] Material[] materials;
    void Start()
    {
        
    }
    public Dictionary<(int, int, int), TileController> StartWorldGen()
    {
        fields = new Dictionary<(int, int, int), TileController>();
        numberOfTiles = worldGenOption.fieldSize;
        for (int i = (worldGenOption.fieldSize - 1) / 2; i > 0; i--)
        {
            numberOfTiles += ((5 - i) * 2);
        }
        GameObject spawnedTile;
        this.fieldSize = worldGenOption.fieldSize / 2 + 1;
        ArrayList fieldsToSpawn = new ArrayList();
        fieldsToSpawn.Add((0, 0, 0));
        int[] fieldCoords = new int[3];
        for (int x = 1, y = -1; x < this.fieldSize + 1; x++, y--)
        {
            fieldCoords[0] = 0;
            fieldCoords[1] = x;
            fieldCoords[2] = y;
            bool negative = fieldCoords[2] < 0 ? true : false;
            int[] startCoords = new int[3];
            for (int i = 0; !fieldCoords.SequenceEqual(startCoords); i++)
            {
                startCoords = new int[3] { 0, x, y };
                negative = fieldCoords[(i - 1 + 3) % 3] < 0 ? true : false;
                for (; fieldCoords[(i + 1) % 3] != 0;)
                {
                    fieldsToSpawn.Add((fieldCoords[0], fieldCoords[1], fieldCoords[2]));
                    fieldCoords[(i) % 3] += negative ? 1 : -1;
                    fieldCoords[(i + 1) % 3] += negative ? -1 : 1;
                }
            }

        }
        foreach ((int, int, int) fiel in fieldsToSpawn)
        {
            Debug.Log(fiel);
        }
        foreach ((int,int,int) fiel in fieldsToSpawn)
        {
            if (Mathf.Sign((q * fiel.Item1).x) == 0)
            {
                spawnedTile = Instantiate(tile, q * fiel.Item1 - r * fiel.Item2 - s * fiel.Item3, Quaternion.identity);
            }
            else
            {
                spawnedTile = Instantiate(tile, q * fiel.Item1 + r * fiel.Item2 + s * fiel.Item3, Quaternion.identity);
            }
            if (Mathf.Abs(fiel.Item1) > fieldSize - 1 || Mathf.Abs(fiel.Item2) > fieldSize - 1 || Mathf.Abs(fiel.Item3) > fieldSize - 1)
            {
                spawnedTile.GetComponent<MeshRenderer>().material = oceanMaterial;
                spawnedTile.tag = "ocean";
            }
            else
            {
                spawnedTile.GetComponent<MeshRenderer>().material = RandomBiomePicker(0);
            }
            spawnedTile.GetComponent<TileController>().number = (fiel.Item1, fiel.Item2, fiel.Item3);
            fields.Add((fiel.Item1, fiel.Item2, fiel.Item3), spawnedTile.GetComponent<TileController>());
            spawnedTile.GetComponent<TileController>().SetCoordinates((fiel.Item1, fiel.Item2, fiel.Item3));

        }
        foreach(TileController hex in fields.Values)
        {
            hex.GenPath();
        }
        foreach (TileController hex in fields.Values)
        {
            hex.GenVillageTile();
        }
        return fields;
    }
    private Material RandomBiomePicker(int recursionLevel)
    {
        if (recursionLevel > numberOfTiles )
        {
            return materials[5];
        }
        int tempRand = UnityEngine.Random.Range(0,6);    
        if (biomes[tempRand] == 0)
        {
            return RandomBiomePicker(recursionLevel+1);
        }
        biomes[tempRand]--;
        return materials[tempRand];
    }   
}
