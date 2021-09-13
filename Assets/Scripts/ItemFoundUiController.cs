using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemFoundUiController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject dialogsContainer;
    [SerializeField] private GameObject dialogObject;
    //[SerializeField] private TextMeshProUGUI textTemplate;

    private List<GameObject> dialogObjects = new List<GameObject>();

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ChecklistEvents.ON_ITEM_FOUND, OnItemFound);
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.ChecklistEvents.ON_ITEM_FOUND, OnItemFound);
    }


    // Start is called before the first frame update
    void Start()
    {
        dialogObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnItemFound(Parameters p)
    {
        string itemName = p.GetStringExtra(ItemPickup.FOUND_ITEM_KEY, "");
        string text = $"{itemName} found!";
        StartCoroutine(DisplayNotification(text));
    }

    private IEnumerator DisplayNotification(string message)
    {
        GameObject d = GameObject.Instantiate(dialogObject, dialogsContainer.transform);
        d.GetComponentInChildren<TextMeshProUGUI>().text = message;
        d.SetActive(true);

        yield return new WaitForSeconds(3f);
        d.GetComponent<Animator>().SetTrigger("DialogFade");
        yield return new WaitForSeconds(2f);

        GameObject.Destroy(d);
    }

}
