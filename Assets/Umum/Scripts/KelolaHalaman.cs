using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class KelolaHalaman : MonoBehaviour
{
    public bool isEscapeToExit;
    public bool isEscapeToPreviousScene;
    public bool isEscapeToTargetScene;
    public string targetScene;

    public AudioSource audioTombol;
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
            else if (isEscapeToTargetScene)
            {
                PindahKeScene(targetScene);
            }
        }
    }

    public void PindahKeScene(string namaScene)
    {
        StartCoroutine(MainkanSuaraLaluPindah(namaScene));
    }

    IEnumerator MainkanSuaraLaluPindah(string namaScene)
    {
        // Simpan nama scene sebelumnya
        SceneHistory.previousSceneName = SceneManager.GetActiveScene().name;

        if (audioTombol != null)
        {
            audioTombol.Play();
            yield return new WaitForSeconds(audioTombol.clip.length); // Tunggu suara selesai
        }

        SceneManager.LoadScene(namaScene);
    }
    public void KeluarGame()
    {
        Application.Quit();
    }
}

