using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAtk : MonoBehaviour
{
    public int damageToDeal;
    private Rigidbody2D theRB2D;
    public float bounceForce;
    // Start is called before the first frame update
    void Start()
    {
        theRB2D = transform.parent.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HurtBox")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageToDeal);
            theRB2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}