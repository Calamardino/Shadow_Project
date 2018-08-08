using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : CAnimatedSprite
{
    //fede mantengo la parte de width y height del andy
    private const int SCALE = 3;

    private const int WIDTH = 40 * SCALE;
    private const int HEIGHT = 43 * SCALE;

    private const int STATE_STAND = 0;
    private const int STATE_WALKING = 1;
    private const int STATE_JUMPING = 2;
    private const int STATE_FALLING = 3;
    private const int STATE_HIT_ROOF = 4;
    private const int STATE_GHOST = 5;

    private int maxEnergy;

    private int currentEnergy;

    private int speed = 700;

    private CSprite mRect2;

    private hitBoxManager mHitBoxManager;

    //Coordenada que sirve para verificar la posicion anterior del player, se utiliza para chequear la posicion horizontal antes de la vertical.
    private float mOldY;

    //La bounding box esta medida en base al size del Andy, se reposiciona al andy segun la distancia entre el dibujo actual del andy y la pared
    //TODO: Ajustar el bounding box al diseno del personaje.
    private const int X_OFFSET_BOUNDING_BOX = 8 * 2;
    private const int Y_OFFSET_BOUNDING_BOX = 13 * 2;

    private hitBox box;
    
    public CPlayer()
    {
        setFrames(Resources.LoadAll<Sprite>("Sprites/player"));
        setName("andy");
        setSortingLayerName("Player");
        //Mantengo el size original dado que el mapa se mantuvo del mismo size
        setScale(SCALE);
        setRegistration(CSprite.REG_TOP_LEFT);
        setWidth(WIDTH);
        setHeight(HEIGHT);
        setState(STATE_STAND);

        //definimos el bounding box del player, es decir la distancia entre el borde del sprite y el actual dibujo de andy.
        setXOffsetBoundingBox(X_OFFSET_BOUNDING_BOX);
        setYOffsetBoundingBox(Y_OFFSET_BOUNDING_BOX);

        maxEnergy = 150;
        currentEnergy = maxEnergy;


        mRect2 = new CSprite();
        mRect2.setImage(Resources.Load<Sprite>("Sprites/ui/pixel"));
        mRect2.setSortingLayerName("Player");
        mRect2.setSortingOrder(20);
        mRect2.setColor(Color.red);
        mRect2.setAlpha(0.5f);
        mRect2.setName("player_debug_rect2");

        mHitBoxManager = new hitBoxManager();
    }
    //llamamos a la posicion anterior en el eje de las Y.
    private void setOldYPosition()
    {
        mOldY = getY();
    }
    override public void update()
    {
        // Se guarda la posicion anterior del objecto.
        setOldYPosition();

        base.update();

        if (getState() == STATE_STAND) 
        {
            setFriction(1);
            //TODO: REALIZAR EL BOUNDING BOX VERTICAL (ARRIBA Y ABAJO) DEL PERSONAJE PARA EL ESTADO GHOST.
            // TODO: EN EL ESTADO GHOST CAERA O VOLARA A OTRA DIRECCION? PLANTEAR TIMER.

            // En stand no deberia pasar nunca que quede metido en una pared.
            // Corregir la posicion del personaje si esta en una pared. 
            if (isWallLeft(getX(), getY()))
            {
                // Reposicionar el personaje contra la pared utilizando el bounding box correspondiente.
                setX(((mLeftX + 1) * CTileMap.TILE_WIDTH) - X_OFFSET_BOUNDING_BOX);
            }
            if (isWallRight(getX(), getY()))
            {
                // Reposicionar el personaje contra la pared.
                setX((((mRightX) * CTileMap.TILE_WIDTH) - getWidth()) + X_OFFSET_BOUNDING_BOX);
            }


            // Si en el pixel de abajo del jugador no hay piso, caemos.

            if (!isFloor(getX(), getY() + 1))
            {
                setState(STATE_FALLING);
                return;
            }

            if (CKeyboard.firstPress(CKeyboard.UP))
            {
                setState(STATE_JUMPING);
                return;
            }

            if (CKeyboard.pressed(CKeyboard.LEFT) && !isWallLeft(getX() - 1, getY()))
            {
                setState(STATE_WALKING);
                return;
            }

            if (CKeyboard.pressed(CKeyboard.RIGHT) && !isWallRight(getX() + 1, getY()))
            {
                setState(STATE_WALKING);
                return;
            }
        }
        else if (getState() == STATE_WALKING)
        {
            if (isWallLeft(getX(), getY()))
            {
                // Reposicionar el personaje contra la pared.
                setX(((mLeftX + 1) * CTileMap.TILE_WIDTH) - X_OFFSET_BOUNDING_BOX);
            }
            if (isWallRight(getX(), getY()))
            {
                // Reposicionar el personaje contra la pared.
                setX((((mRightX) * CTileMap.TILE_WIDTH) - getWidth()) + X_OFFSET_BOUNDING_BOX);
            }

            //Barra espaciadora salta, first press por lo tanto solo cuando se presiona, si se mantiene presionado no salta.
            if (CKeyboard.firstPress(CKeyboard.UP))
            {
                setState(STATE_JUMPING);
                return;
            }

            // Si en el pixel de abajo del jugador no hay piso, caemos.
            if (!isFloor(getX(), getY() + 1))
            {
                setState(STATE_FALLING);
                return;
            }
            //En el caso que no nos movamos, vuelve al estado STAND.
            if (!(CKeyboard.pressed(CKeyboard.LEFT) || CKeyboard.pressed(CKeyboard.RIGHT)))
            {
                setState(STATE_STAND);
                return;
            }
            else
            {
                if (CKeyboard.pressed(CKeyboard.LEFT))
                {
                    // Chequear pared a la izquierda.
                    // Si hay pared a la izquierda vamos a stand.
                    if (isWallLeft(getX(), getY()))
                    {
                        // Reposicionar el personaje contra la pared.
                        //setX((((int) getX ()/CTileMap.TILE_WIDTH)+1)*CTileMap.TILE_WIDTH);
                        setX(((mLeftX + 1) * CTileMap.TILE_WIDTH) - X_OFFSET_BOUNDING_BOX);

                        // Carlos version.
                        //setX (getX()+CTileMap.TILE_WIDTH/(getWidth()-1));

                        setState(STATE_STAND);
                        return;
                    }
                    else
                    {
                        // No hay pared, se puede mover.
                        setVelX(-speed);
                        setFlip(true);
                    }
                }
                else
                {
                    // Chequear pared a la derecha.
                    // Si hay pared a la derecha vamos a stand.
                    if (isWallRight(getX(), getY()))
                    {
                        // Reposicionar el personaje contra la pared.
                        setX((((mRightX) * CTileMap.TILE_WIDTH) - getWidth()) + X_OFFSET_BOUNDING_BOX);

                        setState(STATE_STAND);
                        return;
                    }
                    else
                    {
                        // No hay pared, se puede mover.
                        setVelX(speed);
                        setFlip(false);
                    }
                }
            }
        }
        //En el caso que saltemos, debemos ajustar la posicion del personaje.
        else if (getState() == STATE_JUMPING)
        {
            controlMoveHorizontal();

            if (isFloor(getX(), getY() + 1))
            {
                setY(mDownY * CTileMap.TILE_HEIGHT - getHeight());
                setState(STATE_STAND);
                return;
            }
            // En el caso de el salto, cuando toque el techo, se usa el Y OFFSET para corregir la posicion a la posicion del gorro.
            if (isRoof(getX(), getY() - 1))
            {
                setY(((mUpY + 1) * CTileMap.TILE_HEIGHT) - Y_OFFSET_BOUNDING_BOX);
                setVelY(0);
                setState(STATE_HIT_ROOF);
                return;
            }
        }
        else if (getState() == STATE_FALLING)
        {
            controlMoveHorizontal();

            if (isFloor(getX(), getY() + 1))
            {
                setY(mDownY * CTileMap.TILE_HEIGHT - getHeight());
                setState(STATE_STAND);
                return;
            }
        }
        else if (getState() == STATE_HIT_ROOF)
        {
            if (getTimeState() > 0.02f * 5.0f)
            {
                setState(STATE_FALLING);
                return;
            }
        }
        // Chequear el paso entre pantallas.
        //controlRooms();
        if (getState() != STATE_GHOST)
        {
            if (currentEnergy < maxEnergy)
            {
                currentEnergy++;
            }
            if (CKeyboard.firstPress(CKeyboard.SPACE))
            {
                if (currentEnergy >= (maxEnergy / 5))
                {
                    currentEnergy = currentEnergy - (maxEnergy / 5);
                    setState(STATE_GHOST);
                    return;
                }
            }
        }
        if (getState() == STATE_GHOST)
        {
            setFriction(0.95f);
            if (currentEnergy == 0)
            {
                setState(STATE_STAND);
                return;
            }
            else
            {
                currentEnergy--;
                ghostMove();
            }
            if (CKeyboard.firstPress(CKeyboard.SPACE))
            {
                setState(STATE_STAND);
                return;
            }
        }
        if (CKeyboard.firstPress(CKeyboard.KEY_C))
        {
            if (getState()!= STATE_GHOST)
            {
                if (getFlip())
                {
                    box = new hitBox(this, 30, 135, 5, (getHeight() / 2) - (135 / 2), 10, 60, hitBox.ALLYBOX);
                    mHitBoxManager.addBox(box);
                }
                else
                {
                    box = new hitBox(this, 30, 135, 5+getWidth()-38, (getHeight() / 2) - (135 / 2), 10, 60, hitBox.ALLYBOX);
                    mHitBoxManager.addBox(box);
                }
                
            }
        }

        /*if (box != null)
        {
            box.update();
        }*/
        mHitBoxManager.update();
    }

    
    private void controlMoveHorizontal()
    {
        // Si estamos en una pared, corregirnos.
        if (isWallLeft(getX(), mOldY))
        {
            // Reposicionar el personaje contra la pared.
            setX(((mLeftX + 1) * CTileMap.TILE_WIDTH) - X_OFFSET_BOUNDING_BOX);
        }
        if (isWallRight(getX(), mOldY))
        {
            // Reposicionar el personaje contra la pared.
            setX((((mRightX) * CTileMap.TILE_WIDTH) - getWidth()) + X_OFFSET_BOUNDING_BOX);
        }

        // Chequeamos si podemos movernos.
        if (!(CKeyboard.pressed(CKeyboard.LEFT) || CKeyboard.pressed(CKeyboard.RIGHT)))
        {
            setVelX(0);
        }
        else
        {
            if (CKeyboard.pressed(CKeyboard.LEFT))
            {
                // Chequear pared a la izquierda.
                // Si hay pared a la izquierda vamos a stand.
                if (isWallLeft(getX() - 1, mOldY))
                {
                    // Reposicionar el personaje contra la pared.
                    setX(((mLeftX + 1) * CTileMap.TILE_WIDTH) - X_OFFSET_BOUNDING_BOX);
                }
                else
                {
                    // No hay pared, se puede mover.
                    setVelX(-speed);
                    setFlip(true);
                }
            }
            else
            {
                // Chequear pared a la derecha.
                // Si hay pared a la derecha vamos a stand.
                if (isWallRight(getX() + 1, mOldY))
                {
                    // Reposicionar el personaje contra la pared.
                    setX((((mRightX) * CTileMap.TILE_WIDTH) - getWidth()) + X_OFFSET_BOUNDING_BOX);
                }
                else
                {
                    // No hay pared, se puede mover.
                    setVelX(speed);
                    setFlip(false);
                }
            }
        }
    }
    public void ghostMove()
    {

        /*if (!CKeyboard.pressed(CKeyboard.LEFT) && (!CKeyboard.pressed(CKeyboard.RIGHT)))
        {
            setVelX(0);
        }
        else*/
        if (CKeyboard.pressed(CKeyboard.LEFT))
        {
            setVelX(-speed);
        }
        else if (CKeyboard.pressed(CKeyboard.RIGHT))
        {
            setVelX(speed);
        }
        /*if (!CKeyboard.pressed(CKeyboard.UP) && (!CKeyboard.pressed(CKeyboard.DOWN)))
        {
            setVelY(0);
        }
        else */
        if (CKeyboard.pressed(CKeyboard.UP))
        {
            setVelY(-speed);
        }
        else if (CKeyboard.pressed(CKeyboard.DOWN))
        {
            setVelY(speed);
        }
    }
    override public void render()
    {
        base.render();

        // MOSTRAR TODA EL AREA DEL DIBUJO.
        /*mRect.setXY (getX(), getY());
		mRect.setScaleX(WIDTH);
		mRect.setScaleY(HEIGHT);
		mRect.update ();

		mRect.render ();*/

        // Bounding box.
        mRect2.setXY(getX() + X_OFFSET_BOUNDING_BOX, getY() + Y_OFFSET_BOUNDING_BOX);
        mRect2.setScaleX(WIDTH - (X_OFFSET_BOUNDING_BOX * 2));
        mRect2.setScaleY(HEIGHT - Y_OFFSET_BOUNDING_BOX);
        mRect2.update();

        mRect2.render();
        /*if (box != null)
        {
            box.render();
        }*/
        mHitBoxManager.render();
    }

    override public void destroy()
    {
        base.destroy();

        mRect2.destroy();
        mRect2 = null;
        if (box != null)
        {
            box.destroy();
            box = null;
        }
        mHitBoxManager.destroy();
        mHitBoxManager = null;
    }

    public override void setState(int aState)
    {
        base.setState(aState);

        if (getState() == STATE_STAND)
        {
            stopMove();
            //gotoAndStop(1);
        }
        else if (getState() == STATE_WALKING)
        {
            //initAnimation(2, 9, 12, true);
        }
        else if (getState() == STATE_JUMPING)
        {
            //initAnimation(10, 17, 12, false);
            setVelY(CGameConstants.JUMP_SPEED);
            setAccelY(CGameConstants.GRAVITY);
        }
        else if (getState() == STATE_FALLING)
        {
            //initAnimation(15, 17, 12, false);
            setAccelY(CGameConstants.GRAVITY);
        }
        else if (getState() == STATE_HIT_ROOF)
        {
            stopMove();
        }
        else if(getState() == STATE_GHOST)
        {
            stopMove();
        }
    }
}
    
