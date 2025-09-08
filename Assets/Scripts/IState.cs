using UnityEngine;

public abstract class IState 
{

    protected StateMachine _player;
    protected float targetHeight = 100f;

    public IState(StateMachine player)
    {
        _player = player;
    }

    public abstract void Enter(SpriteRenderer sprite, Camera camera);
    public abstract void Exit();
    public abstract void Update();

    public void ApplyResize(SpriteRenderer sr)
 {
        if (sr.sprite == null) return;

        float spritePixelHeight = sr.sprite.rect.height;

        if (spritePixelHeight <= 0) return;

        float ppu = sr.sprite.pixelsPerUnit;
        float spriteHeightUnits = spritePixelHeight / ppu;

        float targetHeightUnits = targetHeight / ppu;

        float scaleFactor = targetHeightUnits / spriteHeightUnits;

        sr.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
    }
}
