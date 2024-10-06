using UnityEngine;

[CreateAssetMenu(fileName = "New Linear Movement", menuName = "Enemy Utilities / Linear Movement")]
public class LinearMovement : EnemyMovement
{
    [SerializeField] private Vector3 m_MovementDirection;
    [SerializeField] private float m_Speed = 1f;

    public override Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime)
    {
        return m_MovementDirection * m_Speed * deltaTime;
    }
}
