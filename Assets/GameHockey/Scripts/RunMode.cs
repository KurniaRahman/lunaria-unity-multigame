using UnityEngine;
using UnityEngine.SceneManagement;
public class RunMode : MonoBehaviour
{
    public GameObject paddleKiri;
    public GameObject paddleKanan;

    void Start()
    {
        string mode = PlayerPrefs.GetString("ModeGame", "PvP"); // default PvP

        // Paddle kiri selalu player
        paddleKiri.GetComponent<PaddleController>().enabled = true;

        if (mode == "PvP")
        {
            paddleKanan.GetComponent<PaddleController>().enabled = true;
            paddleKanan.GetComponent<PaddleAI>().enabled = false;
        }
        else if (mode == "PvAI")
        {
            paddleKanan.GetComponent<PaddleController>().enabled = false;
            paddleKanan.GetComponent<PaddleAI>().enabled = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
        SceneManager.LoadScene("pilihLawan");          
        }
    }  
}

