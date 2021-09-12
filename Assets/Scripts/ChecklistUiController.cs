using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChecklistUiController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject textTemplate;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        textTemplate.SetActive(false);
        PopulateChecklistUi();
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
        foreach (MissingItem missingItem in Checklist.GetAllItems())
        {
            GameObject text = Instantiate(textTemplate, panel.transform);
            text.SetActive(true);
            text.GetComponent<TMPro.TextMeshProUGUI>().text = missingItem.ItemName;
        }
    }
}
