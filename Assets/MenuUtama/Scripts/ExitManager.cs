using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public GameObject exitPanel;

    void Start()
    {
        if (exitPanel != null)
            exitPanel.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleExitPanel();
        }
    }

    public void ToggleExitPanel()
    {
        exitPanel.SetActive(!exitPanel.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Keluar dari game."); 
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }

    public void CancelExit()
    {
        exitPanel.SetActive(false);
    }
}
