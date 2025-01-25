using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public Transform Root;
    public GameObject GenericRoom;
    public GameObject HorizontalCorridor; // per ora no
    public int TotalRooms = 10;
    public int TreasureRooms = 2;
    List<RoomNodeData> nodes = new List<RoomNodeData>();
    void Start()
    {
        GenerateRoomTree();
        DrawRooms();
    }

    void GenerateRoomTree()
    {
        
        RoomNodeData initialNode = new RoomNodeData(new Vector2(0,0));
        nodes.Add(initialNode);

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
        }while (nodes[selectedRoomIndex].isFull() == false);

        RoomNodeData startingNode = nodes[selectedRoomIndex];

        List<Vector2> availableDirections = new List<Vector2>();

        if (startingNode.upOpen == false)
            availableDirections.Add(Vector2.up);

        if (startingNode.leftOpen == false)
        availableDirections.Add(Vector2.left);

        if (startingNode.downOpen == false)
        availableDirections.Add(Vector2.down);

        if (startingNode.rightOpen == false)
        availableDirections.Add(Vector2.right);

        int chosenDirectionIndex = Random.Range(0,availableDirections.Count);
        Vector2 chosenDirection = availableDirections[chosenDirectionIndex];

        RoomNodeData newNode = new RoomNodeData(startingNode.IdealPosition + chosenDirection);

        startingNode.openDoor(chosenDirection);
        newNode.openDoor(-chosenDirection);

        if (roomType != null)
            newNode.roomType = roomType;

        nodes.Add(newNode);
    }

    void DrawRooms()
    {
        for(int i = 0; i < nodes.Count; i++)
        {
            RoomNodeData node = nodes[i];

            GameObject roomObject = Instantiate(GenericRoom,Root);
            Room roomComponent = roomObject.GetComponent<Room>();
            roomObject.transform.position = new Vector3(node.IdealPosition.x * roomComponent.width,node.IdealPosition.y * roomComponent.height);

            if (node.leftOpen)
                roomComponent.leftDoor = true;

            if (node.rightOpen)
                roomComponent.rightDoor = true; 

            if (node.downOpen)
                roomComponent.downDoor = true;

            if (node.rightOpen)
                roomComponent.rightDoor = true; 

            roomComponent.OpenDoors();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
