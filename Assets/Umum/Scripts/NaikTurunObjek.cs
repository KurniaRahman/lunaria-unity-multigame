using UnityEngine;

public class NaikTurunObjek : MonoBehaviour
{
    public float jarakAmplitudo; 
    public float kecepatanGerak;       
    private Vector3 posisiAwal;

    void Start()
    {
        posisiAwal = transform.position;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * kecepatanGerak) * jarakAmplitudo;
        transform.position = new Vector3(posisiAwal.x, posisiAwal.y + y, posisiAwal.z);
    }
}
