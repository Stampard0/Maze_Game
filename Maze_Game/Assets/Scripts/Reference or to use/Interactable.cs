using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private Image Descript;
    //Image image;
    public float waitTime = 5;
    //WaitForSecondsRealtime waitForSecondsRealtime;
    // Start is called before the first frame update
    void Start()
    {
        //Descript = GetComponent<Image>();
        Descript.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DoActiveWait()
    {
        //print(Time.time);
        //if (waitForSecondsRealtime == null)
        //{
        //Descript.gameObject.SetActive(false);
        //}
        //else
        //{
        //waitForSecondsRealtime.waitTime = waitTime;
        //}
        //yield return waitForSecondsRealtime;
        yield return new WaitForSeconds(waitTime);
        Descript.gameObject.SetActive(false);
        gameObject.layer = 3;
    }
    public void Activate()
    {
        Descript.gameObject.SetActive(true);
        Debug.Log("Active");
        StartCoroutine(DoActiveWait());
        gameObject.layer = 0;
    }
    
}
