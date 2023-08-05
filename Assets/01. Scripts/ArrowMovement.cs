using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float minAlpha = 0.25f;
    public float alphaOffset = 1.57f;
    public float speed = 2.0f;
    public float distanceMultiplier = 0.0005f;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        // Move the arrow back and forth using the sin function, dependent on rotation
        transform.position += transform.right * Mathf.Sin(Time.time * speed) * distanceMultiplier;
        _spriteRenderer.color = new Color(1, 1, 1, Mathf.Abs(Mathf.Sin(Time.time * speed + alphaOffset)) + minAlpha);
    }
}
