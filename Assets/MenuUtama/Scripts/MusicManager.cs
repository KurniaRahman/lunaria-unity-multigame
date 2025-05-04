using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [Header("List scene dan musiknya")]
    public List<DataMusik> sceneMusicList = new List<DataMusik>();

    private Dictionary<string, AudioClip> sceneMusicMap;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        // Inisialisasi Dictionary
        sceneMusicMap = new Dictionary<string, AudioClip>();
        foreach (var pair in sceneMusicList)
        {
            if (!sceneMusicMap.ContainsKey(pair.sceneName))
            {
                sceneMusicMap.Add(pair.sceneName, pair.musicClip);
            }
        }
    }

    void Start()
    {
        PlayMusicForScene(SceneManager.GetActiveScene().name);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        if (sceneMusicMap.TryGetValue(sceneName, out AudioClip clip))
        {
            if (clip != null && audioSource.clip != clip)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
