using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public float duration = 15.0f;
    

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<EdgeCollider2D>().enabled = false;

        gameManager.PillPicked(this);

        yield return new WaitForSeconds(duration);

        gameManager.RemoveBuff();

        Destroy(gameObject);
    }
}
