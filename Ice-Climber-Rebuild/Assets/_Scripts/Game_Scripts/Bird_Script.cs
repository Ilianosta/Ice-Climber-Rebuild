using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Script : MonoBehaviour
{

    Collider2D enemyColl;
    Bird_Script enemy;
    public PlayerController player;

    public bool isHead;
    public float velocidad,velVuelo;
    SpriteRenderer SPbird;


    void Start()
    {
        enemyColl = GetComponent<Collider2D>();
        enemy = GetComponent<Bird_Script>();
        isHead = false;
        SPbird = GetComponent<SpriteRenderer>();
        InvokeRepeating("Vuelo",0,0.5f);
    
    }

    void Update()
    {
        Movimiento();

    
    }
    // Funciones

    void Movimiento()
    {
        this.transform.Translate(velocidad * Time.deltaTime, 0, 0);
        this.transform.Translate(0, velVuelo * Time.deltaTime, 0);
    }

    //Invierte la direccion en Y
    void Vuelo()
    {
        velVuelo = -velVuelo;
    }

    //Invierte la direccion en X cuando se deja de ver en pantalla
    void OnTriggerEnter2D(Collider2D trigg)
    {
        
        if (trigg.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            player.EnemyDestroy();
            //enemyColl.enabled = false;
            
        }

    }


    
  /*  public void OnBecameInvisible()
    {
        velocidad = -velocidad;
        SPbird.flipX = !SPbird.flipX;    
    }
    */

    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            Destroy(gameObject);
        }
    }*/

    
}
