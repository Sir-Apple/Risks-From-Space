using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Player : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float rX, rY, rZ;
    public Boundary boundary;

    public GameObject shot;
    public AudioSource shootSound;
    public Transform shotSpawn;
    public float fireRate;
    public int MaxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private float nextFire;
    public GameObject explosion;


    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shootSound.Play();
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);


        if (currentHealth <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "killbox")
        {
            return;
        }
        else if (other.tag == "Enemy")
        {
            takeDamage(10);
            return;
        }
        else if (other.tag == "EnemyBullet")
        {
            takeDamage(1);
            return;
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

       GetComponent<Rigidbody>().rotation = Quaternion.Euler(rX + GetComponent<Rigidbody>().velocity.x * -tilt, rY, rZ);
    }
}