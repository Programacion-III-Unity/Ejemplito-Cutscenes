using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renderer : MonoBehaviour
{
    [SerializeField] Jugador jugadorScript;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start()
    {
        jugadorScript = GetComponent<Jugador>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Flip(string direction){
        if(direction == "left") spriteRenderer.flipX = true;
        if (direction == "right") spriteRenderer.flipX = false;

    }
}
