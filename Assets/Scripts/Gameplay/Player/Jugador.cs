using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Jugador: MonoBehaviour{
    public Movement movementScript;
    public Animation animationScript;
    public Transform playerTransform;

    [SerializeField] float attackRange;
    [SerializeField] float actorHeight;
    [SerializeField] Transform AttackPoint;
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] Renderer rendererScript;
    [SerializeField] CinemachineVirtualCamera cinemachineCamera;

    GameManager gameManager;
    LayerMask enemyLayers;
    Dictionary<string, bool> status;

    void Start() {
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.playerTransform = GetComponent<Transform>();
        this.movementScript = GetComponent<Movement>();
        this.animationScript = GetComponent<Animation>();
        this.rendererScript = GetComponent<Renderer>();
        this.cinemachineCamera = GetComponent<CinemachineVirtualCamera>(); 

        this.status = new Dictionary<string, bool>();
        this.status.Add("Jumping", false);
        this.status.Add("Attacking", false);
        this.status.Add("Idle", false);
        this.status.Add("Running", false);
        this.status.Add("TouchingGround", false);
        this.status.Add("Falling", false);
    }

    public void SetStatus(string stat, bool value){
        this.status[stat] = value;
    }
    public bool IsAttacking(){
        if (this.status["Attacking"]) return true;
        else return false;
    }
    public bool IsJumping(){
        if (this.status["Jumping"]) return true;
        return false;
    }
    public bool IsFalling()
    {
        if (this.status["Falling"]) return true;
        return false;
    }

    public bool IsTouchingGround(){
        if (this.status["TouchingGround"]) return true;
        else return false;
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


    void OnTriggerEnter2D(Collider2D otherObject){
        GameObject objeto = otherObject.gameObject;
        if (objeto.tag == "Ground"){
            this.status["TouchingGround"] = true;
            this.status["Jumping"] = false;
            this.status["Falling"] = false;
        }
        if (objeto.tag == "Finish")
        {
            // Hacer que la camara deje de seguir
        }

        if (objeto.tag == "HellItSelf"){
            Destroy(this.gameObject);
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
        Gizmos.DrawWireSphere(this.AttackPoint.position, this.attackRange);
    }

    
}
