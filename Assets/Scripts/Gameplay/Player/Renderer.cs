using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renderer : MonoBehaviour
{
    [SerializeField] Jugador playerScript;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start()
    {
        playerScript = GetComponent<Jugador>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

}
