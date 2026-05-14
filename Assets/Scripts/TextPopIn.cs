using UnityEngine;

public class TextPopIn : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 targetScale;

    void Start()
    {
        targetScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);
    }
}