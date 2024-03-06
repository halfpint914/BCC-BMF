using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif 

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseGame();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGameScene();
        }
        // Check for S key press to spawn prefabs
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnPrefabsAbovePlayer();
        }
    }

    private void SpawnPrefabsAbovePlayer()
    {
        if (prefabToSpawn == null || playerTransform == null)
        {
            Debug.LogWarning("Prefab or Player Transform is not assigned in the inspector");
            return;
        }

        for (int i = 0; i < 10; i++)
        {
            // Calculate spawn position 5 units above the player
            Vector3 spawnPosition = playerTransform.position + Vector3.up * 2;
            // Instantiate the prefab at the spawn position with no rotation
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private void RestartGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CloseGame()
    {
        Application.Quit();
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #endif
    }
}
