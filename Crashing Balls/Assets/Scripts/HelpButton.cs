using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    public GameObject screen1;
    public GameObject screen2;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(changeScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeScreen()
    {
        screen1.gameObject.SetActive(false);
        screen2.gameObject.SetActive(true);
    }
}
