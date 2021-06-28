using System;
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

    public void MoveHorizontally(ref Transform gameObject, Vector2 newPosition){
        float speedScaled = Time.fixedDeltaTime * walkingSpeed;
        gameObject.Translate(Vector3.right * newPosition.x * speedScaled , Space.World);
        
    }

    public void MoveVertically(ref Transform gameObject){
        float gravityScaled = Time.fixedDeltaTime * gravity;
        gameObject.Translate(Vector3.down * gravityScaled, Space.World);
    }

    public void Jump(ref Transform gameObject){
        float jumpStrengthScaled = Time.fixedDeltaTime * jumpStrength;
        gameObject.Translate(Vector3.up * jumpStrengthScaled);
    }
}
