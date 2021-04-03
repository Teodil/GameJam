using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class TimeLineFix : MonoBehaviour
{
    bool fix = false;
    [SerializeField]
    private Animator playerAnim;
    [SerializeField]
    private RuntimeAnimatorController playerContr;
    [SerializeField]
    private PlayableDirector director;

    private void OnEnable()
    {
        playerContr = playerAnim.runtimeAnimatorController;
        playerAnim.runtimeAnimatorController = null;
    }

    private void Update()
    {
        if(director.state != PlayState.Playing && !fix)
        {
            fix = true;
            playerAnim.runtimeAnimatorController = playerContr;
        }
    }
}
