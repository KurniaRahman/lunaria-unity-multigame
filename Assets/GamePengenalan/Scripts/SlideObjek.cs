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
    public Text subtitleText;
    public Text descriptionText;
    public Text pageNumberText;
    public CanvasGroup contentCanvasGroup;

    [Header("Audio")]
    public AudioSource audioSource;

    private int currentIndex = 0;
    private bool isTransitioning = false;
    private bool hasShownFirstSlide = false;

    [Header("Navigation Buttons")]
    public Button nextButton;
    public Button prevButton;

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
        
        prevButton.gameObject.SetActive(index > 0);
        nextButton.gameObject.SetActive(index < planetSlides.Count - 1);

    }

    IEnumerator SlideTransition(int index) {
        isTransitioning = true;

        // SLIDE PERTAMA TIDAK FADE HANYA SAAT PERTAMA KALI MASUK
        bool skipFade = (index == 0 && !hasShownFirstSlide);

        if (!skipFade) {
            yield return StartCoroutine(FadeCanvas(contentCanvasGroup, 1f, 0f, 0.5f));
        }

        // Set content langsung
        DataObjek data = planetSlides[index];
        planetImage.sprite = data.image;
        titleText.text = data.title;
        subtitleText.text = data.subtitle;
        descriptionText.text = data.description;
        pageNumberText.text = $"{index + 1}";

        currentIndex = index;

        if (!skipFade) {
            yield return StartCoroutine(FadeCanvas(contentCanvasGroup, 0f, 1f, 0.5f));
        }

        // FLAG bahwa slide pertama sudah pernah ditampilkan
        if (index == 0 && !hasShownFirstSlide) {
            hasShownFirstSlide = true;
        }

        // Delay 2 detik setelah fade in baru play audio
        audioSource.Stop();
        audioSource.clip = data.voiceOver;

        yield return new WaitForSeconds(2f);
        audioSource.Play();

        isTransitioning = false;
    }

    IEnumerator FadeCanvas(CanvasGroup targetCanvasGroup, float from, float to, float duration) {
        float time = 0f;
        while (time < duration) {
            targetCanvasGroup.alpha = Mathf.Lerp(from, to, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        targetCanvasGroup.alpha = to;
    }
}
