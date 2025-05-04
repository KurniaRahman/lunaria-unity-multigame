using UnityEngine;
using UnityEngine.UI;
using System.Collections; // <- Ini perlu untuk pakai Coroutine

public class DeteksiBenda : MonoBehaviour
{
    public string tagBenar;
    public AudioClip audioBenar;
    public AudioClip audioSalah;
    public Text textScore;
    public Sprite gambarTerbuka;

    private AudioSource mediaPlayerBenar;
    private AudioSource mediaPlayerSalah;
    private SpriteRenderer spriteRenderer;
    private Sprite gambarAwal; // <- Tambahan untuk simpan gambar sebelum berubah

void Start()
{
    // Reset score saat scene dimulai
    Data.score = 0;

    mediaPlayerBenar = gameObject.AddComponent<AudioSource>();
    mediaPlayerBenar.clip = audioBenar;

    mediaPlayerSalah = gameObject.AddComponent<AudioSource>();
    mediaPlayerSalah.clip = audioSalah;

    spriteRenderer = GetComponent<SpriteRenderer>();

    textScore.text = "0";

    if (spriteRenderer != null)
    {
        gambarAwal = spriteRenderer.sprite;
    }
}


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        GerakPindah gerakPindah = collision.GetComponent<GerakPindah>();

        if (gerakPindah == null)
        {
            Debug.LogWarning("Object yang masuk trigger tidak punya script GerakPindah: " + collision.name);
            return;
        }

        if (collision.CompareTag(tagBenar))
        {
            Data.score += 25;
            textScore.text = Data.score.ToString();

            if (spriteRenderer != null && gambarTerbuka != null)
            {
                spriteRenderer.sprite = gambarTerbuka;

                // Setelah 2 detik, kembalikan lagi ke gambar awal
                StartCoroutine(KembalikanGambar());
            }

            gerakPindah.BendaSudahDitempatkan();
            mediaPlayerBenar.Play();
        }
        else
        {
            Data.score -= 5;
            textScore.text = Data.score.ToString();

            gerakPindah.BendaSudahDitempatkan();
            mediaPlayerSalah.Play();
        }
    }

    IEnumerator KembalikanGambar()
    {
        yield return new WaitForSeconds(2f); // Tunggu 2 detik
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = gambarAwal;
        }
    }
}
