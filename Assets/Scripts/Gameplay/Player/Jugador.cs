using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador: MonoBehaviour{
    [SerializeField] float attackRange;
    [SerializeField] float actorHeight;
    [SerializeField] Transform AttackPoint;
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] Movement movementScript;
    [SerializeField] Animation animationScript;
    [SerializeField] Renderer rendererScript;
    [SerializeField] GameManager gameManager;
    


    Transform playerTransform;
    Vector2 nuevaPosicionMovimiento;
    LayerMask enemyLayers;
    Dictionary<string, bool> status;

    void Start() {
        this.playerTransform = GetComponent<Transform>();
        this.movementScript = GetComponent<Movement>();
        this.gameManager = GetComponent<GameManager>();
        this.animationScript = GetComponent<Animation>();
        this.rendererScript = GetComponent<Renderer>();

        this.status = new Dictionary<string, bool>();
        this.status.Add("Jumping", false);
        this.status.Add("Attacking", false);
        this.status.Add("Idle", false);
        this.status.Add("Running", false);
        this.status.Add("TouchingGround", false);
    }

    void FixedUpdate(){
        if (!this.IsAttacking())
            horizontalMovement();

        if (!this.IsJumping() && !this.IsTouchingGround())
            applyGravity();

        if (this.MustJump())
            jump();
    }


    public void SetMovementPositionAndRotation(Vector2 posicion){
        this.nuevaPosicionMovimiento = posicion;
        flip(posicion.x);
    }

    void flip(float x){
        if (x < 0) playerTransform.rotation = Quaternion.Euler(0, 180, 0);
        if (x > 0) playerTransform.rotation = Quaternion.identity;
    }

    public void SetJump(){
        this.status["Jumping"] = true;
    }


    void applyGravity(){
        movementScript.MoveVertically(ref this.playerTransform);
    }

     void horizontalMovement(){
        movementScript.MoveHorizontally(ref this.playerTransform, this.nuevaPosicionMovimiento);
        this.animationScript.DoWalk(this.nuevaPosicionMovimiento.x);
    }

    private void jump(){
        this.status["TouchingGround"] = false;
        movementScript.Jump(ref this.playerTransform);
    }
    public void Attack(){
        this.status["Attacking"] = true;
        this.animationScript.DoAttack();
        detectDamagedEnemies();
    }

     void attackEnd(){
        this.status["Attacking"] = false;
    }

     void detectDamagedEnemies(){
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(this.AttackPoint.position, this.attackRange, this.enemyLayers);
        foreach (Collider2D enemy in enemiesHit){
            Debug.Log("Hit" + enemy.name);
        }
    }

    public bool IsAttacking(){
        if (this.status["Attacking"]) return true;
        else return false;
    }

    public bool IsJumping(){
        if (this.status["Jumping"]) return true;
        else return false;
    }
    public bool IsTouchingGround(){
        if (this.status["TouchingGround"]) return true;
        else return false;
    }
    private bool MustJump(){
        if (this.status["Jumping"] && this.status["TouchingGround"]) return true;
        else return false;
    }

    void OnTriggerEnter2D(Collider2D otherObject){
        GameObject objeto = otherObject.gameObject;
        if (objeto.tag == "Ground"){
            this.status["TouchingGround"] = true;
            this.status["Jumping"] = false;
        }
    }
    void OnTriggerExit2D(Collider2D otherObject){
        GameObject objeto = otherObject.gameObject;
        if (objeto.tag == "Ground"){
            this.status["TouchingGround"] = false;
            this.status["Jumping"] = true;
        }
    }

    void OnDrawGizmosSelected(){
        if (this.AttackPoint == null) return;
        Gizmos.DrawSphere(this.AttackPoint.position, this.attackRange);
    }

    
}
