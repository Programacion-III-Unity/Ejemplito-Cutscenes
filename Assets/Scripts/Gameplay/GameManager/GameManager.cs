using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Jugador jugadorScript;
    private Score score;

    private void Start()
    {
        jugadorScript = GameObject.Find("Personaje").GetComponent<Jugador>(); // BUG: Lo instanciamos a mano porque no lo toma del inspector
        score = GameObject.Find("Score").GetComponent<Score>();
    }
    public void DisparoDelJugador(){
        jugadorScript.Disparar();
    }

    public void MoveJugador(Vector2 posicionNueva){
        jugadorScript.SetNuevaPosicionMovimiento(posicionNueva);
        
    }

    public void SalirDelJuego(){
        Application.Quit();
    }


}
