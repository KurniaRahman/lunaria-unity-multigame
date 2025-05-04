using UnityEngine;

public class MunculBenda : MonoBehaviour
{
    public static float kecepatanBenda = 1f;

    public float jedaAwal = 1f;
    public float jedaMinimum = 1f;
    public float percepatan = 20f;
    public float kecepatanMaks = 200f;

    private float timer = 0f;
    private float jedaSekarang;
    private float waktuGame = 0f;

    public GameObject[] daftarBenda;
    public GameObject efekSpawn;

    void Start()
    {
        jedaMinimum = 3.2f;
        jedaSekarang = jedaAwal;
        kecepatanBenda = 1f;
    }

    void Update()
    {
        if (daftarBenda == null || daftarBenda.Length == 0)
            return;

        timer += Time.deltaTime;
        waktuGame += Time.deltaTime;

        jedaSekarang = Mathf.Max(jedaMinimum, 2f / kecepatanBenda);

        KurangiJedaMinimumSeiringWaktu();

        MeningkatkanKecepatanBenda();

        if (timer > jedaSekarang)
        {
            SpawnBenda();
            timer = 0f;
        }
    }

    void SpawnBenda()
    {
        if (daftarBenda.Length == 0) return;

        int randomIndex = Random.Range(0, daftarBenda.Length);
        GameObject prefabBenda = daftarBenda[randomIndex];

        if (prefabBenda != null)
        {
            Instantiate(prefabBenda, transform.position, transform.rotation);
        }

        if (efekSpawn != null)
        {
            Instantiate(efekSpawn, transform.position, Quaternion.identity);
        }
    }

void KurangiJedaMinimumSeiringWaktu()
    {
        if (waktuGame > 5f && jedaMinimum >= 1f)
        {
            jedaMinimum -= 0.2f; 
            waktuGame = 0f;
        }
    }

    void MeningkatkanKecepatanBenda()
    {
        if (kecepatanBenda < kecepatanMaks)
        {
            kecepatanBenda += percepatan * Time.deltaTime;
            kecepatanBenda = Mathf.Min(kecepatanBenda, kecepatanMaks);
        }
    }
}
