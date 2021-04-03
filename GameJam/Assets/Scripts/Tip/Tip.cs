using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour

{
    Canvas canvas;
    [SerializeField]
    private List<Graphic> GraphicToShow; 
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(ShowSprite());
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(HideSprite());
        }
    }

    private IEnumerator ShowSprite()
    {
        Debug.Log("Начало куратины показать");
        while(GraphicToShow[0].color.a < 1)
        {
            foreach (Graphic graphic in GraphicToShow)
            {
                Debug.Log("Исчезает");
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, graphic.color.a + 1 * Time.deltaTime);
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
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, graphic.color.a - 1 * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Конец куратины спрятать");
    }

}
