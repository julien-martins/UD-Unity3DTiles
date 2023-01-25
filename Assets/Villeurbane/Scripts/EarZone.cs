using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarZone : MonoBehaviour
{
    public Light light;
    public MeshRenderer sphereRenderer;

    public Color safeColor;
    public Color dangerColor;
    public Color helpColor;
    
    public Material safeMat;
    public Material dangerMat;
    public Material helpMat;

    private int numberOfObstacles = 0;

    private bool helpZone = false;
    
    void Update()
    {
        light.color = safeColor;
        sphereRenderer.material = safeMat;
        
        if (numberOfObstacles != 0) {
            light.color = dangerColor;
            sphereRenderer.material = dangerMat;
        }

        if (helpZone) {
            light.color = helpColor;
            sphereRenderer.material = helpMat;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("People"))
        {
            var p = other.gameObject.GetComponentInParent<People>();
            p.UnmuteAudio();
        } else if (other.CompareTag("Obstacle"))
        {
            numberOfObstacles++;
        } else if (other.CompareTag("Help"))
        {
            helpZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("People"))
        {
            var p = other.gameObject.GetComponentInParent<People>();
            p.MuteAudio();
        } else if (other.CompareTag("Obstacle"))
        {
            numberOfObstacles--;
        } else if (other.CompareTag("Help"))
        {
            helpZone = false;
        }
    }
}
