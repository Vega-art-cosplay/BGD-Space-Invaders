using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGullLoader : MonoBehaviour
{

    public GameObject attackGullPrefab;
    public AudioSource sfxAttackGull;
    public SpriteRenderer spriteRenderer;

    //public float destroyDelay = 15f;

    public float timeUntilAttack = 4f;
    public float attackTime;
    //public float attackDelay = 2f;



    // Start is called before the first frame update
    void Start()
    {

        //spriteRenderer.transform.Rotate(0, 0, 70);

        //Invoke("GullAttack", 5);
        // Invoke("GullAttack", 15);
        // Invoke("GullAttack", 20);

        attackTime = timeUntilAttack;

        //Destroy(gameObject, destroyDelay);


    }

    // Update is called once per frame
    void Update()
    {

        LoadGull();

    }


    void GullAttack()
    {
        //load somewhere in the top left corner
        //Instantiate(attackGullPrefab, new Vector3(-10, 10, 0), Quaternion.identity);

        //load in the middle, somewhere off the screen
        Instantiate(attackGullPrefab, new Vector3(0, 10, 0), Quaternion.identity);
        sfxAttackGull.Play();

    }


    void LoadGull()
    {

        attackTime -= Time.deltaTime;

        if (attackTime <= 0)
        {

                GullAttack();
                attackTime = timeUntilAttack;
            
        }
    }
}
