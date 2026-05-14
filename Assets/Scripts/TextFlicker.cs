using UnityEngine;
using TMPro;

public class TextFlicker : MonoBehaviour
{
    public TextMeshPro text;
    public float speed = 5f;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1f;

    void Update()
    {
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time * speed, 1));
        Color c = text.color;
        c.a = alpha;
        text.color = c;
    }
}