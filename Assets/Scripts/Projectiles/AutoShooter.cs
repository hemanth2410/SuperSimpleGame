using AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    [SerializeField] int m_RoundsPerMinute;
    [SerializeField] Transform m_fireTransform;
    float timeBetweenShots;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShots = 1 / (m_RoundsPerMinute / 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenShots)
        {
            var k = BulletObjectPool.Instance.Pool.Get();
            k.gameObject.SetActive(true);
            k.gameObject.SetActive(true);
            k.gameObject.transform.position = m_fireTransform.position;
            k.transform.up = m_fireTransform.up;
            k.GetComponent<Rigidbody2D>().AddForce(m_fireTransform.up * 20.0f, ForceMode2D.Impulse);
            timer = 0;
        }
    }
}
