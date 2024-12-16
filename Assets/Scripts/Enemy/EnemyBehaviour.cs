using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Tilemaps.Tilemap;
using System;
using TMPro;


public class EnemyBehaviour : MonoBehaviour
{

    public Sprite spriteGullBread;
    public float moveSpeed = 0.03f;
    public float destroyDelay = 2f;
    public GameObject gull;

    private bool isCollided = false;

    public SpriteRenderer spriteRenderer;
    public Sprite gullSpriteA;
    public Sprite gullSpriteB;

    public float countdownStart = 2f;
    public float countdownStop;
    public float spriteChangeSpeed = 5f;
    bool isSpriteA = false;

    public float rotateCountdownStart = 2f;
    public float rotateCountdownStop;
    public float rotationAmount = 90f;
    bool isRotateRight = false;

    public AudioClip destructionSFX;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gull.transform.Rotate(0,0,-45);
        countdownStop = countdownStart;
        rotateCountdownStop = rotateCountdownStart;

    }


    private void Update()
    {
        rotateGullSprite();
        changeGullSprite();

        if (isCollided == true)
        {
            GetComponent<SpriteRenderer>().sprite = spriteGullBread;
            moveGullAway();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("I Collided!");
    }

    // Unity calls this function if the Collider on the game object has "Is Trigger" checked.
    // Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("I was triggered!");
        // Check the other colliding object's tag to know if it's
        // indeed a player projectile

        if (collision.tag == "Laser")
        {
            isCollided = true;
            ScoreManager.instance.AddPoint();

            // Destroy the alien game object off screen
            Destroy(gull, destroyDelay);

            // Destroy the projectile game object
            Destroy(collision.gameObject);

            // Play an audio clip in the scene and not attached to the alien
            // so the sound keeps playing even after it's destroyed
            AudioSource.PlayClipAtPoint(destructionSFX, transform.position);
        }
    }


    void moveGullAway()
    {

        Vector3 translationVector = new Vector3(0f, 1.5f) * moveSpeed * Time.deltaTime;
        transform.Translate(translationVector);

    }

    void changeGullSprite()
    {

        countdownStop -= Time.deltaTime * spriteChangeSpeed;

        if (countdownStop <= 0)
        {
            if (isSpriteA == true)
            {
                GetComponent<SpriteRenderer>().sprite = gullSpriteB;
                countdownStop = countdownStart;
                isSpriteA = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = gullSpriteA;
                isSpriteA = true;
                countdownStop = countdownStart;
            }
        }
    }

    void rotateGullSprite()
    {

        rotateCountdownStop -= Time.deltaTime;

        if (rotateCountdownStop <= 0)
        {
            if (isRotateRight == true)
            {
                rotateSpriteLeft();
                rotateCountdownStop = rotateCountdownStart;
                isRotateRight = false;
            }
            else
            {
                rotateSpriteRight();
                isRotateRight = true;
                rotateCountdownStop = rotateCountdownStart;
            }
        }

        void rotateSpriteRight()
        {
            Vector3 targetPosition = gull.transform.position;

            transform.RotateAround(targetPosition, Vector3.forward, rotationAmount);
        }

        void rotateSpriteLeft()
        {
            Vector3 targetPosition = gull.transform.position;

            transform.RotateAround(targetPosition, -Vector3.forward, rotationAmount);
        }
    }
}
