using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUiController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI textbox;

    private string[] messages = { "GAME OVER!", "YOU WIN!" };

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.TimerEvents.ON_GAME_OVER, OnGameOver);
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.TimerEvents.ON_GAME_OVER, OnGameOver);
    }


    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGameOver(Parameters p)
    {
        int result = p.GetIntExtra("GAME_OVER_KEY", -1);
        if (result > -1)
        {
            textbox.text = messages[result];
        }

        canvas.gameObject.SetActive(true);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
