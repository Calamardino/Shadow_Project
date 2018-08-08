using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class hitBoxManager: CManager
{
    static private bool mInitialized = false;
    /*static private List<hitBox> allyHitbox;
    static private List<hitBox> enemyHitbox;*/

    public static void init()
    {
        if (mInitialized)
        {
            return;
        }
        mInitialized = true;
    }

    override public void update()
    {
        base.update();
    }

    override public void render()
    {
        base.render();
    }

    override public void destroy()
    {
        if (mInitialized)
        {
            mInitialized = false;

            /*allyHitbox.Clear();
            enemyHitbox.Clear();*/


        }
    }
    public void addBox(hitBox box)
    {
        base.add(box);
        Debug.Log("He agregado un box al manager");
    }

}