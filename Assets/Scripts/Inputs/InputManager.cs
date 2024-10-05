using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] Vector2 m_MovementVector;
    [SerializeField] bool m_Fire;
    public Vector2 MovementVector { get { return m_MovementVector; } }
    public bool Fire { get { return m_Fire; } }
    public void OnMove(InputValue value)
    {
        m_MovementVector = value.Get<Vector2>();
    }
    public void OnFire()
    {
        m_Fire = true;
    }
    public void ResetFire()
    {
        m_Fire = false;
    }
}
