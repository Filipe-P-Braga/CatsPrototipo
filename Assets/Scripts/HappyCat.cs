using UnityEngine;

public class HappyCat : IState
{

    public SpriteRenderer sprite;
    public Camera camera;

    public string spritePath = "Sprites/HappyCat";

    public HappyCat(StateMachine player) : base(player)
    {
    }


    public override void Enter(SpriteRenderer _sprite, Camera _camera)
    {
        sprite = _sprite;
        camera = _camera;

        sprite.sprite = Resources.Load<Sprite>(spritePath);
        ApplyResize(sprite);

        camera.backgroundColor = Color.yellow;

    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}
