using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour {
    public float speed = 2f;
    public float sensitivity = 2f;
    CharacterController player;

    public GameObject eyes;

    float moveFB;
    float moveLR;

    float rotX;
    float rotY;

    float velocidadeVertical;
    float gravidade;
    float forcaPulo;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        player = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        moveFB = Input.GetAxis("Vertical");
        moveLR = Input.GetAxis("Horizontal");

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 movimento = new Vector3(moveLR, 0, moveFB);
        transform.Rotate(0, rotX, 0);
        eyes.transform.Rotate(-rotY, 0, 0);

        movimento = transform.rotation * movimento;
        player.Move(movimento * Time.deltaTime);

        if (player.isGrounded)
        {
            velocidadeVertical = -gravidade * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidadeVertical = forcaPulo;
            }
        }
        else
        {
            velocidadeVertical -= gravidade * Time.deltaTime;
        }

        Vector3 moverVector = new Vector3(0, velocidadeVertical, 0);
        player.Move(moverVector * Time.deltaTime);

	}
}
