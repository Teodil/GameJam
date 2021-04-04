using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipVanish : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float albedoDelta = 1f;
    [SerializeField]
    private List<SpriteRenderer> GraphicToShow;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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

    private IEnumerator HideSprite()
    {
        Debug.Log("Начало куратины показать");
        while (GraphicToShow[0].color.a < 1)
        {
            foreach (SpriteRenderer graphic in GraphicToShow)
            {
                Debug.Log("Исчезает");
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, graphic.color.a + albedoDelta * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();

        }
        Debug.Log("Конец куратины показать");
    }

    private IEnumerator ShowSprite()
    {
        Debug.Log("Начало куратины спрятать");
        while (GraphicToShow[0].color.a > 0)
        {
            foreach (SpriteRenderer graphic in GraphicToShow)
            {
                Debug.Log("Исчезает");
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, graphic.color.a - albedoDelta * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Конец куратины спрятать");
    }

}
