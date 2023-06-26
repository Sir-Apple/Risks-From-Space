using UnityEngine;
using System.Collections;

public class KillRock : MonoBehaviour
{
    private GameController gameController;
    public GameObject explosion;

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
        gameController.AddScore(3);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}