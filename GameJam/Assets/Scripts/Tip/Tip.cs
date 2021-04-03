using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour

{
    Canvas canvas;
    [SerializeField]
    private List<Graphic> spriteRenderersToShow; 
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
        while(spriteRenderersToShow[1].color.a < 1)
        {
            for (int i = 0; i < spriteRenderersToShow.Count; i++)
            {
                Debug.Log("Появляется");
                spriteRenderersToShow[i].color = new Color(spriteRenderersToShow[i].color.r, spriteRenderersToShow[i].color.g, spriteRenderersToShow[i].color.b, spriteRenderersToShow[i].color.a + 1 * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Конец куратины показать");
    }

    private IEnumerator HideSprite()
    {
        Debug.Log("Начало куратины спрятать");
        while (spriteRenderersToShow[1].color.a > 0)
        {
            for (int i=0;i<spriteRenderersToShow.Count;i++)
            {
                Debug.Log("Исчезает");
                spriteRenderersToShow[i].color = new Color(spriteRenderersToShow[i].color.r, spriteRenderersToShow[i].color.g, spriteRenderersToShow[i].color.b, spriteRenderersToShow[i].color.a - 1 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
        Debug.Log("Конец куратины спрятать");
    }

}
