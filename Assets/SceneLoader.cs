using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif 

public class SceneLoader : MonoBehaviour{
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseGame();
        }

        else if(Input.GetKeyDown(KeyCode.R)) {
            RestartGameScene();
        }
    }

    private void RestartGameScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CloseGame(){
        Application.Quit();
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #endif
    }
}
