using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = new Vector3(player.position.x,player.position.y,-10);
    }
}
