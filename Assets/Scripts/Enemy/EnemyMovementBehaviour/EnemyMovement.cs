using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : ScriptableObject
{
    public abstract Vector3 EvaluateMovement(Vector3 currentPosition, float deltaTime);
}
