using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    //private bool isCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "AttackGull")
        {
            //isCollided = true;
            SceneManager.LoadScene("GameOverBad");

            // Play an audio clip in the scene and not attached to the alien
            // so the sound keeps playing even after it's destroyed
            //AudioSource.PlayClipAtPoint(destructionSFX, transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
