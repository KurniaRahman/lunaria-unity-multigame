using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSelesaiUI : MonoBehaviour
{
    public Button tombolMainLagi;
    public Button tombolKembali;
    public Text teksSkor;
    public AudioSource audioTombol; // Tambahan: sumber audio tombol

    void Start()
    {
        // Menampilkan skor akhir
        teksSkor.text = "Score\n" + Data.score.ToString();

        // Hubungkan tombol ke fungsi
        tombolMainLagi.onClick.AddListener(() => StartCoroutine(MainLagi()));
        tombolKembali.onClick.AddListener(() => StartCoroutine(Kembali()));
    }

    IEnumerator MainLagi()
    {
        if (audioTombol != null)
            audioTombol.Play();

        yield return new WaitForSeconds(audioTombol != null ? audioTombol.clip.length : 0.2f);

        Data.score = 0;
        SceneManager.LoadScene("GamePlay"); 
    }

    IEnumerator Kembali()
    {
        if (audioTombol != null)
            audioTombol.Play();

        yield return new WaitForSeconds(audioTombol != null ? audioTombol.clip.length : 0.2f);

        SceneManager.LoadScene("pilihGame"); 
    }
}
