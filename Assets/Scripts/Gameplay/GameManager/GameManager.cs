using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class GameManager : MonoBehaviour {
    public static GameManager GM;

    private Jugador playerScript;
    private GameObject playerObject;
    private Score scoreScript;
    Dictionary<string, int> globalValues;

    [SerializeField] private GameObject playerPrefab;

    void Awake(){
        if (GM != null)
            GameObject.Destroy(GM);
        else
            GM = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        this.globalValues = new Dictionary<string, int>();
        this.globalValues.Add("PlayerLives", 3);
        this.SpawnPlayer();
    }

    public int GetPlayerLives() => this.globalValues["PlayerLives"];
    public Jugador GetJugador() => this.playerObject.GetComponent<Jugador>();

    public void PlayerDied()
    {
        this.globalValues["PlayerLives"]--;

        if (this.globalValues["PlayerLives"] > 0)
        {
            SpawnPlayer();
        }
        else
        {
            Debug.Log("GameOver");
        }
    }
    private void SpawnPlayer()
    {
        Debug.Log(this.globalValues["PlayerLives"]);
        CinemachineVirtualCamera vcam = GameObject.Find("CineMachineVirtualCamera").GetComponent<CinemachineVirtualCamera>();
        Transform spawnLocation = GameObject.Find("PlayerSpawnPoint").GetComponent<Transform>();

        playerObject = Instantiate(playerPrefab, spawnLocation.position, Quaternion.identity);
        playerObject.transform.parent = GameObject.Find("Player").transform;
        playerScript = playerObject.GetComponent<Jugador>();
        vcam.m_Follow = playerObject.transform;

    }
    public void PlayerAttack(){
        if(!playerScript.IsAttacking())
            playerScript.Attack();
    }

    public void PlayerMove(Vector2 posicionNueva){
        if(!playerScript.IsAttacking())
            playerScript.movementScript.SetNewHorizontalPosition(posicionNueva.x);
    }

    public void PlayerJump(){
        if (!playerScript.IsAttacking() && playerScript.IsTouchingGround())
            playerScript.movementScript.PlayerStartJump();

    }

    public void ExitGame(){
        Application.Quit();
    }


}
