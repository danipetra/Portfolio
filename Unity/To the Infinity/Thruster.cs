using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{
    TrailRenderer trailRenderer;
    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    public void Activate(bool activate = true)
    {
        if (activate)
        {
            trailRenderer.enabled = true;
        }

        else
        {
            trailRenderer.enabled = false;
        }
    }
}
