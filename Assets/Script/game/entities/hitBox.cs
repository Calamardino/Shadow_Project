using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : CSprite
{
    private CGameObject entityCasting;

    private int width;
    private int height;

    private int delay;
    private int boxDuration;

    private bool boxRecursivo;
    private int repeticiones;

    private int posX;
    private int posY;

    public int STATE_WAITING = 0;
    public int STATE_ACTING = 1;
    public int STATE_ENDED = 2;

    public const int ALLYBOX = 0;
    public const int ENEMYBOX = 1;

    public hitBox(CGameObject caster, int sizeX, int sizeY, int positionX, int positionY, int frameDelay, int duration, int team, bool recursivo = false, int cantDeRepeticiones = 0)
    {
        entityCasting = caster;
        width = sizeX;
        height = sizeY;

        setXY(caster.getX() + positionX, caster.getY() + positionY);

        delay = frameDelay;

        boxDuration = duration;

        if (recursivo)
        {
            boxRecursivo = recursivo;
            repeticiones = cantDeRepeticiones;
        }

        
        setImage(Resources.Load<Sprite>("Sprites/ui/pixel"));
        setSortingLayerName("Player");
        setSortingOrder(20);
        setColor(Color.blue);
        setAlpha(0.5f);
        setName(caster + " hitBox");

        posX = positionX;
        posY = positionY;
        setXY(-width, -height);


        setScaleX(sizeX);
        setScaleY(sizeY);

        if (delay == 0)
        {
            setState(STATE_ACTING);
        }
        else
        {
            setState(STATE_WAITING);
        }
        

        
        
    }

    public override void update()
    {
        base.update();
        if (getState() == STATE_WAITING)
        {
            if (delay == 0)
            {
                setState(STATE_ACTING);
            }
            else
            {
                delay--;
            }
        }
        else if (getState() == STATE_ACTING)
        {
            if (boxDuration == 0)
            {
                setState(STATE_ENDED);
            }
            else
            {
                boxDuration--;
            }
        }

    }
    public override void render()
    {

        base.render();
    }
    public override void setState(int aState)
    {
        base.setState(aState);
        if (getState() == STATE_WAITING)
        {
            setVisible(false);
        }
        else if (getState() == STATE_ACTING)
        {
            setVisible(true);
            setXY(entityCasting.getX() + posX, entityCasting.getY() + posY);
        }
        else if (getState() == STATE_ENDED)
        {
            setDead(true);
            setVisible(false);
        }
    }
    public override void destroy()
    {
        base.destroy();
    }
}
