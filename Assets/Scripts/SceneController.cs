using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("Scene Names")]
    [SerializeField] private string introScene = "Video"; // Nome della scena dell'intro
    [SerializeField] private string gameScene = "SampleScene"; // Nome della scena principale

    [Header("Intro Settings")]
    [SerializeField] private float introDuration = 63f; // Durata dell'intro in secondi

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadGameScene();
        }
    }

    void Start()
    {
        // Avvia il timer per passare alla scena successiva
        Invoke(nameof(LoadGameScene), introDuration);
    }

    private void LoadGameScene()
    {
        // Carica la scena principale del gioco
        SceneManager.LoadScene(gameScene);
    }

    // Metodo pubblico per passare direttamente a una scena
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
