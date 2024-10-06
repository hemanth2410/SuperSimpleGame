using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sine Wave Movement", menuName = "Enemy Utilities / Sine Wave Movement")]
public class SimpleSineWave : EnemyMovement
{
    [SerializeField] private float m_swayDistance = 1.0f;
    [SerializeField] private float m_SwaySpeed = 1.0f;
    [SerializeField] private Vector3 m_MovementDirection;
    [SerializeField] private Vector3 m_OscillatingDirection;
    [SerializeField] private float m_Speed = 1f;
    private float timePassed;

    public override Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime)
    {
        timePassed += deltaTime;
        float oscillation = Mathf.Sin(timePassed * m_SwaySpeed) * m_swayDistance * Time.deltaTime;
        Vector3 movementDirection = m_MovementDirection * m_Speed * deltaTime;
        movementDirection = new Vector3(movementDirection.x, oscillation, 0);
        return movementDirection;
    }
}