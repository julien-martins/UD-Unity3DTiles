using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("People"))
        {
            var p = other.gameObject.GetComponentInParent<People>();
            p.UnmuteAudio();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("People"))
        {
            var p = other.gameObject.GetComponentInParent<People>();
            p.MuteAudio();
        }
    }
}
