using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneStart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
