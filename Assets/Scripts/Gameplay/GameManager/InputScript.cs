using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;


    void Start(){
        gameManager = GetComponent<GameManager>();
    }

    void OnAttack (InputValue value){
        if ((float)value.Get() == 1f){
            gameManager.PlayerAttack();
        }
    }

    void OnMove(InputValue value) { 
        gameManager.PlayerMove((Vector2)value.Get());
    }

    void OnExit(InputValue value){
        gameManager.ExitGame();
    }

    void OnJump(InputValue value)
    {
        gameManager.PlayerJump();
    }


}
