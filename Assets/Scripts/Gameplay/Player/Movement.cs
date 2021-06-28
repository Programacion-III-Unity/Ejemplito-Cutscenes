using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Jugador jugadorScript;

    private void Start(){
        jugadorScript = GetComponent<Jugador>();
    }



    public Vector2 MoveHorizontally(Transform gameObject, Vector2 nuevaPosicion, float velocidad){
        gameObject.Translate(Vector3.right * nuevaPosicion.x * Time.deltaTime * velocidad, Space.World);
        gameObject.position = new Vector3(
            ClamplearEjeX(gameObject.position.x),
            gameObject.position.y,
            gameObject.position.z
        ) ;

        return gameObject.position;
    }

    private float ClamplearEjeX(float posicion){
        return Mathf.Clamp(posicion, (ObtenerLimiteDePantalla().x * -1f), ObtenerLimiteDePantalla().x);
    }
    private float ClamplearEjeY(float posicion){
        return Mathf.Clamp(posicion, (ObtenerLimiteDePantalla().y * -1f), ObtenerLimiteDePantalla().y);
    }

    private Vector2 ObtenerLimiteDePantalla(){
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }




}