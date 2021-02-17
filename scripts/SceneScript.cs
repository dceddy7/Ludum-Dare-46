using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneScript : MonoBehaviour
{
    int currentScene = 0;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        currentScene++;
        SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
        
        
    }

    public void EndGame()
    {
        SceneManager.LoadScene("End");
    }
}
