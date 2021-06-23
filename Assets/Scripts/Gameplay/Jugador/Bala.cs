using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Transform posicion;

    void Start()
    {
        posicion = GetComponent<Transform>();
    }

    void Update()
    {
        MoverHaciaArriba();
        if (TraspasaLimiteDePantalla())
            DestruirBala();
    }

    private void MoverHaciaArriba(){
        posicion.position += Vector3.up * Time.deltaTime * 8f;
    }
    private bool TraspasaLimiteDePantalla(){
        if (posicion.position.x > ObtenerLimiteDePantalla().x) return true;
        return false;
    }
    private Vector2 ObtenerLimiteDePantalla(){
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    private void OnTriggerEnter2D(Collider2D otherObject){
        GameObject objeto = otherObject.gameObject;
        if (objeto.tag == "Enemy"){
            Score.PlayerScore += 10;
            Destroy(objeto);
            this.DestruirBala();
        }
        


    }

    private void DestruirBala(){
        Destroy(this.gameObject);
    }
}
