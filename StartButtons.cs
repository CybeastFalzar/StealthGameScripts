using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public Button StartButton, ControlButton, QuitButton, BackButton;
    void Start()
    {
        StartButton.onClick.AddListener(StartClick);
        ControlButton.onClick.AddListener(ControlClick);
        QuitButton.onClick.AddListener(QuitClick);
        BackButton.onClick.AddListener(BackClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartClick ()
    {
        SceneManager.LoadScene("Level1");
    }

    void ControlClick()
    {
        SceneManager.LoadScene("Controls");
    }

    void QuitClick()
    {
        Application.Quit();
    }

    void BackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
