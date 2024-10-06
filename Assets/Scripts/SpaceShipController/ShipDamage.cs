using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ShipDamage : MonoBehaviour
{
    CinemachineImpulseSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<CinemachineImpulseSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        source.GenerateImpulse();
    }
}
