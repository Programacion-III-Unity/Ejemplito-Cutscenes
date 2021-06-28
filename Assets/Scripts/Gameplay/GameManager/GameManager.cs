using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Jugador jugadorScript;

    private void Start()
    {
        jugadorScript = GameObject.Find("Personaje").GetComponent<Jugador>(); // BUG: Lo instanciamos a mano porque no lo toma del inspector
    }
    public void PlayerAttack(){
        if(!jugadorScript.IsAttacking())
            jugadorScript.Attack();
    }

    public void MoveJugador(Vector2 posicionNueva){
        if(!jugadorScript.IsAttacking())
            jugadorScript.SetMovementPositionAndRotation(posicionNueva);
        
    }

    public void SalirDelJuego(){
        Application.Quit();
    }


}
