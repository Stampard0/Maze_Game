using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private Image crosshairImg;
    //public GameObject gameObject;
    public static GameHUD Instance { get; private set; }
    [SerializeField] private Image winHUD;
    public float waitTime = 5;

    [SerializeField] private AudioClip collected;
    private AudioSource aSrc;

    public static UnityEvent anItemCollected;

    private void Awake()
    {
        TryGetComponent(out aSrc);
        if (Instance == null)
        {
            Instance = this;
        }
        //crosshairImg = gameObject.GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //crosshairImg = gameObject.GetComponent<Image>();
        anItemCollected = new UnityEvent();
        anItemCollected.AddListener(CollectedSound);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }
    }
    public void SetCrosshairColour(Color colour)
    {
        if (crosshairImg.color != colour)
        {
            crosshairImg.color = colour;
        }
    }
    public void CrosshairColourCan(Color colour)
    {
        crosshairImg.color = Color.green;
    }
    public void CrosshairColourCant(Color colour)
    {
        crosshairImg.color = Color.red;
    }
    IEnumerator DoActiveWait()
    {
        yield return new WaitForSeconds(waitTime);
        winHUD.gameObject.SetActive(false);
        Application.Quit();
    }
    public void GameWin()
    {
        Debug.Log("Win");
        winHUD.gameObject.SetActive(true);
        StartCoroutine(DoActiveWait());
    }
    private void CollectedSound()
    {
        aSrc.PlayOneShot(collected);
    }
}
