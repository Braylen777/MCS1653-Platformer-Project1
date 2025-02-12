using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBehavior : MonoBehaviour
{
    [Header("General Rain Stats")]
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroysRain;
    public Transform TeleportTarget;

    [Header("Normal Rain Stats")]
    [SerializeField] private float normalRainSpeed = 15f;

    [Header("Physics Rain Stats")]
    [SerializeField] private float physicsRainSpeed = 12f;
    [SerializeField] private float physicsRainGravity = 3f;

    private Rigidbody2D rb;

    public enum RainType 
    { 
        Normal,
        Physics
    }
    public RainType rainType;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();

        SetRBStats();
        
        
        InitializeRainStats();
    }

    private void InitializeRainStats() 
    {
        if (rainType == RainType.Normal)
        {
            SetStraightVelocity();
        }

        else if (rainType == RainType.Physics) 
        {
            SetPhysicsVelocity();
        }
    }
    
    
    private void SetStraightVelocity() 
    { 
        rb.velocity = transform.right * normalRainSpeed;
    }

    private void SetPhysicsVelocity()
    {
        rb.velocity = transform.right * physicsRainSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if ((whatDestroysRain.value & (1 << collision.gameObject.layer)) > 0) 
        {
            //sound
            //particles, etc
            Destroy(gameObject);
            TeleportTarget.transform.position = transform.position;
           
        }
    }




    private void SetDestroyTime() 
    {
        Destroy(gameObject, destroyTime);
    }

    private void SetRBStats ()
    {
        if (rainType == RainType.Normal) 
        {
            rb.gravityScale = 0f;
        }

        else if (rainType == RainType.Physics) 
        {  
            rb.gravityScale = physicsRainGravity;
        }
    }

    




}
