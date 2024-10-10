using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HealthBarhandler : MonoBehaviour
{
    [SerializeField] Image m_NormalizedHealthImage;
    [SerializeField] Image m_LerpImage;
    [SerializeField] Color m_MaxHealthColor;
    [SerializeField] Color m_MinHealthColor;
    [SerializeField] AnimationCurve m_LowHealthAnimation;
    [SerializeField] float m_LowhealthTrigger;
    [SerializeField]
    [Range(0, 1)]
    [Tooltip("This is just for test adn it will be removed later")] float m_Currenthealth = 1.0f;
    Color targetColor;
    float alpha;
    // Get current health via event system or something
    // Start is called before the first frame update
    void Start()
    {
        calculatehealth(m_Currenthealth, 0);
    }

    // Update is called once per frame
    void Update()
    {
        calculatehealth(m_Currenthealth, Time.deltaTime);
    }

    public void TestDamage()
    {
        SetHealth(m_Currenthealth - 0.1f);
    }

    public void TestRegen()
    {
        SetHealth(m_Currenthealth + 0.1f);
    }

    void SetHealth(float health)
    {
        // Now lerp the other image in certain amount of time;
        StartCoroutine(JuiceHealth(m_Currenthealth, health));
        m_Currenthealth = Mathf.Clamp(health, 0, 1);
    }
    IEnumerator JuiceHealth(float from, float to)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        float timer = 0.0f;
        while(timer <= 1.0f)
        {
            timer += Time.deltaTime;
            // adjust the lerp value.
            float target = Mathf.Lerp(from, to, timer);
            m_LerpImage.fillAmount = target;
            yield return new WaitForEndOfFrame();
        }
    }
    void calculatehealth(float health, float deltaTime)
    {
        targetColor = Color.Lerp(m_MinHealthColor, m_MaxHealthColor, health);
        if (deltaTime > 0 && health <= m_LowhealthTrigger)
        {
            alpha = m_LowHealthAnimation.Evaluate(Time.time);
            targetColor.a = alpha;
        }
        else
        {
            targetColor.a = 1;
        }
        m_NormalizedHealthImage.color = targetColor;
        m_NormalizedHealthImage.fillAmount = health;
    }
}
