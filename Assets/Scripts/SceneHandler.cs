using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField]
    RectTransform fader;

    [SerializeField]
    float faderScaleTime = 0.2f;
    public AudioSource buttonClickSound;

    private void Start()
    {
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 1, 0f);
        LeanTween
            .alpha(fader, 0, faderScaleTime)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                fader.gameObject.SetActive(false);
            });
    }

    public void OpenMenuScene()
    {
        buttonClickSound.Play();
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0f);
        LeanTween
            .alpha(fader, 1, faderScaleTime)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                SceneManager.LoadScene(0);
            });
    }

    public void OpenGameScene()
    {
        buttonClickSound.Play();
        // Clear cards
        Player player = Player.Instance;
        player.removeAllPlayerCards();
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0f);
        LeanTween
            .alpha(fader, 1, faderScaleTime)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                SceneManager.LoadScene(3);
            });
    }

    public void OpenCreditsScene()
    {
        buttonClickSound.Play();
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0f);
        LeanTween
            .alpha(fader, 1, faderScaleTime)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                SceneManager.LoadScene(6);
            });
    }

    public void OpenAllCardsScene()
    {
        buttonClickSound.Play();
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0f);
        LeanTween
            .alpha(fader, 1, faderScaleTime)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                SceneManager.LoadScene(2);
            });
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
