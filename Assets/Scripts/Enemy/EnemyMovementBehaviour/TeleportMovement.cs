using UnityEngine;

[CreateAssetMenu(fileName = "New Teleport Movement", menuName = "Enemy Utilities / Teleport Movement")]
public class TeleportMovement : EnemyMovement
{
    [SerializeField] private float m_TeleportInterval = 2.0f;
    [SerializeField] private Vector3 m_TeleportAreaSize;
    private float timePassed;

    public override Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime)
    {
        timePassed += deltaTime;
        if (timePassed >= m_TeleportInterval)
        {
            timePassed = 0;
            return new Vector3(
                Random.Range(-m_TeleportAreaSize.x / 2, m_TeleportAreaSize.x / 2),
                Random.Range(-m_TeleportAreaSize.y / 2, m_TeleportAreaSize.y / 2),
                0);
        }
        return Vector3.zero;
    }
}
