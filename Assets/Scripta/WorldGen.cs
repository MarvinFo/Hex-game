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
    public (int,int,int) startIndex = (2,-2,0);
    public GameObject tile;
    public Vector3 q = new Vector3(0.35f, 0, 0);
    public Vector3 r = new Vector3(-0.5f, 0, -0.5f);
    public Vector3 s = new Vector3(-0.5f, 0, 0.5f);
    private int[] biomes = new int[] { 3, 4, 4, 4, 3, 1 };
    private static readonly int[] fieldNumbers = { 5, 2, 6, 3, 8, 10, 9, 12, 11, 4, 8, 10, 9, 4, 5, 6, 3, 11 };
    private int numberOfTiles;
    [SerializeField] Material[] materials;
    void Start()
    {
        
    }
    public (Dictionary<(int, int, int), TileController>,Dictionary<int,HashSet<TileController>>) StartWorldGen()
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
                Material material = RandomBiomePicker(0);
                if (material.name.Equals("Desert"))
                {
                    spawnedTile.GetComponent<TileController>().isDesert = true;
                }
                spawnedTile.GetComponent<MeshRenderer>().material = material;
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
        Dictionary<int, HashSet<TileController>> fieldsWithNumbers = FieldNumberGen();
        return (fields,fieldsWithNumbers);
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
    private Dictionary<int, HashSet<TileController>> FieldNumberGen()
    {
        Dictionary<int, HashSet<TileController>> fieldsWithNumbers = new Dictionary<int, HashSet<TileController>>();
        ArrayList test = FieldCalculation.SpiralPattern(startIndex);
        int i = 0;
        foreach ((int, int, int) tes in test)
        {
            HashSet<TileController> field = new HashSet<TileController>();
            if (fields[tes].isDesert) { continue; }
            fields[tes].SetNumber(fieldNumbers[i]);
            Debug.Log(i);
            Debug.Log(tes.ToString());
            fieldsWithNumbers.Remove(fieldNumbers[i], out field);
            if(field == null)
            {
                field = new HashSet<TileController>();
            }
            field.Add(fields[tes]);
            fieldsWithNumbers.Add(fieldNumbers[i], field);
            i++;
        }
        return fieldsWithNumbers;
    }
}
