using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    public Transform bola;
    public float kecepatan = 5f;
    public float batasAtas = 2.75f;
    public float batasBawah = -2.75f;
    public float batasKiri = 0.2f;
    public float batasKanan = 8.25f;

    private Vector3 posisiAwal;
    public float marginError = 0.5f;

    private Rigidbody2D bolaRb;

    void Start()
    {


        bola = GameObject.Find("bola").transform;
        bolaRb = bola.GetComponent<Rigidbody2D>();
        posisiAwal = new Vector3(7.5f, 0f, 0f);
        transform.position = posisiAwal;

        string level = PlayerPrefs.GetString("AILevel", "Easy");

        switch (level)
        {
            case "Easy":
                kecepatan = 2f;
                marginError = 2.5f;
                break;
            case "Medium":
                kecepatan = 4f;
                marginError = 2f;
                break;
            case "Hard":
                kecepatan = 6f;
                marginError = 1.75f;
                break;
            case "Legend":
                kecepatan = 7f;
                marginError = 0.5f;
                break;
        }
    }

    void Update()
    {
        Vector3 posisiSekarang = transform.position;

        bool bolaMenujuAI = bolaRb.linearVelocity.x > 0;

        if (bolaMenujuAI)
        {
            if (Mathf.Abs(bola.position.y - posisiSekarang.y) > marginError)
            {
                posisiSekarang.y = Mathf.MoveTowards(posisiSekarang.y, bola.position.y, kecepatan * Time.deltaTime);
            }

            if (Mathf.Abs(bola.position.x - posisiSekarang.x) > marginError)
            {
                posisiSekarang.x = Mathf.MoveTowards(posisiSekarang.x, bola.position.x, kecepatan * Time.deltaTime);
            }
        }

        posisiSekarang.y = Mathf.Clamp(posisiSekarang.y, batasBawah, batasAtas);
        posisiSekarang.x = Mathf.Clamp(posisiSekarang.x, batasKiri, batasKanan);

        transform.position = posisiSekarang;
    }
}
