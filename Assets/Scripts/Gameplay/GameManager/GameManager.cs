using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Jugador playerScript;

    private void Start()
    {
        playerScript = GameObject.Find("Personaje").GetComponent<Jugador>(); // BUG: Lo instanciamos a mano porque no lo toma del inspector
    }
    public void PlayerAttack(){
        if(!playerScript.IsAttacking())
            playerScript.Attack();
    }

    public void PlayerMove(Vector2 posicionNueva){
        if(!playerScript.IsAttacking())
            playerScript.movementScript.SetNewMovementPosition(posicionNueva);
        
    }

    public void ExitGame(){
        Application.Quit();
    }


}
