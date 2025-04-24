using UnityEngine;

public class RotasiObjek : MonoBehaviour
{
    public float kecepatanRotasi;
    public bool putarKeKanan = true; 

    void Update()
    {
        float arah = putarKeKanan ? -1f : 1f;
        transform.Rotate(0, 0, kecepatanRotasi * arah * Time.deltaTime);
    }
}
