using UnityEngine;

class RoomNodeData
{
    public Vector2 IdealPosition;
    public bool upOpen;
    public bool downOpen;
    public bool leftOpen;
    public bool rightOpen;
    public string roomType = "Generic";

    public void openDoor(Vector2 direction)
    {
        if (direction.x == 0 && direction.y == 1)
            upOpen = true;

        if (direction.x == 0 && direction.y == -1)
            downOpen = true;
        
        if (direction.x == 1 && direction.y == 0)
            rightOpen = true;
        
        if (direction.x == -1 && direction.y == 0)
            leftOpen = true;
    }

    public bool isFull()
    {
        return upOpen == true && downOpen == true && leftOpen == true && rightOpen == true;
    }
    

    public RoomNodeData(Vector2 IdealPosition)
    {
        this.IdealPosition = IdealPosition;
    }

}