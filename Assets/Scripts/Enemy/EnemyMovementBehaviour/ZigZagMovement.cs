using UnityEngine;

[CreateAssetMenu(fileName = "New ZigZag Movement", menuName = "Enemy Utilities / ZigZag Movement")]
public class ZigZagMovement : EnemyMovement
{
    [SerializeField] private float m_ZigZagAmplitude = 2.0f;
    [SerializeField] private float m_ZigZagFrequency = 2.0f;
    [SerializeField] private float m_ForwardSpeed = 1.0f;
    private float timePassed;

    public override Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime)
    {
        timePassed += deltaTime;
        float zigZagOffset = Mathf.Sin(timePassed * m_ZigZagFrequency) * m_ZigZagAmplitude;
        Vector3 movement = new Vector3(-m_ForwardSpeed * deltaTime, zigZagOffset * deltaTime, 0);
        return movement;
    }
}
