using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAim : MonoBehaviour
{

    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject rain;
    [SerializeField] private Transform rainSpawnPoint;


    private GameObject rainInst;

    private Vector2 worldPosition;
    private Vector2 direction;
    private void Update()
    {
        HandlePortalRotation();
        HandlePortalThrowing();
    }

    
    private void HandlePortalRotation()
    {
       
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)portal.transform.position).normalized;
        portal.transform.right = direction;
    }


    private void HandlePortalThrowing() 
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            rainInst = Instantiate(rain, rainSpawnPoint.position, portal.transform.rotation);
        }
            
    
    
    }






}
