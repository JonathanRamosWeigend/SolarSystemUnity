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

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
