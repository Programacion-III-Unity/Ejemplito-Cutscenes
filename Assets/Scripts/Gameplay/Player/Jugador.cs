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
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] int HP;

    Dictionary<string, bool> status;

    void Start() {
        this.playerTransform = GetComponent<Transform>();
        this.movementScript = GetComponent<Movement>();
        this.animationScript = GetComponent<Animation>();

        this.status = new Dictionary<string, bool>();
        this.status.Add("Jumping", false);
        this.status.Add("Attacking", false);
        this.status.Add("Idle", false);
        this.status.Add("Running", false);
        this.status.Add("TouchingGround", false);
        this.status.Add("Falling", false);

        this.HP = 100;
    }

    public int GetHP()
    {
        return this.HP;
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
    }

     void attackEnd(){
        this.status["Attacking"] = false;
    }

     void detectDamagedEnemies(){
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in enemiesHit){
            Destroy(enemy.gameObject);
            Score.PlayerScore += 10;
        }
    }

    
    void OnCollisionEnter2D(Collision2D otherObject){
        GameObject objeto = otherObject.gameObject;
        
        if (objeto.tag == "Ground"){
            this.status["TouchingGround"] = true;
            this.status["Jumping"] = false;
            this.status["Falling"] = false;
        }

        if(objeto.tag == "Enemy"){
            this.HP -= 10;
            if (this.HP <= 0){
                Debug.Log("Perdiste gil");
                Destroy(this.gameObject);
            }


        }


    }
    void OnCollisionExit2D(Collision2D otherObject){
        
        if (otherObject.gameObject.tag == "Ground"){
            this.status["TouchingGround"] = false;
            this.status["Jumping"] = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D otherObject){
        if (otherObject.gameObject.tag == "HellItSelf"){
            Destroy(this.gameObject);
        }
    }
    void OnDrawGizmosSelected(){
        if (this.AttackPoint == null) return;
        Gizmos.DrawWireSphere(this.AttackPoint.position, this.attackRange);
    }

    void OnDestroy()
    {
        GameManager.GM.PlayerDied();
    }

}
