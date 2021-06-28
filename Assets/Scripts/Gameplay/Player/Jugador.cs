using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador: MonoBehaviour
{
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
        playerTransform = GetComponent<Transform>();
        movementScript = GetComponent<Movement>();
        gameManager = GetComponent<GameManager>();
        animationScript = GetComponent<Animation>();
        rendererScript = GetComponent<Renderer>();

        status = new Dictionary<string, bool>();
        status.Add("Jumping", false);
        status.Add("Attacking", false);
        status.Add("Idle", false);
        status.Add("Running", false);

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
        Walk();
    }


    private void Walk(){
        playerTransform.position = movementScript.MoveHorizontally(playerTransform, nuevaPosicionMovimiento, velocidad);
        animationScript.DoWalk(nuevaPosicionMovimiento.x);
        
    }

    public void Attack(){
        
        animationScript.DoAttack();
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in enemiesHit)
        {
            Debug.Log("Hit" + enemy.name);
        }
        //nuevaBala.transform.parent = GameObject.Find("__Dynamic").transform;

    }


    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.DrawSphere(AttackPoint.position, attackRange);
    }

    
}
