using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] private WorldGen worldGeneration;
    private static Dictionary<(int, int, int), TileController> fields;
    private Dictionary<int, TileController[]> numberAssignment;
    public static Material hoverMaterial;
    // Start is called before the first frame update
    void Start()
    {
        fields = worldGeneration.StartWorldGen();
        DrawCircle((2,-1,-1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void NextPlayer()
    {

    }
    private void DistributeAssetsToPlayers()
    {
        
    }
    public static void DrawCircle((int,int,int) startIndex)
    {
        ArrayList test = FieldCalculation.SpiralPattern(startIndex);
        foreach ((int, int, int) tes in test)
        {
           fields[tes].IndicateSelected(hoverMaterial);
        }
    }

}
