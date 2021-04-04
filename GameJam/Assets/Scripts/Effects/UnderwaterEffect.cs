using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class UnderwaterEffect : MonoBehaviour
{
    public Material _mat;
    [Range (0.001f, 0.1f)]
    public float pixelOffset;
    [Range(0.1f, 20f)]
    public float noiseScale;
    [Range(0.1f, 20f)]
    public float noiseFrequency;
    [Range(0.1f, 30f)]
    public float noiseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _mat.SetFloat("_NoiseFrequency", noiseFrequency);
        _mat.SetFloat("_NoiseSpeed", noiseSpeed);
        _mat.SetFloat("_NoiseScale", noiseScale);
        _mat.SetFloat("_PixelOffset", pixelOffset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination) 
    {
        Graphics.Blit(source, destination, _mat);
    }
}
