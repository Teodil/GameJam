using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string name)
    {
        Debug.Log("Загрузка " + name);
        Time.timeScale = 1;
        SceneTransition.SwitchToScene(name);
    }

    public void ExitGame()
    {
        Debug.Log("Выход");
        SceneTransition.CloseGame();
    }
}
