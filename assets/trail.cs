using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour
{
    public Transform transform1;
    public Transform player;
    public Vector3 posXYZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform1.position = player.position + posXYZ;
    }
}
