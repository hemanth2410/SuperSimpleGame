using UnityEngine;

[CreateAssetMenu(fileName = "New Random Movement", menuName = "Enemy Utilities / Random Movement")]
public class RandomMovement : EnemyMovement
{
    [SerializeField] private float m_Speed = 1.0f;
    [SerializeField] private float m_ChangeInterval = 2.0f;
    private Vector3 randomDirection;
    private float timePassed;

    public override Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime)
    {
        timePassed += deltaTime;
        if (timePassed > m_ChangeInterval)
        {
            randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            timePassed = 0;
        }
        return randomDirection * m_Speed * deltaTime;
    }
}
