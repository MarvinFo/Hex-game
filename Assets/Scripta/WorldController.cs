using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] private WorldGen worldGeneration;
    private Dictionary<(int, int, int), TileController> fields;
    private Dictionary<int, TileController[]> numberAssignment;
    public Material hoverMaterial;
    // Start is called before the first frame update
    void Start()
    {
        fields = worldGeneration.StartWorldGen();
        /*(int,int,int)[] test = FieldCalculation.CirclePattern((0,-3,3));
        foreach (var tes in test)
        {
            fields[tes].IndicateSelected(hoverMaterial);
        }*/
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


}
