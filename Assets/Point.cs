using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private Color newColor;
    [SerializeField] private SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor()
    {
        rend.color = newColor;
    }

    public int GetNumber()
    {
        return number;
    }
}
