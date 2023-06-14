using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Open2 : MonoBehaviour
{
    public static UnityEvent item2Collected;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        item2Collected = new UnityEvent();
        item2Collected.AddListener(Destroy2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Destroy2()
    {
         gameObject.SetActive(false);
    }
}
