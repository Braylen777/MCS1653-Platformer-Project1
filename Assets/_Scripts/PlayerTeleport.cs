using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject PlayerPrefab;

    void Start()
    {
        CreatePlayer();
    }
    public void CreatePlayer()
    {
        //PlayerPrefab.SetActive(true);
        Instantiate(PlayerPrefab, new Vector2(-4f, 3.05f), Quaternion.identity);

    }
}

