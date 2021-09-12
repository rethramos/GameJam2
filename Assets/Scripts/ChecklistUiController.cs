using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChecklistUiController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject textTemplate;

    private List<TextMeshProUGUI> checklistItems = new List<TextMeshProUGUI>();


    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        textTemplate.SetActive(false);
    }

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ChecklistEvents.ON_CHECKLIST_ADD, OnChecklistAdd);
        EventBroadcaster.Instance.AddObserver(EventNames.ChecklistEvents.ON_ITEM_FOUND, OnItemFound);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.ChecklistEvents.ON_CHECKLIST_ADD, OnChecklistAdd);
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.ChecklistEvents.ON_ITEM_FOUND, OnItemFound);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update of checklistui");

        // toggle checklist UI
        if (Input.GetKeyDown(KeyCode.C) == true)
        {
            Debug.Log("C pressed");
            bool isActive = canvas.activeSelf;
            canvas.SetActive(!isActive);
        }
    }

    private void PopulateChecklistUi()
    {
        Debug.Log("POPULATECHECKLISTUI CALLED");
        foreach (MissingItem missingItem in Checklist.GetAllItems())
        {
            GameObject text = Instantiate(textTemplate, panel.transform);
            text.SetActive(true);
            text.GetComponent<TMPro.TextMeshProUGUI>().text = missingItem.ItemName;
        }
    }

    private void OnChecklistAdd(Parameters p)
    {
        string itemName = p.GetStringExtra(MissingItem.ITEM_KEY, ".");
        InstantiateText(itemName);
    }

    private void OnItemFound(Parameters p)
    {
        MarkAsFound(p.GetStringExtra(ItemPickup.FOUND_ITEM_KEY, ""));
    }

    private void InstantiateText(string text)
    {
        GameObject _textTemp = Instantiate(textTemplate, panel.transform);
        _textTemp.SetActive(true);
        TextMeshProUGUI textComp = _textTemp.GetComponent<TextMeshProUGUI>();
        textComp.text = text;
        checklistItems.Add(textComp);
    }

    private void MarkAsFound(string text)
    {
        TextMeshProUGUI tmpFoundItem = checklistItems.Find(item => item.text == text);
        tmpFoundItem.fontStyle = FontStyles.Strikethrough;
        tmpFoundItem.color = Color.gray;
    }
}
