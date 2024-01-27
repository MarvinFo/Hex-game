using System.Collections;
using System.Collections.Generic;
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
    public static (int,int,int)[] CirclePattern((int, int, int) start)
    {
        (int, int, int)[] fields = new (int, int, int)[20];
        int[] coords = new int[3] { start.Item1, start.Item2, start.Item3 };
        (int, int, int) currentField = (0, 0, 0);
        int[] tempCalc = new int[] { start.Item1, start.Item2, start.Item3 };
        bool negative = true;
        (int,int) maxValue = (Mathf.Abs(start.Item1),0);
        fields[0] = start;
        for (int i = 0; i < coords.Length; i++)
        {
            maxValue = maxValue.Item1 < Mathf.Abs(coords[i]) ? (Mathf.Abs(coords[i]),i) : maxValue;
            if(coords[i] == 0)
            {
                
                for(int j=i, indexOut = 0; indexOut < 20 ;j++, indexOut++)
                {
                    
                    tempCalc[j % 3] = negative ? 1 : -1;
                    tempCalc[(j - 1 + 3) % 3] = negative ? -1 : +1;
                    currentField = (tempCalc[0], tempCalc[1], tempCalc[2]);
                    fields[indexOut] = currentField;
                    negative = Mathf.Sign(coords[(j + 1) % 3]) < 0;
                    /*for (; !(tempCalc[(j-1+3)%3] == 0) ;) { 
                        tempCalc[j%3] = negative ? 1:-1;
                        tempCalc[(j-1+3)%3] = negative ? -1:+1;
                        currentField = (tempCalc[0], tempCalc[1], tempCalc[2]);
                        fields[indexOut] = currentField;
                        Debug.Log(currentField);
                        Debug.Log(start);
                    }*/
                }
                return fields;
            }

        }
        /*for (int j = maxValue.Item2, indexOut=0; !currentField.Equals(start); j++,indexOut++)
        {
            negative = Mathf.Sign(coords[(j + 1) % 3]) < 0;
            for (; !(tempCalc[(j + 1) % 3] == 0);)
            {
                tempCalc[(j+1) % 3] = negative ? 1 : -1;
                tempCalc[(j+2) % 3] = negative ? -1 : +1;
                currentField = (tempCalc[0], tempCalc[1], tempCalc[2]);
                fields[indexOut] = currentField;
            }
        }*/
        return fields;

    }
    public static void SpiralPattern((int, int, int) start)
    {

    }
}
