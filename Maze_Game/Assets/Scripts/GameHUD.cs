using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private Image crosshairImg;
    //public GameObject gameObject;
    public static GameHUD Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
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
}
