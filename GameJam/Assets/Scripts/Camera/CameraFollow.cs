using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    Transform player;

    [SerializeField]
    private float xOffset = 22.72481f;
    [SerializeField]
    private float yOffset = 10.9f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.position + new Vector3(xOffset, yOffset, transform.position.z);
    }
}
