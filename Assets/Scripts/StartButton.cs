using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour

{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        //print("You have clicked the button!");
        SceneManager.LoadScene("SpaceInvaders");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
