using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLevel1 : CGameState
{
    public const int IN_PROGRESS = 0;
    public const int FINISHED = 1;
    private CPlayer mAndy;

    private CTileMap mMap;

    private hitBoxManager mHitBoxManager;

    private bigEnemy mBigEnemy;
    

    //private CText title;
    override public void init()
    {
        base.init();
        mMap = new CTileMap();
        CGame.inst().setMap(mMap);
        setState(CLevel1.IN_PROGRESS);
        Debug.Log("cree CLevel1");
        mAndy = new CPlayer();
        mAndy.setXY(200, 200);
        /*title = new CText("holi");
        title.setXY(200, 200);*/
        mBigEnemy = new bigEnemy();


        mHitBoxManager = new hitBoxManager();
    }
    public override void update()
    {
        base.update();
        mMap.update();
        mAndy.update();
        //title.update();
        mHitBoxManager.update();
        mBigEnemy.update();
    }
    public override void render()
    {
        base.render();
        mMap.render();
        mAndy.render();
        //title.render();
        mHitBoxManager.render();
        mBigEnemy.render();
    }
    public override void destroy()
    {
        base.destroy();

        mMap.destroy();
        mMap = null;

        mAndy.destroy();
        mAndy = null;

        mBigEnemy.destroy();
        mBigEnemy = null;

        mHitBoxManager.destroy();

        /*title.destroy();
        title = null;*/
    }
}
