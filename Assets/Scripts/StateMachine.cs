using UnityEngine;
using System;
public class StateMachine : MonoBehaviour
{
    private IState _currentMood;

    [HideInInspector]
    public bool isBeingPetted = false;
    [HideInInspector]
    public float moodTimer = 0f;

    public Subject RaisePettingEvent;



    [Header("Dependências")]
    public SpriteRenderer _sprite;
    public Material _material;
    public Material _materialDefault;
    public Camera camera;
    public GameObject _particulas;


    [Range(0f, 1f)] public float neutralChance = 0.2f;
    [Range(0f, 1f)] public float happyChance = 0.2f;
    [Range(0f, 1f)] public float angryChance = 0.2f;
    [Range(0f, 1f)] public float sadChance = 0.2f;

    //---------------------------------------------------------

    void OnEnable()
    {
        RaisePettingEvent.OnFullBarEventRaised += SetRandomMood;
        RaisePettingEvent.OnFullBarEventRaised += PauseState;

    }

    void OnDisable()
    {
        RaisePettingEvent.OnFullBarEventRaised -= SetRandomMood;
        RaisePettingEvent.OnFullBarEventRaised -= PauseState;
    }


    //---------------------------------------------------------

    private void Start()
    {
        ChangeMood(new NeutralCat(this));
    }

    private void Update()
    {
        _currentMood?.Update();
    }

    public void ChangeMood(IState newMood)
    {
        _currentMood?.Exit();
        _currentMood = newMood;
        _currentMood.Enter(_sprite, camera);
    }

    //---------------------------------------------------------

    public void SetRandomMood(bool paused)
    {
        if (paused == false)
        {
            float rand = UnityEngine.Random.value * (neutralChance + happyChance + angryChance + sadChance);

            if (rand < neutralChance)
            {
                ChangeMood(new NeutralCat(this));
            }
            else if (rand < neutralChance + happyChance)
            {
                ChangeMood(new HappyCat(this));
            }
            else if (rand < neutralChance + happyChance + angryChance)
            {
                ChangeMood(new AngryCat(this));
            }
            else
            {
                ChangeMood(new SadCat(this));
            }
                
        }
    }

    //---------------------------------------------------------

    public void PauseState(bool paused)
    {
        if (_materialDefault == null)
        {
            _materialDefault = _sprite.material;
        }

        if (paused == true)
        {
            _sprite.material = _material;
            var particleSystem = _particulas.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
            }
        }
        else
        {
            _sprite.material = _materialDefault;
        }
    }
        


}
