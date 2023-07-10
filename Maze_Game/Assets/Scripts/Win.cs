using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    private GameHUD manager;

    private void Awake()
    {
        manager = FindObjectOfType<GameHUD>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == true)
        {
            manager.GameWin();
        }
    }
}
