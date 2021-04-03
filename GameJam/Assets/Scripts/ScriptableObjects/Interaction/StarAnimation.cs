using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartAnimation", menuName = "StartAnimation", order = 51)]
public class StarAnimation : InteractActions
{

    private Animator animator;
    public override void ToDoAction(GameObject gameObject, bool MakeOnce)
    {
        if (gameObject.TryGetComponent<Animator>(out animator))
        {
            animator.SetTrigger("StartAnimation");
        }
    }
}
