using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPindah : MonoBehaviour
{
    public float speedMaks = 20f;        // kecepatan maksimal (bisa disesuaikan)

    private float speedSekarang;
    private bool isDragging = false;
    private bool sudahDitempatkan = false;

    private Vector3 screenPoint;
    private Vector3 offset;
    private float firstY;
    private float speedTetap;


    public Sprite[] sprites;

    void Start()
    {
        speedTetap = MunculBenda.kecepatanBenda;
        speedSekarang = speedTetap;

        int index = Random.Range(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    void Update()
    {
        if (!isDragging && !sudahDitempatkan)
        {
            if (!isDragging && !sudahDitempatkan)
            {
                speedSekarang = MunculBenda.kecepatanBenda; // atau pakai percepatan sendiri

                float move = transform.position.x - speedSekarang * Time.deltaTime;
                transform.position = new Vector3(move, transform.position.y, transform.position.z);

                // HANCURKAN jika sudah keluar batas
                if (transform.position.x < -12f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (!sudahDitempatkan)
        {
            isDragging = true;
            firstY = transform.position.y;
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (!sudahDitempatkan)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    void OnMouseUp()
    {
        if (!sudahDitempatkan)
        {
            isDragging = false;
            transform.position = new Vector3(transform.position.x, firstY, transform.position.z);
        }
    }

    public void BendaSudahDitempatkan()
    {
        sudahDitempatkan = true;
        Destroy(gameObject);
    }
}
