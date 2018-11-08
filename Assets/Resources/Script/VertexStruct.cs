using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CUSTOM_VERTEX
{
    public Vector3 pos; 
    public Vector3 normal;
    public Color color;

    public CUSTOM_VERTEX(Vector3 pos, Vector3 normal, Color color)
    {
        this.pos = pos;
        this.normal = normal;
        this.color = color;
    }
}
