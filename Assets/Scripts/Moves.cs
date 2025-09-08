using UnityEngine;

public class Moves : MonoBehaviour
{
    public Subject RaisePettingEvent;

    [SerializeField] public Transform spriteTransform; // o Transform do sprite que vai fazer stretch

    [Header("Scratch & Stretch Configuração")]
    public float stretchAmount = 1.2f;
    public float squashAmount = 0.8f;
    public float stretchSpeed = 8f;

    private Vector3 originalScale;
    private float stretchTimer = 0f;

    void Awake()
    {
        if (spriteTransform == null)
            spriteTransform = transform;

        originalScale = spriteTransform.localScale;
    }

    void OnEnable()
    {
        RaisePettingEvent.OnPettingEventRaised += OnPettingEvent;
    }

    void OnDisable()
    {
        RaisePettingEvent.OnPettingEventRaised -= OnPettingEvent;
    }

    void OnPettingEvent(bool isPetting)
    {
        if(isPetting==true){
            // aplica scratch & stretch enquanto estiver recebendo petting
            stretchTimer += Time.deltaTime * stretchSpeed;
            float t = Mathf.Sin(stretchTimer) * 0.5f + 0.5f; // valor entre 0 e 1
            float xScale = Mathf.Lerp(originalScale.x, originalScale.x * stretchAmount, t);
            float yScale = Mathf.Lerp(originalScale.y, originalScale.y * squashAmount, 1 - t);
            spriteTransform.localScale = new Vector3(xScale, yScale, originalScale.z);
        }
        else{
            spriteTransform.localScale = originalScale;

        }
    
    }

}
