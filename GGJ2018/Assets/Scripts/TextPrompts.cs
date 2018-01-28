using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextPrompts : MonoBehaviour {
    public static TextPrompts Instance { get; set; }
    public GameObject promptPanel;
    public string dogName;
    public List<string> textLines = new List<string>();

    Text promptText, nameText;
    int promptIndex;

    public static bool isPlaying = false;

    void Awake()
    {
        promptText = promptPanel.transform.FindChild("Text").GetComponent<Text>();
        nameText = promptPanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();

        promptPanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        isPlaying = false;
    } 
    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ContinuePrompt();
            }
        }
    }

    public void AddNewPrompt(string[] lines, string dogName)
    {
        promptIndex = 0;
        textLines = new List<string>();
        foreach(string line in lines)
        {
            textLines.Add(line);
        }
        this.dogName = dogName;

        Debug.Log(textLines.Count);
        CreatePrompt();
    }

    public void CreatePrompt()
    {
        isPlaying = true;
        promptText.text = textLines[promptIndex];
        nameText.text = dogName;
        promptPanel.SetActive(true);
        print("LINE" + promptIndex);
    }

    public void ContinuePrompt()
    {
        if (promptIndex < textLines.Count - 1)
        {
            promptIndex++;
            promptText.text = textLines[promptIndex];
            print("LINE" + promptIndex);
        }
        else
        {
            promptPanel.SetActive(false);
            isPlaying = false;
            print("CLOSE");
        }
    }
}
