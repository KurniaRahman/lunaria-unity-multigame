using UnityEngine;

[System.Serializable]
public class DataObjek {
    public string title;
    public string subtitle;
    [TextArea(3, 10)]
    public string description;
    public Sprite image;
    public AudioClip voiceOver;
}
