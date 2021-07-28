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
    

    float newVerticalPosition;
    float horizontalVelocity;
    float verticalVelocity;


    void Start(){
        playerScript = GetComponent<Jugador>();
        this.verticalVelocity = 0;
        this.horizontalVelocity = 0;
    }

    bool playerIsFalling() => this.verticalVelocity < 0;

    void Update(){
        if (playerScript.IsJumping() && playerScript.IsTouchingGround())
            verticalVelocity = jumpStrength;
    }

    void FixedUpdate(){
        setMovementVelocity();
        checkIfPlayerTouchesGround();
        managePlayerMovement();
    }

    void setMovementVelocity(){
        horizontalVelocity = newVerticalPosition * walkingSpeed;
        verticalVelocity -= gravity;
    }
    void checkIfPlayerTouchesGround(){
        if (playerIsFalling() && playerScript.IsTouchingGround()) { 
            verticalVelocity = 0;
            playerScript.SetStatus("Jumping", false);
            playerScript.SetStatus("Falling", false);
            playerScript.animationScript.Animator.SetBool("Falling", false);
            playerScript.animationScript.Animator.SetBool("Jumping", false);
        }
    }

    void managePlayerMovement(){
        setPlayerRunningStatus();
        managePlayerFlip(newVerticalPosition);
        movePlayer();
    }

    void managePlayerFlip(float x){
        if (x < 0) playerScript.playerTransform.rotation = Quaternion.Euler(0, 180, 0);
        if (x > 0) playerScript.playerTransform.rotation = Quaternion.identity;

    }

    private void setPlayerRunningStatus(){
        if (newVerticalPosition == 0 && playerScript.IsTouchingGround())
            playerScript.SetStatus("Running", true);
        else
            playerScript.SetStatus("Running", false);
    }

    private void movePlayer(){
        var movementVector = new Vector3(horizontalVelocity * Time.fixedDeltaTime, verticalVelocity * Time.fixedDeltaTime);
        playerScript.playerTransform.Translate(movementVector, Space.World);
        playerScript.animationScript.DoWalk(newVerticalPosition);

        if (!playerScript.IsTouchingGround() && verticalVelocity < 0) { 
            playerScript.SetStatus("Jumping", false);
            playerScript.SetStatus("Falling", true);

            if(!playerScript.animationScript.Animator.GetBool("Falling")) playerScript.animationScript.FallDown();
        }
        
    }


    public void SetNewHorizontalPosition(float position){
        this.newVerticalPosition = position;
    }
    

    
    public void PlayerStartJump(){
        playerScript.SetStatus("Jumping", true);
        playerScript.SetStatus("Falling", false);
        playerScript.animationScript.JumpUp();
    }



    public float GetGravity()
    {
        return this.gravity;
    }

    public float GetWalkingSpeed()
    {
        return this.walkingSpeed;
    }

    public float GetJumpStrenght()
    {
        return this.jumpStrength;
    }

    public float GetVerticalVelocity()
    {
        return this.verticalVelocity;
    }

    public float GetHorizontalVelocity()
    {
        return this.horizontalVelocity;
    }

    public float GetNewVerticalPosition()
    {
        return this.newVerticalPosition;
    }
}
