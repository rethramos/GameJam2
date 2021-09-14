using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startScript : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider slider;

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
        //SceneManager.LoadScene("WhiteRoom");
        StartCoroutine(LoadAsynchronously());
    }
    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("WhiteRoom");
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
