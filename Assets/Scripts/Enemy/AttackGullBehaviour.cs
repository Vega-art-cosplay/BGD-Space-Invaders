using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGullBehaviour : MonoBehaviour
{
   // public GameObject attackGullPrefab;

    public float moveSpeed = 10f;
    public float destroyDelay = 10f;
    public SpriteRenderer spriteRenderer;


    void Start()
    {

        //spriteRenderer.transform.Rotate(0, 0, 70);
        // Another form of the Destroy function, which allows us to destroy an object
        // after a delay in seconds. We set the delay with a variable "destroyAfter"
        Destroy(gameObject, destroyDelay);
    }

    void Update()
    {
        // Moves the game object along the Y-axis (X is 0f), and we make the Y value into 
        // a variable so we can change the direction (up or down) and make the script reusable
        // in different situations. (can do the same for X and then it'll move in any direction you want)

        // diagonal movement
        //Vector3 translationVector = new Vector3(1f, -1f) * moveSpeed * Time.deltaTime;

        Vector3 translationVector = new Vector3(0f, -1f) * moveSpeed * Time.deltaTime;

        transform.Translate(translationVector);
    }


}
