using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador: MonoBehaviour{
    [SerializeField] private float velocidad;
    [SerializeField] private Movement movementScript;
    [SerializeField] private Animation animationScript;
    [SerializeField] private Renderer rendererScript;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private Transform AttackPoint;

    private Vector2 nuevaPosicionMovimiento;
    private Dictionary<string, bool> status;
    Transform playerTransform;
    LayerMask enemyLayers;

    
    
    
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

    }

    public void SetMovementPositionAndRotation(Vector2 posicion){
        this.nuevaPosicionMovimiento = posicion;
        flip(posicion.x);
    }

    private void flip(float x){
        if (x < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        if (x > 0) transform.rotation = Quaternion.identity;
    }

    void Update(){
        if(!this.IsAttacking())
            Walk();
    }


    private void Walk(){
        this.playerTransform.position = movementScript.MoveHorizontally(this.playerTransform, this.nuevaPosicionMovimiento, this.velocidad);
        this.animationScript.DoWalk(this.nuevaPosicionMovimiento.x);
        
    }

    public void Attack(){
        this.status["Attacking"] = true;
        this.animationScript.DoAttack();
        detectDamagedEnemies();
    }

    public bool IsAttacking(){
        if (this.status["Attacking"]) return true;
        else return false;
    }

    private void detectDamagedEnemies(){
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(this.AttackPoint.position, this.attackRange, this.enemyLayers);
        foreach (Collider2D enemy in enemiesHit){
            Debug.Log("Hit" + enemy.name);
        }
    }

    private void attackEnd(){
        this.status["Attacking"] = false;
    }

    void OnDrawGizmosSelected(){
        if (this.AttackPoint == null) return;
        Gizmos.DrawSphere(this.AttackPoint.position, this.attackRange);
    }

    
}
