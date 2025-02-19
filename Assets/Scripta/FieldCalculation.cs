using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FieldCalculation : MonoBehaviour
{
    public static ArrayList CirclePattern((int, int, int) start)
    {
        ArrayList fieldsToSpawn = new ArrayList();
        int[] fieldCoords = new int[3] {start.Item1,start.Item2,start.Item3};
        fieldsToSpawn.Add((fieldCoords[0], fieldCoords[1], fieldCoords[2]));
        if(fieldCoords.SequenceEqual(new int[3] { 0, 0, 0 }))
        {
            return fieldsToSpawn;
        }
        int pointer = 0;
        if (!fieldCoords.Contains(0))
        {
            int largest = 0;
            for(int index = 0; index < 3; index++)
            {
                largest = Mathf.Abs(fieldCoords[index]) > Mathf.Abs(fieldCoords[largest]) ? index : largest;
            }
            for (; fieldCoords[(largest+1)%3] != 0;)
            {
                fieldCoords[(largest + 1) % 3] += Math.Sign(fieldCoords[largest] == 1 ? -1 : 1);
                fieldCoords[(largest + 2) % 3] += Math.Sign(fieldCoords[largest] == 1 ? 1 : -1);
                fieldsToSpawn.Add((fieldCoords[0], fieldCoords[1], fieldCoords[2]));
            }
            pointer = (largest + 2) % 3;
        }
        int[] startCoords = new int[3] { start.Item1, start.Item2, start.Item3 };
        for (int i = 0; true; i+=2)
        {
            for (; fieldCoords[(pointer + 1) % 3] != 0;)
            {
                fieldCoords[(pointer + 1) % 3] += (Math.Sign(fieldCoords[pointer]) == 1 ? 1 : -1);
                fieldCoords[(pointer + 2) % 3] += (Math.Sign(fieldCoords[pointer]) == 1 ? -1 : 1);
                if (fieldCoords.SequenceEqual(startCoords)) break;
                fieldsToSpawn.Add((fieldCoords[0], fieldCoords[1], fieldCoords[2]));
            }
            if (fieldCoords.SequenceEqual(startCoords)) break;
            pointer = (pointer + 2) % 3;
        }
        return fieldsToSpawn;

    }
    public static ArrayList SpiralPattern((int, int, int) start)
    {
        ArrayList fieldsToSpawn = new ArrayList();
        int[] fieldCoords = new int[3] { start.Item1, start.Item2, start.Item3 };
        fieldsToSpawn.AddRange(CirclePattern(start));
        int largest = 0;
        for (int index = 0; index < 3; index++)
        {
            largest = Mathf.Abs(fieldCoords[index]) > Mathf.Abs(fieldCoords[largest]) ? index : largest;
        }
        while (!fieldCoords.SequenceEqual(new int[3] {0,0,0}))
        {
            if(fieldCoords[(largest + 2) % 3] != 0)
            {
                fieldCoords[(largest + 2) % 3] += fieldCoords[(largest + 2) % 3] == 1 ? -1 : 1;
            }
            else
            {
                fieldCoords[(largest + 1) % 3] += fieldCoords[(largest + 2) % 3] == 1 ? -1 : 1;
            }
            fieldCoords[largest] -= 1;
            fieldsToSpawn.AddRange(CirclePattern((fieldCoords[0], fieldCoords[1], fieldCoords[2])));
        }
        return fieldsToSpawn;
    }
}
