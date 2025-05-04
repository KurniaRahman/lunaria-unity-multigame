using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    private Rigidbody2D rigid;

    private int scoreP1;
    private int scoreP2;

    private Text scoreUIP1;
    private Text scoreUIP2;

    private GameObject panelSelesai;
    private Text txPemenang;

    private float waktuMain = 60f; //setting waktu (detik)
    private Text waktuUI;

    private bool gameBerakhir = false;
    private bool gameDimulai = false;

    private Text countdownText;

    private GameObject pemukul1;
    private GameObject pemukul2;

    AudioSource SoundFx;
    public AudioClip hitSound;
    public AudioClip goalSound;

    private TrailRenderer trail;




    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.linearVelocity = Vector2.zero;

        scoreP1 = 0;
        scoreP2 = 0;

        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();
        waktuUI = GameObject.Find("Waktu").GetComponent<Text>();
        countdownText = GameObject.Find("CountdownText").GetComponent<Text>();

        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);

        SoundFx = GetComponent<AudioSource>();

        trail = GetComponent<TrailRenderer>();


        // 🔹 Cari paddle
        pemukul1 = GameObject.Find("pemukul1");
        pemukul2 = GameObject.Find("pemukul2");


        TampilkanScore();
        StartCoroutine(HitungMundurDanMulaiGame());
    }

    void Update()
    {
        if (!gameDimulai || gameBerakhir) return;

        waktuMain -= Time.deltaTime;

        int menit = Mathf.FloorToInt(waktuMain / 60);
        int detik = Mathf.FloorToInt(waktuMain % 60);
        waktuUI.text = menit.ToString("00") + ":" + detik.ToString("00");

        if (waktuMain <= 0)
        {
            waktuUI.text = "00:00";
            SelesaiGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        SoundFx.PlayOneShot(hitSound);
        if (coll.gameObject.name == "gawangKanan")
        {
            scoreP1 += 1;
            TampilkanScore();
            StartCoroutine(SoundGoal(new Vector2(2, 0)));

            
                
            
        }   
        else if (coll.gameObject.name == "gawangKiri")
        {
            scoreP2 += 1;                
            TampilkanScore();
            StartCoroutine(SoundGoal(new Vector2(-2, 0)));
        }
        else if (coll.gameObject.name == "pemukul1" || coll.gameObject.name == "pemukul2")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.linearVelocity.x, sudut).normalized;
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForce(arah * force * 2);
        }
        
    }

    void ResetBall()
    {
        trail.enabled = false;
        transform.localPosition = Vector2.zero;
        rigid.linearVelocity = Vector2.zero;
    }

    void TampilkanScore()
    {
        scoreUIP1.text = scoreP1.ToString();
        scoreUIP2.text = scoreP2.ToString();
    }

    public void SelesaiGame()
{
    gameBerakhir = true;
    rigid.linearVelocity = Vector2.zero;
    rigid.angularVelocity = 0f;

    //menghentikan pemukul
    if (pemukul1 != null)
    {
        PaddleController kontrol1 = pemukul1.GetComponent<PaddleController>();
        if (kontrol1 != null) kontrol1.enabled = false;
    }

    if (pemukul2 != null)
    {
        PaddleController kontrol2 = pemukul2.GetComponent<PaddleController>();
        if (kontrol2 != null) kontrol2.enabled = false;
    }

    panelSelesai.SetActive(true);
    txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();

    if (scoreP1 > scoreP2)
        txPemenang.text = "Player 1 Pemenang!";
    else if (scoreP2 > scoreP1)
        txPemenang.text = "Player 2 Pemenang!";
    else
        txPemenang.text = "Seri!";
}

    IEnumerator HitungMundurDanMulaiGame(Vector2? arah = null)
    {
        gameDimulai = false;
        ResetBall();
        // reset pemukul
        if (pemukul1 != null) pemukul1.transform.localPosition = new Vector2(-7.5f, 0f);
        if (pemukul2 != null) pemukul2.transform.localPosition = new Vector2(7.5f, 0f);

        string mode = PlayerPrefs.GetString("ModeGame", "PvP");
        pemukul1.GetComponent<PaddleController>().enabled = false;
        if (mode == "PvP")
        {
            pemukul2.GetComponent<PaddleController>().enabled = false;
        }
        countdownText.gameObject.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        trail.Clear();
        trail.enabled = true;
        countdownText.text = "Mulai!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);

        pemukul1.GetComponent<PaddleController>().enabled = true;
        if (mode == "PvP")
        {
            pemukul2.GetComponent<PaddleController>().enabled = true;
        }        
        gameDimulai = true;


        Vector2 arahMulai = arah ?? new Vector2(Random.Range(0, 2) == 0 ? -2 : 2, 0);
        rigid.AddForce(arahMulai.normalized * force);
    }

    IEnumerator SoundGoal(Vector2 arah)
    {
        rigid.linearVelocity = Vector2.zero;

        if (goalSound != null)
        {
            SoundFx.PlayOneShot(goalSound);
            yield return new WaitForSeconds(goalSound.length);
        }

        StartCoroutine(HitungMundurDanMulaiGame(arah));
    }
}
