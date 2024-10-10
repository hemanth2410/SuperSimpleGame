using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySample : MonoBehaviour
{
    [SerializeField] EnemyMovement m_MovementAsset;
    EnemyMovement movementAsset;
    // Start is called before the first frame update
    void Start()
    {
        movementAsset = Instantiate(m_MovementAsset);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = movementAsset.EvaluateMovement(transform.position, Time.deltaTime);
        transform.Translate(movement);
        //Vector3 movementVector = new Vector3(-2.0f * Time.deltaTime, Mathf.Sin(Time.time * 5) * 2 * Time.deltaTime, 0);
        //transform.Translate(movementVector);
    }
}
