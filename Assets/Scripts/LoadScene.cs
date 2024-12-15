using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Seagull").Length == 0)
        {
            // go to next scene
            SceneManager.LoadScene("GameOverScreen");
            //print("game over");
        }

    }



}
