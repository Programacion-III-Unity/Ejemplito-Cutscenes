using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugInfo : MonoBehaviour
{
    [SerializeField] private Text debugText;
    Jugador jugador;

    void Start(){
        debugText = GetComponent<Text>();
        jugador = GameObject.Find("Personaje").GetComponent<Jugador>(); // BUG: Lo instanciamos a mano porque no lo toma del inspector

    }

    void FixedUpdate(){
        debugText.text = "";
        debugText.text += "Player: \n";
        debugText.text += "HP: " + jugador.GetHP().ToString() + "\n";
        debugText.text += "Posicion X: " + jugador.transform.position.x.ToString() + "\n";
        debugText.text += "Posicion Y: " + jugador.transform.position.y.ToString() + "\n";
        debugText.text += "Jumping: " + jugador.IsJumping().ToString() + "\n";
        debugText.text += "Touching Ground: " + jugador.IsTouchingGround().ToString() + "\n";
        debugText.text += "Falling: " + jugador.IsFalling().ToString() + "\n";
        debugText.text += "Attacking: " + jugador.IsAttacking().ToString() + "\n";
        debugText.text += "----------------------------------\n\n";

        debugText.text += "Movement: \n";
        debugText.text += "Gravedad: " + jugador.movementScript.GetGravity().ToString() + "\n";
        debugText.text += "Velocidad Caminar: " + jugador.movementScript.GetWalkingSpeed().ToString() + "\n";
        debugText.text += "Fuerza Salto: " + jugador.movementScript.GetJumpStrenght().ToString() + "\n";
        debugText.text += "Empuje Horizontal: " + jugador.movementScript.GetHorizontalVelocity().ToString() + "\n";
        debugText.text += "Empuje Vertical: " + jugador.movementScript.GetVerticalVelocity().ToString() + "\n";
        debugText.text += "Nueva Posicion: " + jugador.movementScript.GetNewVerticalPosition().ToString() + "\n";









    }
}
