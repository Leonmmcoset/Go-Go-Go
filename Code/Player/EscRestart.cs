using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EscRestart : MonoBehaviour
{
    void Update()
    {
        // If the ESC key is pressed, exit the application or leave the game scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        // If the R key is pressed, reload the current scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }

        // If the F key is pressed, delete save data
        if (Input.GetKeyDown(KeyCode.F))
        {
            DeleteSaveData();
        }
    }

    void ReloadScene()
    {
        // Get the index of the current scene and reload it
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void DeleteSaveData()
    {
        // Construct the full path to the save file using Path.Combine
        string savePath = Path.Combine(Application.persistentDataPath, "Save", "SaveData.sav");

        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save data deleted!");
        }
        else
        {
            Debug.Log("No save data found!");
        }
    }
}