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

    Vector2 newMovementPosition;



    void Start(){
        playerScript = GetComponent<Jugador>();
    }

    private void FixedUpdate(){
        if (!playerScript.IsTouchingGround())
            this.applyGravity();

        if(!playerScript.IsAttacking())
            this.MovePlayerHorizontally(newMovementPosition);
    }

    void applyGravity(){
        this.MovePlayerVertically();
    }

    public void SetNewMovementPosition(Vector2 position){
        this.newMovementPosition = position;
        this.managePlayerFlip(position.x);
    }
    public void MovePlayerHorizontally(Vector2 newPosition){
        float speedScaled = Time.fixedDeltaTime * walkingSpeed;
        playerScript.playerTransform.Translate(Vector3.right * newPosition.x * speedScaled , Space.World);
        playerScript.animationScript.DoWalk(newPosition.x);
        
    }

    private void managePlayerFlip(float x){
        if (x < 0) playerScript.playerTransform.rotation = Quaternion.Euler(0, 180, 0);
        if (x > 0) playerScript.playerTransform.rotation = Quaternion.identity;
        
    }

    public void MovePlayerVertically(){
        float gravityScaled = Time.fixedDeltaTime * gravity;
        playerScript.playerTransform.Translate(Vector3.down * gravityScaled, Space.World);
    }


}
