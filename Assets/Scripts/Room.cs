using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Tilemap WallsTilemap;
    public Tilemap FloorTilemap;
    public RuleTile FloorTile;
    public int h = 9;
    public int w = 15;
    void Start()
    {
        
        var bounds = FloorTilemap.cellBounds;
        Debug.Log(bounds.x +", " + bounds.xMax);
        Debug.Log(bounds.y +", " + bounds.yMax);


        var s = FloorTilemap.GetTile(new Vector3Int(0,0));
        Debug.Log($"{s == null}");

        for (int i = bounds.x; i < bounds.xMax; i++)
        {
            for (int j = bounds.y; j < bounds.yMax; j++)
            {
                var tile = FloorTilemap.GetTile(new Vector3Int(i,j));
                if(tile != null)
                {
                    Debug.Log($"{i},{j}");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
