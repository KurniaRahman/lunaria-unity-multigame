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
        Debug.Log("Keluar dari game."); // Kalau di editor, ini hanya log, karena Application.Quit baru berfungsi di build.
    }

    public void CancelExit()
    {
        exitPanel.SetActive(false);
    }
}
