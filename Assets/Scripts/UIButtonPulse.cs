using UnityEngine;

public class UIButtonPulse : MonoBehaviour
{
    private Vector3 originalScale;

    public float pulseSpeed = 2f;
    public float pulseAmount = 0.05f;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = originalScale * scale;
    }
}