using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefixCam : MonoBehaviour
{

    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = new Vector3(-22.77f, 548.10f, -8.0f);
        cam.transform.rotation = Quaternion.Euler(90, 0, -90);
        cam.orthographicSize = -219.7f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
