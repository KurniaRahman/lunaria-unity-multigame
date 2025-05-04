using UnityEngine;
using UnityEngine.SceneManagement;

public class BatasAkhirBenda : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (Data.score >= 1000)
        {
            SceneManager.LoadScene("GameSelesai");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
