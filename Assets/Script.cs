using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Script : MonoBehaviour
{
    public Button play;
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(start);
    }

    public void start()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
