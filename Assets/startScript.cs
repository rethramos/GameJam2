using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Storyline");
    }
    
    public void Storyline()
    {
        SceneManager.LoadScene("Storyline2");
    }
    public void Storyline2()
    {
        SceneManager.LoadScene("Storyline3");
    }
    public void Storyline3()
    {
        SceneManager.LoadScene("WhiteRoom");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
