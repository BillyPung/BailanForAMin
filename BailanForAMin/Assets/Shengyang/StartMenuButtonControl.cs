using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuButtonControl : MonoBehaviour
{
    private Button StartGameButton, ExitGameButton;
    // Start is called before the first frame update
    void Start()
    {
        StartGameButton = GameObject.Find("StartButton").GetComponent<Button>();
        StartGameButton.onClick.AddListener(StartOnClick);
        ExitGameButton = GameObject.Find("ExitButton").GetComponent<Button>();
        ExitGameButton.onClick.AddListener(ExitOnClick);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void StartOnClick()
    {
        SceneManager.LoadScene(1);
    }

    void ExitOnClick()
    {
        Application.Quit();
    }
}
