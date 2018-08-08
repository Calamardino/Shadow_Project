using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigEnemy : CSprite
{
    
    private const int WIDTH = 300;
    private const int HEIGHT = 430;

    private const int STATE_STAND = 0;
    private const int STATE_TAKING_STEP = 1;
    private const int STATE_FALLING = 2;
    private const int STATE_ALERTED = 3;
    private const int STATE_ATTACKING = 4;
    private const int STATE_STUNNED = 5;
    private const int STATE_DEAD = 6;

    private int maxHealth;
    private int currentHealth;

    private int minTimeStanding = 50;
    private int maxTimeStanding = 150;

    private int currentTimeStanding;

    private int minSteps = 1;
    private int maxSteps = 3;

    private int nextAmountOfSteps;

    private const int LEFT = 1;
    private const int RIGHT = 2;

    private int direction;

    private hitBoxManager mHitBoxManager;

    private hitBox box;

    private CTileMap mMap;


    public bigEnemy()
    {

        setXY(1400, CTileMap.TILE_HEIGHT*8-HEIGHT);
        setImage(Resources.Load<Sprite>("Sprites/ui/pixel"));
        setSortingLayerName("Enemies");
        setSortingOrder(20);

        setColor(Color.magenta);

        setAlpha(0.4f);
        setName("bigEnemy");

        setScaleX(WIDTH);
        setScaleY(HEIGHT);

        currentHealth = maxHealth;
        setState(STATE_STAND);

        mMap = new CTileMap();
    }
    public override void setState(int aState)
    {
        base.setState(aState);
        if (getState() == STATE_STAND)
        {
            currentTimeStanding = CMath.randomIntBetween(minTimeStanding, maxTimeStanding);
            nextAmountOfSteps = CMath.randomIntBetween(minSteps, maxSteps);
        }
        if (getState() == STATE_TAKING_STEP)
        {
            int c = CMath.randomIntBetween(0, 1);
            if (c== 0)
            {
                direction = LEFT;
            }
            else if (c == 1)
            {
                direction = RIGHT;
            }
            else
            {
                Debug.Log("Error random dio algo que no era");
            }
        }

    }

    public override void update()
    {
        base.update();
        if (getState() == STATE_STAND)
        {
            if (currentTimeStanding == 0)
            {
                setState(STATE_TAKING_STEP);
            }
            else
            {
                currentTimeStanding--;
            }
        }
        else if (getState() == STATE_TAKING_STEP)
        {
            if (direction == LEFT)
            {
                if (mMap.getTile((int)getX() - 2, (int)getY()).isWalkable())
                {

                }
            }
            else if (direction == RIGHT)
            {

            }
            
        }
    }

    public override void render()
    {
        base.render();
    }

    public override void destroy()
    {
        base.destroy();
    }
}
