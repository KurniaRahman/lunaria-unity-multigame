using UnityEngine;
using UnityEngine.SceneManagement;


public class KelolaHalaman : MonoBehaviour
{
    public bool isEscapeToExit;
    public bool isEscapeToPreviousScene;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToPreviousScene && !string.IsNullOrEmpty(SceneHistory.previousSceneName))
            {
                SceneManager.LoadScene(SceneHistory.previousSceneName);
            }
            else if (isEscapeToExit)
            {
                Application.Quit();
            }
        }
    }

    public void PindahKeScene(string namaScene)
    {
        // Simpan scene saat ini sebelum pindah
        SceneHistory.previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(namaScene);
    }
    public void KeluarGame()
    {
        Application.Quit();
    }
}

