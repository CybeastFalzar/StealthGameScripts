using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    string scoreText;
    [SerializeField] TextMeshProUGUI m_Object;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText = PlayerMovement.score.ToString();
        m_Object.text = scoreText;
    }
}
