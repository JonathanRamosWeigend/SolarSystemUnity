/// <summary>
/// --------------------------------------------------------------------------------------------------------
/// Solar Simulation with UNITY and C#
/// (c) Jonathan Ramos Weigend, Johannes Weigend
/// November 2022, Blumenau Brasilien
/// --------------------------------------------------------------------------------------------------------
/// </summary>
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public float flyingSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Fliegen durch Drücken der Leertaste
        if (Input.GetKey(KeyCode.Space))
        {
            // Bewegung in Richtung der aktuellen Blickrichtung
            Vector3 movement = transform.up * Time.deltaTime * flyingSpeed;

            // Verschiebung des Charakters um die berechnete Bewegung
            controller.Move(movement);
        }
    }
}
