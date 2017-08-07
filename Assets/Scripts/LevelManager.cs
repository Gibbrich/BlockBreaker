using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadLevel(string name)
    {
        print(string.Format("Level {0} load requested", name));
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        print("Quit requested");
        Application.Quit();
    }
}