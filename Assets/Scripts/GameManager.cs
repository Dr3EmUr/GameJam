using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject root;
    public GameObject GenericRoom;
    public static GameObject HealthText;
    static Object[] Enemies;
    public static Vector3 CurrentPlayerPosition;
    public static Camera PlayerCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {                            
        Enemies = Resources.LoadAll("Enemies");
        HealthText = GameObject.Find("HealthText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject GetEnemyInstance()
    {
        Object randomEnemy = Enemies[Mathf.FloorToInt(Random.value *Enemies.Length)];
        var instance = GameObject.Instantiate(randomEnemy) as GameObject;
        return instance;
    }
}
