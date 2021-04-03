using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField]
    private AudioSource StepSoundSource;
    [SerializeField]
    private List<AudioClip> Sounds;

    [SerializeField]
    private Jump playerJump;

    [SerializeField]
    private int currentSound = 0;

    [SerializeField]
    private float TimeForNextSound = 0;
    [SerializeField]
    private float gapBetweenSounds = 0.2f;
    
    void Start()
    {
        StepSoundSource = GetComponent<AudioSource>();
        playerJump = GetComponent<Jump>();
    }

    public void PlaySoundAndNext()
    {
        if (TimeForNextSound <= 0 && !playerJump.IsJumping)
        {
            StepSoundSource.PlayOneShot(Sounds[currentSound]);
            currentSound++;
            if (currentSound == Sounds.Count)
                currentSound = 0;
            TimeForNextSound = gapBetweenSounds;
           // StartCoroutine(Timer());
        }
    }

    void FixedUpdate() 
    {
        if (TimeForNextSound >= 0)
        {
            TimeForNextSound -= 0.1f;
        }
    }

}
