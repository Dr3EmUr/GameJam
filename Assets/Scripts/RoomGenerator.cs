using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public Transform Root;
    public GameObject GenericRoom;
    public GameObject PlayerPrefab;
    public GameObject HorizontalCorridor; // per ora no
    public int TotalRooms = 10;
    public int TreasureRooms = 2;
    Dictionary<Vector2,RoomNodeData> nodes = new Dictionary<Vector2,RoomNodeData>();
    private Vector2 startingRoomPosition;
    void Start()
    {
        GenerateRoomTree();
        DrawRooms();
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject player = Instantiate(PlayerPrefab);
        player.transform.position = startingRoomPosition;
    }

    void GenerateRoomTree()
    {
        
        RoomNodeData initialNode = new RoomNodeData(new Vector2(0,0));
        nodes.Add(initialNode.IdealPosition,initialNode);

        int normalRooms = TotalRooms - TreasureRooms - 1 - 1; // (- boss room - initial room)

        for (int i = 0; i < normalRooms; i++)
        {
            GenerateNodeData("Generic");
        }

        for (int i = 0; i < TreasureRooms; i++)
        {
            GenerateNodeData("Treasure");
        }

        GenerateNodeData("Boss");
    }

    void GenerateNodeData(string roomType)
    {
        int selectedRoomIndex = -1;

        do
        {
            selectedRoomIndex = Random.Range(0,nodes.Count);
        }while (nodes.ElementAt(selectedRoomIndex).Value.isFull() == true);

        RoomNodeData startingNode = nodes.ElementAt(selectedRoomIndex).Value;

        List<Vector2> availableDirections = new List<Vector2>();

        if (nodes.ContainsKey(startingNode.IdealPosition + Vector2.up) == false)
            availableDirections.Add(Vector2.up);

        if (nodes.ContainsKey(startingNode.IdealPosition + Vector2.right) == false)
            availableDirections.Add(Vector2.right);

        if (nodes.ContainsKey(startingNode.IdealPosition + Vector2.down) == false)
            availableDirections.Add(Vector2.down);

        if (nodes.ContainsKey(startingNode.IdealPosition + Vector2.left) == false)
            availableDirections.Add(Vector2.left);

        Debug.Log(availableDirections.Count);

        int chosenDirectionIndex = Random.Range(0,availableDirections.Count);
        Vector2 chosenDirection = availableDirections[chosenDirectionIndex];

        RoomNodeData newNode = new RoomNodeData(startingNode.IdealPosition + chosenDirection);

        startingNode.openDoor(chosenDirection);
        newNode.openDoor(-chosenDirection);

        if (roomType != null)
            newNode.roomType = roomType;

        nodes.Add(newNode.IdealPosition,newNode);
    }

    void DrawRooms()
    {
        for(int i = 0; i < nodes.Count; i++)
        {
            var pair = nodes.ElementAt(i);
            RoomNodeData node = pair.Value;

            GameObject roomObject = Instantiate(GenericRoom,Root);
            Room roomComponent = roomObject.GetComponent<Room>();
            roomObject.transform.position = new Vector3(node.IdealPosition.x * roomComponent.width,node.IdealPosition.y * roomComponent.height);

            if (node.leftOpen)
                roomComponent.leftDoor = true;

            if (node.rightOpen)
                roomComponent.rightDoor = true; 

            if (node.downOpen)
                roomComponent.downDoor = true;

            if (node.upOpen)
                roomComponent.upDoor = true; 

            roomComponent.OpenDoors();

            if (pair.Key.x == 0 && pair.Key.y == 0)
                startingRoomPosition = roomObject.transform.position + new Vector3(roomComponent.width/2,roomComponent.height/2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
