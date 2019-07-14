using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;


public class TileSearcher
{
    private readonly string[] water_tile = new string[3] { "water_tile_0", "water_tile_1", "water_tile_2" };
    private readonly string grass = "grass";
    private readonly string road_horizontal = "road_up";
    private readonly string road_vertical = "road_side";
    private readonly string road_intersection = "road_intersection";


    private Tile[] Tiles;

    public TileSearcher(Tile[] TilesArr)
    {
        this.Tiles = TilesArr;
    }

    private Tile getTileByName(string name)
    {
        return Tiles.First(f => f.name == name);
    }

    public Tile getRandomWaterTile()
    {
        return getTileByName(water_tile[Random.Range(0, 2)]);
    }

    public Tile getGrassTile()
    {
        return getTileByName(grass);
    }

    public Tile getRoadHorizontalTile()
    {
        return getTileByName(road_horizontal);
    }

    public Tile getRoadVerticalTile()
    {
        return getTileByName(road_vertical);
    }

    public Tile getRoadIntersectionTile()
    {
        return getTileByName(road_intersection);
    }

}

public class Translator : MonoBehaviour {

    public Tile[] Tiles;

    void Awake()
    {
        Vector3Int NegativePosition = new Vector3Int(-256,-256, 0 );
        var Gen = new Generator();
        Map map = Gen.CreateMap();
        Tilemap tilemap = FindObjectOfType<Tilemap>();
        TileSearcher searcher = new TileSearcher(Tiles);
        
        for (int row = 0; row< map.RowsNumber(); row++)
        {
            for (int column = 0; column < map.ColumnsNumber(); column++)
            {
                switch (map.Element(row, column))
                {
                    case MapElement.WATER:
                        tilemap.SetTile(new Vector3Int(row, column, 0) + NegativePosition, searcher.getRandomWaterTile());
                        break;
                    case MapElement.ROAD_HORIZONTAL:
                        tilemap.SetTile(new Vector3Int(row, column, 0) + NegativePosition, searcher.getRoadHorizontalTile());
                        break;
                    case MapElement.ROAD_VERTICAL:
                        tilemap.SetTile(new Vector3Int(row, column, 0) + NegativePosition, searcher.getRoadVerticalTile());
                        break;
                    case MapElement.ROAD_INTERSECTION:
                        tilemap.SetTile(new Vector3Int(row, column, 0) + NegativePosition, searcher.getRoadIntersectionTile());
                        break;
                    case MapElement.GRASS:
                        tilemap.SetTile(new Vector3Int(row, column, 0) + NegativePosition, searcher.getGrassTile());
                        break;
                }                
            }
        }
        
    }
}
