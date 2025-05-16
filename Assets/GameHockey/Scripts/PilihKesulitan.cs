using UnityEngine;
using UnityEngine.SceneManagement;

public class PilihKesulitan : MonoBehaviour
{
    public AudioSource audioTombol; // Tambahan untuk suara

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (audioTombol != null)
                audioTombol.Play();

            StartCoroutine(PindahSceneDenganDelay("pilihLawan"));
        }
    }

    public void PilihEasy()
    {
        PlayerPrefs.SetString("AILevel", "Easy");
        PlaySoundAndLoadScene("mainHockey");
    }

    public void PilihMedium()
    {
        PlayerPrefs.SetString("AILevel", "Medium");
        PlaySoundAndLoadScene("mainHockey");
    }

    public void PilihHard()
    {
        PlayerPrefs.SetString("AILevel", "Hard");
        PlaySoundAndLoadScene("mainHockey");
    }

    public void PilihLegend()
    {
        PlayerPrefs.SetString("AILevel", "Legend");
        PlaySoundAndLoadScene("mainHockey");
    }

    void PlaySoundAndLoadScene(string namaScene)
    {
        if (audioTombol != null)
            audioTombol.Play();

        StartCoroutine(PindahSceneDenganDelay(namaScene));
    }

    System.Collections.IEnumerator PindahSceneDenganDelay(string namaScene)
    {
        yield return new WaitForSeconds(audioTombol != null ? audioTombol.clip.length : 0.2f);
        SceneManager.LoadScene(namaScene);
    }
}
