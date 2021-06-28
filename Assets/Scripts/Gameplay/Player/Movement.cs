using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Jugador playerScript;
    [SerializeField] float gravity;
    [SerializeField] float walkingSpeed;
    [SerializeField] float jumpStrength;



     void Start(){
        playerScript = GetComponent<Jugador>();
    }

    public Vector2 MoveHorizontally(Transform gameObject, Vector2 newPosition){
        float speedScaled = Time.fixedDeltaTime * walkingSpeed;
        gameObject.Translate(Vector3.right * newPosition.x * speedScaled , Space.World);
        return gameObject.position;
    }

    public Vector2 MoveVertically(Transform gameObject){
        float gravityScaled = Time.fixedDeltaTime * gravity;
        gameObject.Translate(Vector3.down * gravityScaled, Space.World);
        return gameObject.position;
    }




}
