using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject root;
    public GameObject GenericRoom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {                            
        var one = Instantiate(GenericRoom,root.transform);
        one.transform.position =new Vector3(0,0);

        var two = Instantiate(GenericRoom,root.transform);
        two.transform.position =new Vector3(0,8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
