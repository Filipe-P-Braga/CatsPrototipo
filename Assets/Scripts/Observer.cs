using UnityEngine;
using TMPro;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    public Subject pettingSubject;

    public bool isPetting = false;

    [SerializeField] private Slider slider;

    [Header("Configuração do Slider")]
    public float minValue = 0f;
    public float maxValue = 100f;
    public float SubtractValue = 1f;

    [Header("Configuração Affection")]
    public float affection = 0f;
    public float affectionRate = 5f;
    public float pauseDuration = 0;

    [Header("Configuração CatCount")]
    private int happyCatCount = 0;
    [SerializeField] private TextMeshProUGUI happyCatCountText;




    private void Awake()
    {
        if (slider != null)
        {
            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.value = minValue;
        }
    }

    private void Update()
    {
        if (slider != null && slider.value > minValue && !isPetting)
        {
            slider.value -= SubtractValue * Time.deltaTime;
            if (slider.value < minValue)
            {
                slider.value = minValue;
            }
        }
        else if (slider.value == maxValue)
        {

            addCatCount();

            slider.value = minValue;

            pettingSubject.RaiseFullBarEvent(true);
            StartCoroutine(PauseGame());


            affectionRate = Mathf.Max(affectionRate - 0.5f, 0.2f);

        }
    }

    void OnEnable()
    {
        pettingSubject.OnPettingEventRaised += UpdateSlider;
    }

    void OnDisable()
    {
        pettingSubject.OnPettingEventRaised -= UpdateSlider;
    }

    void UpdateSlider(bool isPetting)
    {

        this.isPetting = isPetting;

        if (slider != null)
        {
            float affectionDelta = affectionRate * Time.deltaTime;

            slider.value = Mathf.Clamp(slider.value + affectionDelta, minValue, maxValue);

            affection += affectionDelta;
        }
    }

    void StopPetting(bool isStopped)
    {
        isPetting = false;
    }

    private System.Collections.IEnumerator PauseGame()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(pauseDuration);
        Time.timeScale = 1f;
        pettingSubject.RaiseFullBarEvent(false);
    }

    private void addCatCount()
    {
        happyCatCount++;
        if (happyCatCountText != null)
        {
            happyCatCountText.text = "Happy Cats: " + happyCatCount;
        }
    }


}
