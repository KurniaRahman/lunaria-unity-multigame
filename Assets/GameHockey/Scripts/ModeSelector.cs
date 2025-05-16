using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    public AudioSource audioTombol; // Tambahan

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (audioTombol != null)
                audioTombol.Play();

            StartCoroutine(PindahSceneDenganDelay("pilihGame"));
        }
    }

    public void ModePvsP()
    {
        if (audioTombol != null)
            audioTombol.Play();

        PlayerPrefs.SetString("ModeGame", "PvP");
        StartCoroutine(PindahSceneDenganDelay("mainHockey"));
    }

    public void ModePvsAI()
    {
        if (audioTombol != null)
            audioTombol.Play();

        PlayerPrefs.SetString("ModeGame", "PvAI");
        StartCoroutine(PindahSceneDenganDelay("pilihKesulitan"));
    }

    private System.Collections.IEnumerator PindahSceneDenganDelay(string namaScene)
    {
        yield return new WaitForSeconds(audioTombol != null ? audioTombol.clip.length : 0.2f);
        SceneManager.LoadScene(namaScene);
    }
}
