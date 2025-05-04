using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelesaiUI : MonoBehaviour
{
    public Button tombolMainLagi;
    public Button tombolKembali;
    public Text teksSkor;

    void Start()
    {
        // Menampilkan skor akhir
        teksSkor.text = "Score\n" + Data.score.ToString();

        // Hubungkan tombol ke fungsi
        tombolMainLagi.onClick.AddListener(MainLagi);
        tombolKembali.onClick.AddListener(Kembali);
    }

    void MainLagi()
    {
        Data.score = 0;
        SceneManager.LoadScene("GamePlay"); 
    }

    void Kembali()
    {
        SceneManager.LoadScene("pilihGame"); 


}
}
