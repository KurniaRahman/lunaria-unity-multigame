using UnityEngine;

public class GameSelesai : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Game selesai. Skor akhir: " + Data.score);
        // Tidak perlu timer karena UI GameSelesai menangani aksi berikutnya
    }
}
