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
    // just a reminder for myself; functionally useless
    public int h = 9;
    public int w = 15;

    // doors
    public bool upDoor = false;
    public bool downDoor = false;
    public bool leftDoor = false;
    public bool rightDoor = false;
    void Start()
    {
        if (upDoor)
        {

        }
    }

    void OpenDoor(Vector3Int position)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
