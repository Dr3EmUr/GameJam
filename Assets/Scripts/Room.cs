using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Tilemap WallsTilemap;
    public Tilemap FloorTilemap;
    public TileBase FloorTile;
    public TileBase WallTile;
    public int height = 9;
    public int width = 15;

    // doors
    public bool upDoor = false;
    public bool downDoor = false;
    public bool leftDoor = false;
    public bool rightDoor = false;
    void Start()
    {
        OpenDoors();
    }

    void OpenDoor(Vector3Int position)
    {
        WallsTilemap.SetTile(position,null);
        FloorTilemap.SetTile(position,Instantiate(FloorTile));

    }

    public void OpenDoors()
    {
        if (upDoor)
            OpenDoor(new Vector3Int(7,8));

        if (downDoor)
            OpenDoor(new Vector3Int(7,0));

        if (leftDoor)
            OpenDoor(new Vector3Int(0,5));
        
        if (rightDoor)
            OpenDoor(new Vector3Int(14,5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
