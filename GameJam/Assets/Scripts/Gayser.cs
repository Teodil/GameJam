using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gayser : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Image ImageToShow;

    [SerializeField]
    private bool IsShown = false;

    [Header("Настройка гейзера")]
    [SerializeField]
    private float ReloadTime = 5f;
    [SerializeField]
    private float TimeToShow = 1f;
    [SerializeField]
    private float TimeToHide = 1f;
    [SerializeField]
    private float ShowTime = 10f;


    [Header("Текущее состояние")]
    [SerializeField]
    private float CurrentShowTime = 0;
    [SerializeField]
    private float currentReloadTime = 0;
    [SerializeField]
    private float currentShowHideTime = 0;

    void Start()
    {
        ImageToShow = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ReloadTime > 0)
        {
            ReloadTime -= 0.1f;
            return;
        }

        StartCoroutine(ShowHideCoroutine(true));


    }

   private IEnumerator ShowHideCoroutine(bool isShow)
    {
        if (isShow)
        {
            while (currentShowHideTime < TimeToShow)
            {
                currentShowHideTime += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            currentShowHideTime = 0;
            IsShown = true;
        }
        else
        {
            while (currentShowHideTime < TimeToHide)
            {
                currentShowHideTime += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            currentShowHideTime = 0;
            IsShown = false;
        }
    }
}
