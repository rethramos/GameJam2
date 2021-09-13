using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUiController : MonoBehaviour
{
    private Slider slider;
    private Animator animator;
    private float durationSeconds = 180f;
    private float timeElapsed = 0f;
    private bool animationTriggered = false;
    private bool eventPosted = false;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        animator = gameObject.GetComponent<Animator>();
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

            // add "shaking" animation to timer when there's only 30% of the duration left
            if (!animationTriggered && timeElapsed >= 0.6 * durationSeconds)
            {
                animator.SetTrigger("AlmostTime");
                animationTriggered = true;
            }
        }
        else
        {
            if (!eventPosted)
            {
                // TODO: post game lose event
                Parameters p = new Parameters();
                p.PutExtra("GAME_OVER_KEY", 0);
                EventBroadcaster.Instance.PostEvent(EventNames.TimerEvents.ON_GAME_OVER, p);
                Debug.Log("TIME'S UP");
            }
        }



    }

}
