using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    [SerializeField] Jugador jugadorScript;

    public void Start(){
        jugadorScript = GetComponent<Jugador>();
    }
    public void OnDisparo(InputValue value){

        if ((float)value.Get() == 1f){
            jugadorScript.Disparar();
        }
    }

    public void OnMovimiento(InputValue value){
        
        jugadorScript.SetNuevaPosicionMovimiento((Vector2)value.Get());
    }

    public void OnSalir(InputValue value)    {
        Application.Quit();
    }

}
