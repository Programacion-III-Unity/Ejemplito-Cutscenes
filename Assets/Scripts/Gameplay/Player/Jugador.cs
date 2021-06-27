using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador: MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private float velocidad;
    [SerializeField] private Movement movementScript;
    [SerializeField] private Animation animationScript;
    [SerializeField] private Renderer rendererScript;
    [SerializeField] private GameManager gameManager;

     
    Transform transformJugador; 
    private Vector2 nuevaPosicionMovimiento;
    
    
    void Start() {
        transformJugador = GetComponent<Transform>();
        movementScript = GetComponent<Movement>();
        gameManager = GetComponent<GameManager>();
        animationScript = GetComponent<Animation>();
        rendererScript = GetComponent<Renderer>();
    }

    public void SetMovementPositionAndRotation(Vector2 posicion){
        this.nuevaPosicionMovimiento = posicion;
        flip(posicion.x);
    }

    private void flip(float x){
        if (x < 0) rendererScript.Flip("left");
        if (x > 0) rendererScript.Flip("right");
    }

    void Update(){
        Walk();
    }

    private void Walk(){
        transformJugador.position = movementScript.MoveHorizontally(transformJugador, nuevaPosicionMovimiento, velocidad);
        animationScript.DoWalk(nuevaPosicionMovimiento.x);
        
    }

    public void Disparar(){
        GameObject nuevaBala;
        nuevaBala = Instantiate(bala, transformJugador.position, transformJugador.rotation);
        nuevaBala.transform.parent = GameObject.Find("__Dynamic").transform;

    }



    
}
