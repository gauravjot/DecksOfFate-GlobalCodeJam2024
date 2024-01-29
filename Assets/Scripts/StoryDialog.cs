using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryDialog : MonoBehaviour
{
    public TextMeshProUGUI textSpeaker;
    public TextMeshProUGUI textDisplay;
    public Image imageAtComplete;

    [SerializeField]
    RectTransform playerOptions;

    [SerializeField]
    string speakerName;

    [SerializeField]
    string[] sentences;

    [Range(0f, 1f), SerializeField]
    float textSpeed = 0.1f;

    [SerializeField]
    int nextSceneIndex = 0;

    [SerializeField]
    int afterOptionSelectSceneIndex = 0;

    private bool isFinished = false;

    private int index;

    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
        playerOptions.gameObject.SetActive(false);
        imageAtComplete.enabled = false;
    }

    private IEnumerator TypeLine()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        imageAtComplete.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        textSpeaker.text = speakerName;
        textDisplay.text = string.Empty;
        StartDialog();
    }

    void NextLine()
    {
        imageAtComplete.enabled = false;
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textDisplay.text = string.Empty;
            textSpeaker.text = string.Empty;
            if (nextSceneIndex < 0)
            {
                playerOptions.gameObject.SetActive(true);
            }
        }
    }

    void openNextScene()
    {
        if (nextSceneIndex >= 0)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            textDisplay.text = string.Empty;
            textSpeaker.text = string.Empty;
            playerOptions.gameObject.SetActive(true);
        }
    }

    public void changeSceneOnButtonClick()
    {
        SceneManager.LoadScene(afterOptionSelectSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isFinished)
            {
                openNextScene();
            }
            if (textDisplay.text == sentences[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                if (!isFinished)
                {
                    textDisplay.text = sentences[index];
                    imageAtComplete.enabled = true;
                }
            }
            if (index == sentences.Length - 1)
            {
                isFinished = true;
            }
        }
    }
}
