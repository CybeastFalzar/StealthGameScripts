using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    bool timeStopped;

    public GameObject pauseMenu;

    public Button ResumeButton, MenuButton, QuitButton;
    void Start()
    {
        ResumeButton.onClick.AddListener(resume);
        MenuButton.onClick.AddListener(menu);
        QuitButton.onClick.AddListener(quit);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && timeStopped == false)
        {
            TimeStop();
        } else if (Input.GetKeyDown(KeyCode.Escape) && timeStopped == true) 
            {
            TimeStart();
        }


    }


    void TimeStop ()
    {
        timeStopped = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    void TimeStart()
    {
        timeStopped = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }

    void resume()
    {

        TimeStart();
    }   
    
   void menu()
    {
        TimeStart();
        PlayerMovement.score = 0;   
        SceneManager.LoadScene("MainMenu");
    }

    void quit()
    {

        Application.Quit();
    }
}
