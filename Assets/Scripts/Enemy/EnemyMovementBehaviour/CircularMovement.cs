using UnityEngine;

[CreateAssetMenu(fileName = "New Circular Movement", menuName = "Enemy Utilities / Circular Movement")]
public class CircularMovement : EnemyMovement
{
    [SerializeField] private float m_Radius = 2.0f;
    [SerializeField] private float m_RotationSpeed = 1.0f;
    [SerializeField] private Vector3 m_CenterOffset;
    private float angle;

    public override Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime)
    {
        angle += m_RotationSpeed * deltaTime;
        float x = Mathf.Cos(angle) * m_Radius;
        float y = Mathf.Sin(angle) * m_Radius;
        return new Vector3(x, y, 0) + m_CenterOffset;
    }
}
