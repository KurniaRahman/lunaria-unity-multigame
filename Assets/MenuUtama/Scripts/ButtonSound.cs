using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        // Tambahkan AudioSource jika belum ada
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clickSound;
    }

    public void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}

