using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldCalculation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static ArrayList CirclePattern((int, int, int) start)
    {
        ArrayList fieldsToSpawn = new ArrayList();
        int[] fieldCoords = new int[3] {start.Item1,start.Item2,start.Item3};
        int[] startCoords = new int[3];
        bool negative = fieldCoords[2] < 0 ? true : false;
        bool startsWithZero = false;
        (int,int) indexToStart = (Mathf.Abs(start.Item1),0);
        for (int i = 0; i < fieldCoords.Length; i++)
        {
            if (Mathf.Abs(fieldCoords[i]) > Mathf.Abs(indexToStart.Item1))
            {
                indexToStart = (Mathf.Abs(fieldCoords[i]), i);
            }
            if (fieldCoords[i] == 0)
            {
                startsWithZero = true;
            }
        }
        if (!startsWithZero) 
        {
            negative = (indexToStart.Item1 + 1) % 3 < 0 ? true : false;
            for (; fieldCoords[(indexToStart.Item2+1) % 3] != 0;)
            {
                fieldsToSpawn.Add((fieldCoords[0], fieldCoords[1], fieldCoords[2]));
                fieldCoords[(indexToStart.Item2+1) % 3] += negative ? 1 : -1;
                fieldCoords[(indexToStart.Item2 + 2) % 3] += negative ? -1 : 1;
            }
        }
        for (int i = 0; !fieldCoords.SequenceEqual(startCoords); i+=2)
        {
            startCoords = new int[3] { start.Item1, start.Item2, start.Item3 };
            negative = fieldCoords[(i - 1 + 3) % 3] < 0 ? true : false;
            for (; fieldCoords[(i + 2) % 3] != 0;)
            {
                fieldsToSpawn.Add((fieldCoords[0], fieldCoords[1], fieldCoords[2]));
                fieldCoords[(i) % 3] += negative ? -1 : 1;
                fieldCoords[(i + 2) % 3] += negative ? 1 : -1;
                if (fieldCoords.SequenceEqual(startCoords))
                {
                    break;
                }
            }
        }
        return fieldsToSpawn;

    }
    public static void SpiralPattern((int, int, int) start)
    {

    }
}
