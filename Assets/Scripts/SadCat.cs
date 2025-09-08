using UnityEngine;

public class SadCat : IState
{
    public SpriteRenderer sprite;
    public Camera camera;

    public string spritePath = "Sprites/sadCat";

    public SadCat(StateMachine player) : base(player)
    {
    }


    public override void Enter(SpriteRenderer _sprite, Camera _camera)
    {
        sprite = _sprite;
        camera = _camera;

        sprite.sprite = Resources.Load<Sprite>(spritePath);
        
        ApplyResize(sprite);

        camera.backgroundColor = Color.blue;

    }

    public override void Exit()
    {
        sprite.color = Color.white;
    }

    public override void Update()
    {

    }
}
