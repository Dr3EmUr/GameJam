using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

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
        GetRandomPosition();
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
            OpenDoor(new Vector3Int(0,4));
        
        if (rightDoor)
            OpenDoor(new Vector3Int(14,4));
    }

    public Vector2 GetRandomPosition()
    {
        Vector2 minPos = transform.position + new Vector3(2,2);
        Vector2 maxPos = transform.position + new Vector3(width,height) - new Vector3(2,2);

        float randomX = Random.Range(minPos.x,maxPos.x);
        float randomY = Random.Range(minPos.y,maxPos.y);

        Vector2 finalPos = new Vector2(randomX,randomY);

        return finalPos;
    }
}
