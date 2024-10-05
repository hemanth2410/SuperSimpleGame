using AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShooter : MonoBehaviour
{
    InputManager inputManager;
    [SerializeField] Transform m_FireTransform;
    [SerializeField] float m_bulletImpulse;
    [SerializeField] AudioClip m_AudioClip;
    SoundData soundData;
    SoundBuilder soundBuilder;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        soundData = new SoundData();
        soundData.clip = m_AudioClip;
        soundBuilder = SoundManager.Instance.CreateSoundBuilder();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputManager.Fire)
        {
            inputManager.ResetFire();
            var go = BulletObjectPool.Instance.Pool.Get();
            go.gameObject.SetActive(true);
            go.gameObject.transform.position = m_FireTransform.position;
            go.transform.up = m_FireTransform.up;
            go.GetComponent<Rigidbody2D>().AddForce(m_FireTransform.up * m_bulletImpulse, ForceMode2D.Impulse);
            soundBuilder.WithRandomPitch().WithPosition(m_FireTransform.position).Play(soundData);
        }
    }
}
