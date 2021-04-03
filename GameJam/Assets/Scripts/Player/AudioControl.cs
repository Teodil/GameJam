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
    private int currentSound = 0;

    [SerializeField]
    private float TimeForNextSound = 0;
    [SerializeField]
    private float gapBetweenSounds = 0.2f;
    
    void Start()
    {
        StepSoundSource = GetComponent<AudioSource>();
    }

    public void PlaySoundAndNext()
    {
        if (TimeForNextSound <= 0)
        {
            StepSoundSource.PlayOneShot(Sounds[currentSound]);
            currentSound++;
            if (currentSound == Sounds.Count)
                currentSound = 0;
            TimeForNextSound = gapBetweenSounds;
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        while (TimeForNextSound >= 0)
        {
            TimeForNextSound -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
