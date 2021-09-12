using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUiController : MonoBehaviour
{
    private Slider slider;
    private float durationSeconds = 10f;
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeElapsed < durationSeconds)
        {
            timeElapsed += Time.deltaTime;
            slider.value = (timeElapsed / durationSeconds);
            Debug.Log(timeElapsed);

            // TODO: add "blinking" animation to slider when there's only 10% of the duration left
        } else
        {
            // TODO: post game lose event
        }

    }
}
