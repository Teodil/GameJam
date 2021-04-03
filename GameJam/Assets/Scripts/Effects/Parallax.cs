using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, startpos2;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
        startpos = transform.position.x;
        startpos2 = transform.position.y;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float yd = cam.transform.position.y;
        transform.position = new Vector3(startpos + dist+4, startpos2+1 + yd, transform.position.z);
        
    }
}
