using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ch3S1_Squirrel : MonoBehaviour
{
    public void IntimidateOption()
    {
        SceneManager.LoadScene(12);
    }

    public void SneakOption()
    {
        SceneManager.LoadScene(13);
    }

    public void AttackOption()
    {
        SceneManager.LoadScene(14);
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
