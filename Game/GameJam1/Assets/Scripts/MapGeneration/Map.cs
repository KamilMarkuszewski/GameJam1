using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MapElement
{
    public const string WATER = "W";
    public const string ROAD_VERTICAL = "RV";
    public const string ROAD_HORIZONTAL = "RH";
    public const string ROAD_INTERSECTION = "RI";
    public const string GRASS = "G";
}

public class Map {

    private string[,] MapElements;

    public void Save()
    {
        System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("Map.txt");
        string output = "";
        for (int i = 0; i < MapElements.GetUpperBound(0); i++)
        {
            for (int j = 0; j < MapElements.GetUpperBound(1); j++)
            {
                output += MapElements[i, j];
                if (j < MapElements.GetUpperBound(1) - 1)
                {
                    output += ",";
                }
            }
            streamWriter.WriteLine(output);
            output = "";
        }
        streamWriter.Close();
    }

    internal bool isType(int row, int column, string type)
    {
        return MapElements[row, column] == type;
    }

    internal string Element(int row, int column)
    {
        return MapElements[row, column];
    }

    internal int RowsNumber()
    {
        return MapElements.GetUpperBound(0);
    }

    internal int ColumnsNumber()
    {
        return MapElements.GetUpperBound(1);
    }

    public void Put(int row, int column, string mapElement)
    {
        MapElements[row, column] = mapElement;
    }

    //public bool isRoad(int row, int column)
    //{
    //    return MapElements[row, column] == MapElement.ROAD_VERTICAL;
    //}

    public void GenerateWaterMap(int width, int hight)
    {
        MapElements = new string[width, hight];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < hight; j++)
            {
                MapElements[i, j] = MapElement.WATER;
            }
        }        
    }

    internal void changeElementsInRow(int row, string fromElement, string toElement)
    {
        for (int column = 0; column < ColumnsNumber(); column++)
        {
            if (isType(row, column, fromElement)){
                MapElements[row, column] = toElement;
            }
        }
    }

    internal void changeElementInColumn(int column, string fromElement, string toElement)
    {
        for (int row = 0; row < ColumnsNumber(); row++)
        {
            if (isType(row, column, fromElement))
            {
                MapElements[row, column] = toElement;
            }
        }
    }
}
