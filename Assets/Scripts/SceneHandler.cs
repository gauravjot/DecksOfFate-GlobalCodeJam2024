using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneHandler : MonoBehaviour
{

    [SerializeField] RectTransform fader;
    public AudioSource buttonClickSound;

    private void Start() {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1,1,1), 0f);
        LeanTween.scale (fader, Vector3.zero, 0.5f).setEase (LeanTweenType.easeInOutQuad).setOnComplete (() => {
            fader.gameObject.SetActive (false);
        });
    }

    public void OpenMenuScene()
    {
        buttonClickSound.Play();
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f).setEase (LeanTweenType.easeInOutQuad).setOnComplete(()=>{
                    SceneManager.LoadScene(0);
        });
    }
    
    public void OpenGameScene()
    {
        buttonClickSound.Play();
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f).setEase (LeanTweenType.easeInOutQuad).setOnComplete(()=>{
                    SceneManager.LoadScene(1);
        });
    }
    
    public void OpenAllCardsScene()
    {
        buttonClickSound.Play();
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f).setEase (LeanTweenType.easeInOutQuad).setOnComplete(()=>{
                    SceneManager.LoadScene(2);
        });
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
