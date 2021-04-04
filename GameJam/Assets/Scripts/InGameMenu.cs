using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;

    [SerializeField]
    private bool IsOpen = false;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsOpen)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
        IsOpen = false;
    }

    public void Pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
        IsOpen = true;
    }
}
