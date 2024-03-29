using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!canvas.activeSelf)
            {
                canvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                canvas.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }
    }

    public void OnCLick(string buttonName)
    {
        if(buttonName == "Exit Game")
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else if(buttonName == "Unpause")
        {
            canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}
