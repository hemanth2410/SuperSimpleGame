using UnityEngine;

[CreateAssetMenu(fileName = "New Follow Player Movement", menuName = "Enemy Utilities / Follow Player Movement")]
public class FollowPlayerMovement : EnemyMovement
{
    [SerializeField] private float m_Speed = 1.0f;
    private Transform playerTransform;

    public void SetPlayer(Transform player)
    {
        playerTransform = player;
    }

    public override Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime)
    {
        if (playerTransform == null) return Vector3.zero;

        Vector3 directionToPlayer = (playerTransform.position - currentPosition).normalized;
        return directionToPlayer * m_Speed * deltaTime;
    }
}
