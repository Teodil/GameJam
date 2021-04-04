using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerContol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioMixer mixer;


    public void SetMusicVolume(float value)
    {
        Debug.Log("SetMusicVolume " + value);
        mixer.SetFloat("musicVolume", value);
    }

    public void SetSoundsVolume(float value)
    {
        Debug.Log("SetSoundsVolume " + value);
        mixer.SetFloat("soundsVolume", value);
    }


}
