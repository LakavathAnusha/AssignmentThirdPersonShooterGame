using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public Button playAgain;
    // Start is called before the first frame update
    void Start()
    {
        playAgain.onClick.AddListener(starts);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void starts()
    {
        SceneManager.LoadScene(1);
    }
}
