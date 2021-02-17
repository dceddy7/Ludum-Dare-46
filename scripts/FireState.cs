using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FireState
{
    public string stateName;
    public int healthMin;
    public int healthMax;
    public string displayName;
    public BoxCollider2D collider;
    public ParticleSystem effect;
    public Color displayColor;
    public int burnTier;
}
