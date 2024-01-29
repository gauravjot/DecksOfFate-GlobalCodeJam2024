using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene3 : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene(6);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(7);
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
