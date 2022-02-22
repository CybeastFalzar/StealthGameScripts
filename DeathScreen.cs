using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DeathScreen : MonoBehaviour
{



    public Button MButton, TButton;
    void Start()
    {
        MButton.onClick.AddListener(menu) ;
        TButton.onClick.AddListener(tryAgain);

    }

    // Update is called once per frame
    void Update()
    {
       


    }



    void tryAgain()
    {
       
        SceneManager.LoadScene("Level1");
        PlayerMovement.score = 0;
    }
    void menu()
    {
       
        SceneManager.LoadScene("MainMenu");
        PlayerMovement.score = 0;
    }


}
