using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
        SceneManager.LoadScene("pilihGame");          
        }
    }
    public void ModePvsP()
    {
        PlayerPrefs.SetString("ModeGame", "PvP");
        SceneManager.LoadScene("mainHockey"); 
    }

    public void ModePvsAI()
    {
        PlayerPrefs.SetString("ModeGame", "PvAI");
        SceneManager.LoadScene("pilihKesulitan");
    }
}
