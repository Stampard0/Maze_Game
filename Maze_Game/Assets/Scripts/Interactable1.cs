using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactable1 : MonoBehaviour, IInteractable
{
    //[SerializeField] private Image Descript;
    [SerializeField] private Object Wall;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate()
    {
        //Wall.gameObject.SetActive(false);
        //Descript.gameObject.SetActive(true);
        Debug.Log("Active");
        gameObject.SetActive(false);
        Open1.item1Collected.Invoke();
        Debug.Log("Interact");
    }
}
