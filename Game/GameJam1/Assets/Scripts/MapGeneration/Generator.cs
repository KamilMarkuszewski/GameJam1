using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generator
{
    public Map CreateMap()
    {
        Map map = new Map();
        map.GenerateWaterMap(512, 512);

        GenerateHorizontalRoads(map);
        GenerateVerticalRoads(map);



        //int[,] roads = new int[50, 3];
        //for (int i = 0; i < 50; i++)
        //{
        //    roads[i, 0] = UnityEngine.Random.Range(10, 500); //umieszenie?
        //    roads[i, 1] = roads[i, 0] + UnityEngine.Random.Range(2, 5); //szerokość?
        //    roads[i, 2] = UnityEngine.Random.Range(0, 2); 
        //    for (int j = 0; j < i; j++)
        //    {
        //        if (roads[i, 2] == roads[j, 2] &&
        //            ((roads[i, 0] - roads[j, 0]) * (roads[i, 0] - roads[j, 0]) < 25 ||
        //             (roads[i, 0] - roads[j, 1]) * (roads[i, 0] - roads[j, 1]) < 25 ||
        //             (roads[i, 1] - roads[j, 0]) * (roads[i, 1] - roads[j, 0]) < 25 ||
        //             (roads[i, 1] - roads[j, 1]) * (roads[i, 1] - roads[j, 1]) < 25))
        //        {
        //            i--;
        //            j = i;
        //        }
        //    }
        //}
        //for (int i = 0; i < 50; i++)
        //{
        //    for (int j = 0; j < 512; j++)
        //    {
        //        for (int k = roads[i, 0]; k < roads[i, 1]; k++)
        //        {
        //            if (roads[i, 2] == 0)
        //            {
        //                map.Put(j, k, MapElement.ROAD);
        //            }
        //            else
        //            {
        //                map.Put(k, j, MapElement.ROAD);
        //            }
        //        }
        //        if (roads[i, 2] == 0)
        //        {
        //            if (map.isRoad(j, roads[i, 0] - 1))
        //            {
        //                map.Put(j, roads[i, 0] - 1, MapElement.GRASS);
        //            }
        //            if (map.isRoad(j, roads[i, 1]))
        //            {
        //                map.Put(j, roads[i, 1], MapElement.GRASS);
        //            }
        //        }
        //        else
        //        {
        //            if (map.isRoad(roads[i, 0] - 1, j))
        //            {
        //                map.Put(roads[i, 0] - 1, j, MapElement.GRASS);
        //            }
        //            if (map.isRoad(roads[i, 1], j))
        //            {
        //                map.Put(roads[i, 1], j, MapElement.GRASS);
        //            }
        //        }
        //    }
        //}

        map.Save();
        return map;
    }

    private void GenerateHorizontalRoads(Map map)
    {
        for (int row = 0; row < map.RowsNumber(); row ++)
        {
            int numberOfNotRoadElements = UnityEngine.Random.Range(8, 25);
            row += numberOfNotRoadElements;
            if (row > map.RowsNumber())
            {
                break;
            }

            int numberOfRoadElements = UnityEngine.Random.Range(4, 6);
            if (row + numberOfRoadElements > map.RowsNumber())
            {
                break;
            }

            map.changeElementsInRow(row + 1, MapElement.WATER, MapElement.GRASS);
            for (int i = 2; i < numberOfRoadElements; i++)
            {
                map.changeElementsInRow(row + i, MapElement.WATER, MapElement.ROAD_HORIZONTAL);
            }
            map.changeElementsInRow(row + numberOfRoadElements, MapElement.WATER, MapElement.GRASS);

            row += numberOfRoadElements;
        }
    }

    private void GenerateVerticalRoads(Map map)
    {
        for (int column = 0; column < map.ColumnsNumber(); column++)
        {
            int numberOfNotRoadElements = UnityEngine.Random.Range(8, 25);
            column += numberOfNotRoadElements;
            if (column > map.ColumnsNumber())
            {
                break;
            }

            int numberOfRoadElements = UnityEngine.Random.Range(4, 6);
            if (column + numberOfRoadElements > map.ColumnsNumber())
            {
                break;
            }

            map.changeElementInColumn(column + 1, MapElement.WATER, MapElement.GRASS);
            for (int i = 2; i < numberOfRoadElements; i++)
            {
                map.changeElementInColumn(column + i, MapElement.WATER, MapElement.ROAD_VERTICAL);
                map.changeElementInColumn(column + i, MapElement.GRASS, MapElement.ROAD_VERTICAL);
                map.changeElementInColumn(column + i, MapElement.ROAD_HORIZONTAL, MapElement.ROAD_INTERSECTION);
            }
            map.changeElementInColumn(column + numberOfRoadElements, MapElement.WATER, MapElement.GRASS);

            column += numberOfRoadElements;
        }
    }
}
