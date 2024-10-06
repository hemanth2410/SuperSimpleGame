using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Pattern Movement", menuName = "Enemy Utilities / Wave Pattern Movement")]
public class WavePatternMovement : EnemyMovement
{
    [SerializeField] private float m_AmplitudeX = 1.0f;
    [SerializeField] private float m_AmplitudeY = 1.0f;
    [SerializeField] private float m_FrequencyX = 1.0f;
    [SerializeField] private float m_FrequencyY = 1.0f;
    [SerializeField] private float m_ForwardSpeed = 1.0f;
    private float timePassed;

    public override Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime)
    {
        timePassed += deltaTime;
        float x = Mathf.Sin(timePassed * m_FrequencyX) * m_AmplitudeX;
        float y = Mathf.Sin(timePassed * m_FrequencyY) * m_AmplitudeY;
        return new Vector3(-m_ForwardSpeed * deltaTime + x, y, 0);
    }
}
