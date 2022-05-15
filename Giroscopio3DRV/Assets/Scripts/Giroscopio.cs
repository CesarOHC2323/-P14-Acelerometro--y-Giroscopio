using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giroscopio : MonoBehaviour
{

    public GameObject VRCamara;

    private float PosicionInicialY =0f;
    private float PosicionDelGyroEnY =0f;
    private float CalibrarEnLaPosicionY =0f;

    public bool SeInicioElJuego;

    // Start is called before the first frame update
    void Start()
    {//Indica que el dispositivo mivil tiene un giroscopio
    //Activacion
        Input.gyro.enabled = true;
        PosicionInicialY = VRCamara.transform.eulerAngles.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        AplicarRotacionDelGyroscopio();
        AplicarCalibracion();

        //condicional de inicio de juego
        if(SeInicioElJuego == true)
        {
            Invoke("CalibrarEnPosicionY", 3f);
            SeInicioElJuego = false;
        }
        
    }
    void AplicarRotacionDelGyroscopio()
    {
        //Devuelve la oriencion en el espacio del dispositivo
        VRCamara.transform.rotation = Input.gyro.attitude;
        VRCamara.transform.Rotate(0f, 0f, 180f, Space.Self);
        VRCamara.transform.Rotate(90f, 180f, 0f, Space.World);
        //Guarda el angulo de la calibracion para su uso en Y
        PosicionDelGyroEnY = VRCamara.transform.eulerAngles.y;

    }
    void CalibrarEnPosicionY()
    {
        //Esto desplaza al angulo Y en edicion
        CalibrarEnLaPosicionY = PosicionDelGyroEnY - PosicionInicialY;

    }
    void AplicarCalibracion()
    {
        //calibrar el VRcamara
        VRCamara.transform.Rotate(0f, -CalibrarEnLaPosicionY, 0f, Space.World);

    }
}
