using UnityEngine;
using UnityEngine.EventSystems;

public class MeowScript : MonoBehaviour
{

    public Subject RaisePettingEvent;


    [SerializeField] public AudioSource pettingSound;
    [SerializeField] public AudioSource meowSound;


    void OnEnable()
    {
        RaisePettingEvent.OnPettingEventRaised += UpdateUI;
        RaisePettingEvent.OnFullBarEventRaised += Meow;

    }

    void OnDisable()
    {
        RaisePettingEvent.OnPettingEventRaised -= UpdateUI;
        RaisePettingEvent.OnFullBarEventRaised -= Meow;
    }

    void UpdateUI(bool isPetting)
    {
        if (isPetting == true)
        {
            if (!pettingSound.isPlaying)
            {
                pettingSound.Play();
            }

        }
        else if (pettingSound.isPlaying)
        {
            pettingSound.Stop();
        }

    }

    void Meow(bool paused)
    {
        if (paused == true)
        {
            meowSound.Play();
        }
    }

}
