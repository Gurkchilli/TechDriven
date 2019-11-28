using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public Text timeText;
    private float time = 60.0f;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime;

        timeText.text = "" + Math.Round(time);
        if(time < 1)
        {
            Time.timeScale=0;
            timeText.text = "Game Over";
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

            Time.timeScale = 1;
        }
    }
    
}
