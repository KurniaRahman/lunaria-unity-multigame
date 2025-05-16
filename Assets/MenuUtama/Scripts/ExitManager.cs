using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public GameObject exitPanel;
    public AudioSource audioTombol; 

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
        if (audioTombol != null)
            audioTombol.Play();

        exitPanel.SetActive(!exitPanel.activeSelf);
    }

    public void ExitGame()
    {
        if (audioTombol != null)
            audioTombol.Play();

        // Tambah sedikit delay agar suara sempat terdengar sebelum quit
        StartCoroutine(TungguDanKeluar());
    }

    public void CancelExit()
    {
        if (audioTombol != null)
            audioTombol.Play();

        exitPanel.SetActive(false);
    }

    private System.Collections.IEnumerator TungguDanKeluar()
    {
        yield return new WaitForSeconds(audioTombol != null ? audioTombol.clip.length : 0.2f);

        Application.Quit();
        Debug.Log("Keluar dari game."); 

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}