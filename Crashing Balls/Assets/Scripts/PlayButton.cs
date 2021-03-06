﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    public string level;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }

}
