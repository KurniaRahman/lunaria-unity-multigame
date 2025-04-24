using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GerakHewan : MonoBehaviour
{
 
    int[] posX = new int[] {0, -20, -40, -60};
    int idx = 0;
    public AudioSource[] soundFx;
 
    // Use this for initialization
    void Start()
    {
        soundFx[idx].Play();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (idx < posX.Length - 1)
            {
                soundFx[idx].Stop();
                idx++;
                soundFx[idx].Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (idx > 0)
            {
                soundFx[idx].Stop();
                idx--;
                soundFx[idx].Play();
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(posX[idx], transform.position.y), 50 * Time.deltaTime);
    }
}


