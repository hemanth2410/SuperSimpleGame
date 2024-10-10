using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    Rigidbody2D rb;  // Reference to the Rigidbody2D component
    InputManager inputManager;
    [SerializeField] float m_ThrustForce = 10f;  // Force applied for movement
    [SerializeField] float m_MaxSpeed = 5f;      // Max speed for the spaceship
    [SerializeField] float m_RotationSpeed = 200f; // Speed for rotating the spaceship
    [SerializeField] bool m_rotateSpaceShip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        inputManager = GetComponent<InputManager>();  // Get the InputManager component
        // Remove this later 
        // Dont forget
        PlayerSingletons.Instance.RegisterPlayer(this.gameObject);
    }
    private void Update()
    {
        if (!m_rotateSpaceShip)
            return;

    }
    private void FixedUpdate()
    {
        ApplyThrust();  // Apply forces to move the ship
        LimitSpeed();   // Cap the maximum speed of the spaceship
    }

    // Apply thrust force based on input
    private void ApplyThrust()
    {
        Vector2 movementInput = inputManager.MovementVector;

        // Apply force in the direction of input
        if (movementInput != Vector2.zero)
        {
            rb.AddForce(movementInput.normalized * m_ThrustForce);
        }
    }

    // Optional: Limit the maximum speed of the spaceship
    private void LimitSpeed()
    {
        if (rb.velocity.magnitude > m_MaxSpeed)
        {
            rb.velocity = rb.velocity.normalized * m_MaxSpeed;  // Cap the velocity at the maximum speed
        }
    }
    private void RotateShip()
    {
        Vector2 movementInput = inputManager.MovementVector;

        // Rotate towards the input direction if there's input
        if (movementInput != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg - 90f;
            float angle = Mathf.LerpAngle(rb.rotation, targetAngle, Time.deltaTime * m_RotationSpeed);
            rb.rotation = angle;
        }
    }
}
