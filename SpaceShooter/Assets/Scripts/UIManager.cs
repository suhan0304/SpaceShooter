using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Button optionButton;
    public Button shopButton;

    private UnityAction action;

    void Start() {
        action = () => OnButtonClick(startButton.name);
        startButton.onClick.AddListener(action);

        optionButton.onClick.AddListener(delegate {OnButtonClick(optionButton.name);});

        shopButton.onClick.AddListener(() => OnButtonClick(shopButton.name));
    }

    public void OnButtonClick(string msg) {
        Debug.Log($"Click Button : {msg}");
    }
}
