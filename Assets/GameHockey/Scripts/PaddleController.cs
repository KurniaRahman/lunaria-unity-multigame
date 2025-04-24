using UnityEngine;
public class PaddleController : MonoBehaviour
{
    public BallController bola;
    public float batasAtas;
    public float batasBawah;
    public float batasKanan;
    public float batasKiri;
    public float kecepatan;
    public string axisY;
    public string axisH;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

        float gerakY = Input.GetAxis(axisY) * kecepatan * Time.deltaTime;
        float gerakH = Input.GetAxis(axisH) * kecepatan * Time.deltaTime;
        float nextPosY = transform.position.y + gerakY;
        float nextPosH = transform.position.x + gerakH;
        if (nextPosY > batasAtas)
        {
            gerakY = 0;
        }
        if (nextPosY < batasBawah)
        {
            gerakY = 0;
        }
        if (nextPosH > batasKanan)
        {
            gerakH = 0;
        }
        if (nextPosH < batasKiri)
        {
            gerakH = 0;
        }
        transform.Translate(gerakH, gerakY, 0);
        
    }
}
