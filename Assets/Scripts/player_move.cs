using UnityEngine;

public class player_move : MonoBehaviour
{
    public float speed = 5f;       // velocità del personaggio
    public float gravity = -9.81f; // gravità
    public float jumpHeight = 2f;  // altezza del salto

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // piccola forza per tenere il personaggio a terra
        }

        float x = Input.GetAxis("Horizontal");    // Input orizzontale e verticale (WASD / frecce)
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;// direzione personaggio
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)         // salto
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravità
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
