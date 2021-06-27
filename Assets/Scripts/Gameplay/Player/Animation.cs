using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Jugador jugadorScript;
    public Animator Animator;

    private void Start(){
        jugadorScript = GetComponent<Jugador>();
        Animator = GetComponent<Animator>();
    }

    public void DoWalk(float speed)
    {

        if (speed == 0f){
            this.Animator.speed = 1f;
            this.Animator.SetBool("Running", false);
        }
        else{
            
            this.Animator.speed = Mathf.Abs(Mathf.Clamp(speed,0.5f,1f));
            this.Animator.SetBool("Running", true);
        }
    } 

}
