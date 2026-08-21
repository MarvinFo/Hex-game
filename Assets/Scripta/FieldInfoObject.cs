using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class FieldInfoObject
{
    private Dictionary<int, HashSet<int>> playerValues;
    private int material;
    public FieldInfoObject()
    {
        playerValues = new Dictionary<int, HashSet<int>>();
    }
    public void Add((int,int) player)
    {
        HashSet<int> quant;
        playerValues.TryGetValue(player.Item1, out quant);
        if (quant != null) 
        { 
            quant.Add(player.Item2);
            playerValues[player.Item1] = quant;
        }
        else
        {
            quant = new HashSet<int>() {  player.Item2 };
            playerValues.Add(player.Item1,quant);
        }

        
    }
    public void AddAnalyseTile(TileController tileController)
    {
        return;
    }
}
