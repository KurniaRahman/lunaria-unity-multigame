using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BatasKiri : MonoBehaviour
{
    public Text textNyawa;
    public int totalNyawa = 3;
    public AudioClip suaraNyawaBerkurang; 
    private int nyawaTersisa;

    private AudioSource audioSource;

    void Start()
    {
        nyawaTersisa = totalNyawa;
        UpdateNyawaUI();

        
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Objek menyentuh batas kiri.");

        nyawaTersisa--;
        UpdateNyawaUI();

        // Mainkan suara jika tersedia
        if (suaraNyawaBerkurang != null && audioSource != null)
        {
            audioSource.PlayOneShot(suaraNyawaBerkurang);
        }

        if (nyawaTersisa <= 0)
        {
            SceneManager.LoadScene("GameSelesai");
        }
    }

    void UpdateNyawaUI()
    {
        if (textNyawa != null)
        {
            textNyawa.text = "Nyawa: " + nyawaTersisa.ToString();
        }
        else
        {
            Debug.LogWarning("Text nyawa belum diassign!");
        }
    }


}
