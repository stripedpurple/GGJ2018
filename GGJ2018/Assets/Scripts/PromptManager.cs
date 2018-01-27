using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PromptManager : MonoBehaviour {

    public static PromptManager self;

    public GameObject panel;
    public Text textObj;

    public bool isVisible = false;

    void Awake()
    {
        self = this;
        SetVisible(false);
    }
    public static void SetVisible (bool doVisible)
    {
        self.panel.SetActive(doVisible);
        self.isVisible = doVisible;
    }

    public static void SetText(string text)
    {
        self.textObj.text = text;
    }
}
