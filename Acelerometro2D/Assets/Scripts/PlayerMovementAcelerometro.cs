using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementAcelerometro : MonoBehaviour
{
    public float velocidad;
    Rigidbody2D rbPlayer;
    public int score;
    public Text TXTScore;

 
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        
    }
 
   
    void Update()
    {
        TXTScore.text = "Score: " + score;

        Vector3 acelerometroVector = new Vector3(Input.acceleration.x, Input.acceleration.y, 0);

        transform.Translate(acelerometroVector * velocidad * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            //se suma
            score++;
            //se destruye 
            Destroy(collision.gameObject);
        }
    }




}
