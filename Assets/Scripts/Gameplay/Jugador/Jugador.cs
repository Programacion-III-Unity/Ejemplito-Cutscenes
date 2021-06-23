using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador: MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private float velocidad;
    [SerializeField] private InputScript inputScript;
    [SerializeField] private MovementScript movementScript;
     
    Transform transformJugador; 
    private Vector2 nuevaPosicionMovimiento;
    
    
    void Start() {
        transformJugador = GetComponent<Transform>();
        movementScript = GetComponent<MovementScript>();
        inputScript = GetComponent<InputScript>();
    }

    public void SetNuevaPosicionMovimiento(Vector2 posicion){
        this.nuevaPosicionMovimiento = posicion;
    }


    void Update(){
        transformJugador.position = movementScript.Mover(transformJugador, nuevaPosicionMovimiento, velocidad);
    }

    
    

    public void Disparar(){
        GameObject nuevaBala;
        nuevaBala = Instantiate(bala, transformJugador.position, transformJugador.rotation);
        nuevaBala.transform.parent = GameObject.Find("__Dynamic").transform;

    }



    
}
