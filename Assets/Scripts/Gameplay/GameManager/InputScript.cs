using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    

    void OnAttack (InputValue value){
        if ((float)value.Get() == 1f){
            GameManager.GM.PlayerAttack();
        }
    }

    void OnMove(InputValue value) {
        GameManager.GM.PlayerMove((Vector2)value.Get());
    }

    void OnExit(InputValue value){
        GameManager.GM.ExitGame();
    }

    void OnJump(InputValue value)
    {
        GameManager.GM.PlayerJump();
    }


}
