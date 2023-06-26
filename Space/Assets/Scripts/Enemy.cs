using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameController gameController;
    private GameObject player;
    private Transform target;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    public int moveSpeed = 15;
    public int MaxHealth = 100;

    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.Log("Cannot find 'Player' script");
        }
        target = player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    //Enemy Movement - beeline for player
    private void Movement()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    public void takeDamage()
    {
        MaxHealth -= 25;

        if (MaxHealth <= 0)
        {
            gameController.AddScore(10);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "killbox" || other.tag == "Enemy")
        {
            return;
        }
        else if (other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            return;
        }
        else if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            takeDamage();
        }
        
    }
}
