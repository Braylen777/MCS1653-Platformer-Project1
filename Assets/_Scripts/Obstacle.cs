using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float startSpeed = 5.0f;
    void Start()
    {
        //transform.position = new Vector3(1, 1, 1);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            //Obstacle moves right
           rb.velocity = transform.right * startSpeed;
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Death zone triggered!");
        if (gameObject.CompareTag("Player"))
        {
            //destroy the player
            Destroy(gameObject);
            Debug.Log("Enemy Touched!");
        }
    }
}
