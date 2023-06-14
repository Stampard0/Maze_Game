using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Open1 : MonoBehaviour
{
    public static UnityEvent item1Collected;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        item1Collected = new UnityEvent();
        item1Collected.AddListener(Destroy1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Destroy1()
    {
         gameObject.SetActive(false);
    }
}
