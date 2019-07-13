using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator
{
    public void CreateMap()
    {
        int[,] Map = new int[512, 512];
        int[,] roads = new int[50, 3];
        for (int i = 0; i < 50; i++)
        {
            roads[i, 0] = UnityEngine.Random.Range(10, 500);
            roads[i, 1] = roads[i, 0] + UnityEngine.Random.Range(2, 5);
            roads[i, 2] = UnityEngine.Random.Range(0, 2);
            for (int j = 0; j < i; j++)
            {
                if (roads[i, 2] == roads[j, 2] &&
                    ((roads[i, 0] - roads[j, 0]) * (roads[i, 0] - roads[j, 0]) < 25 ||
                     (roads[i, 0] - roads[j, 1]) * (roads[i, 0] - roads[j, 1]) < 25 ||
                     (roads[i, 1] - roads[j, 0]) * (roads[i, 1] - roads[j, 0]) < 25 ||
                     (roads[i, 1] - roads[j, 1]) * (roads[i, 1] - roads[j, 1]) < 25))
                {
                    i--;
                    j = i;
                }
            }
        }
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 512; j++)
            {
                for (int k = roads[i, 0]; k < roads[i, 1]; k++)
                {
                    if (roads[i, 2] == 0)
                    {
                        Map[j, k] = 1;
                    }
                    else
                    {
                        Map[k, j] = 1;
                    }
                }
                if (roads[i, 2] == 0)
                {
                    if (Map[j, roads[i, 0] - 1] != 1)
                    {
                        Map[j, roads[i, 0] - 1] = 2;
                    }
                    if (Map[j, roads[i, 1]] != 1)
                    {
                        Map[j, roads[i, 1]] = 2;
                    }
                }
                else
                {
                    if (Map[roads[i, 0] - 1,j] != 1)
                    {
                        Map[roads[i, 0] - 1, j] = 2;
                    }
                    if (Map[roads[i, 1] , j] != 1)
                    {
                        Map[roads[i, 1] , j] = 2;
                    }
                }
            }
        }
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 512; j++)
            {
                Map[i, j] = 0;
                Map[511 -i, j] = 0;
                Map[j, i] = 0;
                Map[j, 511 - i] = 0;
            }
        }

        System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("Map.txt");
        string output = "";
        for (int i = 0; i < Map.GetUpperBound(0); i++)
        {
            for (int j = 0; j < Map.GetUpperBound(1); j++)
            {
                output += Map[i, j].ToString();
                if (j < Map.GetUpperBound(1) - 1)
                {
                    output += ",";
                }
            }
            streamWriter.WriteLine(output);
            output = "";
        }
        streamWriter.Close();
    }
}
