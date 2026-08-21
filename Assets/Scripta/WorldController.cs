using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] private WorldGen worldGeneration;
    private static Dictionary<(int, int, int), TileController> fields;
    private static Dictionary<int, HashSet<TileController>> fieldsWithNumbers;
    private Dictionary<int, TileController[]> numberAssignment;
    
    public static Material hoverMaterial;
    // Start is called before the first frame update
    void Start()
    {
        var temp = worldGeneration.StartWorldGen();
        fields = temp.Item1;
        fieldsWithNumbers = temp.Item2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void NextPlayer()
    {

    }
    public void RollField(int fieldNumber)
    {
        HashSet<TileController> tiles;
        fieldsWithNumbers.TryGetValue(fieldNumber, out tiles);
        foreach (TileController tileController in tiles)
        {
            tileController.IndicateSelected();
            tileController.NotifyPicked();
        }
    }

}
