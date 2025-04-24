using UnityEngine;
using UnityEngine.SceneManagement;
public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Return))
        {
            KembaliKeMenu();
        }

    }
    public void MulaiPermainan()
    {
        SceneManager.LoadScene("mainHockey");
    }
    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("menuHockey");
    }
    public void PilihMode()
    {
        SceneManager.LoadScene("pilihLawan");
    }
}
