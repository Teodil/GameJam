using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigidbody;
    private float right;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool IsRightMove = true;

    [SerializeField]
    private bool isClicked = false;

    [SerializeField]
    private AudioControl audioControl;

    [Header("Настройка скорости")]
    [SerializeField]
    private float speed = 5f;

    [Header("Настройки Стрейфа")]
    [SerializeField]
    private float timerFoDoubleClick = 0;
    [SerializeField]
    private float maxTimeForDoubleClick = 0.01f;
    [SerializeField]
    private float strafeForce = 10f;
    [SerializeField]
    private float reloadStrafeTime = 5f;
    [SerializeField]
    private float currentReloadStrafeTime = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioControl = GetComponent<AudioControl>();
    }

    // Update is called once per frame
    void Update()
    {

        SpriteFlipper();

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))//Обработка Нажатия на клавиши
        {
            if (!isClicked)//Проверка была ли нажата до этого клавиша
            {
                Debug.Log("Обновление таймера");
                timerFoDoubleClick = 0;
                isClicked = true;
            }
            else
            {
                if (timerFoDoubleClick < maxTimeForDoubleClick && currentReloadStrafeTime <= 0)
                    Strafe();
                else
                    isClicked = false;
            }

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (currentReloadStrafeTime < reloadStrafeTime-0.2f)
            {
                right = speed * Input.GetAxis("Horizontal");
                rigidbody.velocity = new Vector2(right, rigidbody.velocity.y);
                audioControl.PlaySoundAndNext();


            }
        }
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && timerFoDoubleClick > maxTimeForDoubleClick)
            isClicked = false;

        timerFoDoubleClick += Time.deltaTime;
        animator.SetInteger("Velocity", (int)Input.GetAxis("Horizontal") * 100);
    }


    private void SpriteFlipper()
    {
        if (IsRightMove && Input.GetAxis("Horizontal")<0)
        {
            spriteRenderer.flipX = true;
            IsRightMove = false;
        }
        if(!IsRightMove && Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
            IsRightMove = true;
        }
    }

    private void Strafe()
    {
        rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        float accelerate = strafeForce * MathExten.GetSign(Input.GetAxis("Horizontal"));
        Debug.Log("Ускорение " + accelerate);
        rigidbody.AddForce(new Vector2(accelerate, 0), ForceMode2D.Impulse);
        currentReloadStrafeTime = reloadStrafeTime;
        StartCoroutine(ReloadStrafeCoroutine());
    }

    private IEnumerator ReloadStrafeCoroutine()
    {
        while(currentReloadStrafeTime > 0)
        {
            currentReloadStrafeTime -= Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }


    public void Jump(float jumpForce)
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        Debug.Log(rigidbody.velocity);
    }

}
