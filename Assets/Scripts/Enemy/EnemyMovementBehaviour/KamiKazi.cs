using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "KamiKazi", menuName = "Enemy Utilities / KamiKazi")]
public class KamiKazi : EnemyMovement
{
    [SerializeField][Tooltip("Make sure it is less than 1 for best outcome")] float m_KamikaziTime;
    [SerializeField] float m_MaxKamikaziSpeed;
    [SerializeField] float acceleration = 1.5f;  // New: Speed ramping for smoother movement
    float kamikaziSpeed;
    private float timer = 0;
    private Vector3 direction;
    [SerializeField] bool lockedOn = false;  // Lock onto the direction once kamikaze time ends

    public override Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime)
    {
        // Ensure there's a valid target (Player)
        if (PlayerSingletons.Instance.Player == null)
            return Vector3.zero;

        // Calculate movement before locking direction
        if (!lockedOn && timer < m_KamikaziTime)
        {
            timer += deltaTime;
            // Get direction towards the player and normalize
            Vector3 targetDirection = (PlayerSingletons.Instance.Player.transform.position - currentPosition).normalized;

            // Gradual speed increase for a more natural movement
            kamikaziSpeed += acceleration * deltaTime;
            if (kamikaziSpeed > m_MaxKamikaziSpeed)
                kamikaziSpeed = m_MaxKamikaziSpeed;
            // Calculate new position (translate this to movement outside)
            direction = targetDirection * kamikaziSpeed * deltaTime;

            // After the kamikaze time, lock the direction
            if (timer >= m_KamikaziTime)
                lockedOn = true;

            return direction;
        }
        else
        {
            // Locked-on movement: Keep moving in the final direction
            return direction;
        }
    }
}
