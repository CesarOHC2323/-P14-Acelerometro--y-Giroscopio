
using UnityEngine;

public class InputController : MonoBehaviour
{
    Transform cam;
    public Joystick joystickMove;
    public Joystick joystickGiro;

    public Transform player;
    public CharacterController controller;

    public float speed = 10f;
    float x;
    float z;
    Vector3 move;
    //
    float rotateV;
    float rotateH;
    public float speedGiro = 0.2f;
   
    private void Start()
    {
        cam = Camera.main.transform;
    }
    private void Update()
    {
        Move();
        Rotate();
    }
    void Move()
    {
        x = joystickMove.Horizontal + Input.GetAxis("Horizontal");
        z = joystickMove.Vertical + Input.GetAxis("Vertical");
        move = player.right * x + player.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    void Rotate()
    {
        rotateH = joystickGiro.Horizontal * speedGiro;
        rotateV = -(joystickGiro.Vertical * speedGiro);
        cam.Rotate(rotateV, 0, 0);
        player.Rotate(0, rotateH, 0);
    }

   
}
