using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideObjek : MonoBehaviour
{
    [Header("Slide Content")]
    public List<DataObjek> planetSlides;

    [Header("UI Components")]
    public Image planetImage;
    public Text titleText;
    public Text descriptionText;
    public Text pageNumberText;
    public CanvasGroup canvasGroup;

    [Header("Audio")]
    public AudioSource audioSource;

    private int currentIndex = 0;
    private bool isTransitioning = false;

    void Start() {
        ShowSlide(currentIndex);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) OnNextButton();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) OnPrevButton();
    }

    public void OnNextButton() {
        if (currentIndex + 1 < planetSlides.Count) ShowSlide(currentIndex + 1);
    }

    public void OnPrevButton() {
        if (currentIndex - 1 >= 0) ShowSlide(currentIndex - 1);
    }

    public void ShowSlide(int index) {
        if (isTransitioning || index < 0 || index >= planetSlides.Count) return;
        StartCoroutine(SlideTransition(index));
    }

    IEnumerator SlideTransition(int index) {
        isTransitioning = true;

        // Fade out
        yield return StartCoroutine(FadeCanvas(1f, 0f, 0.5f));

        // Set new content
        DataObjek data = planetSlides[index];
        planetImage.sprite = data.image;
        titleText.text = data.title;
        descriptionText.text = data.description;
        pageNumberText.text = $"{index + 1} / {planetSlides.Count}";

        currentIndex = index;

        // Play audio
        audioSource.Stop();
        audioSource.clip = data.voiceOver;
        audioSource.Play();

        // Fade in
        yield return StartCoroutine(FadeCanvas(0f, 1f, 0.5f));

        isTransitioning = false;
    }

    IEnumerator FadeCanvas(float from, float to, float duration) {
        float time = 0f;
        while (time < duration) {
            canvasGroup.alpha = Mathf.Lerp(from, to, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = to;
    }
}