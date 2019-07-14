using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Translator : MonoBehaviour {

    public Tile[] Tiles;
    void Awake()
    {
        Vector3Int NegativePosition = new Vector3Int(-256,-256, 0 );
        var Gen = new Generator();
        Gen.CreateMap();
        Tilemap Map = FindObjectOfType<Tilemap>();
        string[] Line = new string[512];
        using (StreamReader file = new StreamReader("Map.txt"))
        {
            string ln;
            int collumn = 0;

            while ((ln = file.ReadLine()) != null)
            {
                Line = ln.Split(',');
                for(int i = 0; i < 511; i++)
                {
                    if (Line[i] == "0")
                    {
                        Map.SetTile(new Vector3Int(collumn, i, 0)+ NegativePosition, Tiles[1+ Random.Range(0,3)]);
                    }
                    if (Line[i] == "1")
                    {
                        Map.SetTile( new Vector3Int(collumn,i,0)+NegativePosition, Tiles[4]);
                    }
                    if (Line[i] == "2")
                    {
                        Map.SetTile(new Vector3Int(collumn, i, 0)+ NegativePosition, Tiles[0]);
                    }
                }
                collumn++;
            }
            file.Close();
        }
    }
}
