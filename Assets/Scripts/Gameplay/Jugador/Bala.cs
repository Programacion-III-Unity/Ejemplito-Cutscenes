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
        MoverHaciaLaDerecha();
        if (TraspasaLimiteDePantalla())
            DestruirBala();
    }

    private void MoverHaciaLaDerecha(){
        posicion.position += Vector3.right * Time.deltaTime * 8f;
    }
    private bool TraspasaLimiteDePantalla(){
        if (posicion.position.x > ObtenerLimiteDePantalla().x) return true;
        return false;
    }
    private Vector2 ObtenerLimiteDePantalla(){
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void DestruirBala(){
        Destroy(this.gameObject);
    }
}
