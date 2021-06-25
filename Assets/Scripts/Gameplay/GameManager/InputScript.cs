using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;


    public void Start(){
        gameManager = GetComponent<GameManager>();
    }

    public void OnDisparo(InputValue value){
        if ((float)value.Get() == 1f){
            gameManager.DisparoDelJugador();
        }
    }

    public void OnMovimiento(InputValue value){
        gameManager.MoveJugador((Vector2)value.Get());
    }

    public void OnSalir(InputValue value){
        gameManager.SalirDelJuego();
    }

}
