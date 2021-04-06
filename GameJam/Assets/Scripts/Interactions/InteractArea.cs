using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractArea : MonoBehaviour
{
    [SerializeField]
    private InteractActions ActionToDo;
    [SerializeField]
    private GameObject InteractTo;
    [SerializeField]
    private bool MakeOnce = false;

    [SerializeField]
    private List<Graphic> GraphicToShow;
    [SerializeField]
    private float albedoDelta = 1f;

    private bool isIn = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isIn = true;
            StartCoroutine(ShowSprite());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Стоит в зоне действия");
        if (isIn)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Старт");
                ActionToDo.ToDoAction(InteractTo, MakeOnce);

            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isIn = false;
            StartCoroutine(HideSprite());
        }
    }



    private IEnumerator ShowSprite()
    {
        Debug.Log("Начало куратины показать");
        while (GraphicToShow[0].color.a < 1)
        {
            foreach (Graphic graphic in GraphicToShow)
            {
                Debug.Log("Исчезает");
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, graphic.color.a + albedoDelta * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();

        }
        Debug.Log("Конец куратины показать");
    }

    private IEnumerator HideSprite()
    {
        Debug.Log("Начало куратины спрятать");
        while (GraphicToShow[0].color.a > 0)
        {
            foreach (Graphic graphic in GraphicToShow)
            {
                Debug.Log("Исчезает");
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, graphic.color.a - albedoDelta * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Конец куратины спрятать");
    }

}
