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




    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Death zone triggered!");
        if (other.gameObject.CompareTag("Player"))
        {
            //destroy the player
            Destroy(other.gameObject);
            Debug.Log("Enemy Touched!");
        }
    }
}
