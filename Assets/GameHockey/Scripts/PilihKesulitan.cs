using UnityEngine;
using UnityEngine.SceneManagement;

public class PilihKesulitan : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
        SceneManager.LoadScene("pilihLawan");          
        }
    }    
    public void PilihEasy()
    {
        PlayerPrefs.SetString("AILevel", "Easy");
        SceneManager.LoadScene("mainHockey");
    }

    public void PilihMedium()
    {
        PlayerPrefs.SetString("AILevel", "Medium");
        SceneManager.LoadScene("mainHockey");
    }

    public void PilihHard()
    {
        PlayerPrefs.SetString("AILevel", "Hard");
        SceneManager.LoadScene("mainHockey");
    }

    public void PilihLegend()
    {
        PlayerPrefs.SetString("AILevel", "Legend");
        SceneManager.LoadScene("mainHockey");
    }
}
