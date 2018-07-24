using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class turnActionManager : CManager
{
    private static turnActionManager mInst = null;
    private Dictionary<CGameObject, int> targetAndTurns;
    private int turndamage;

    public turnActionManager()
    {
        registerSingleton();
        targetAndTurns = new Dictionary<CGameObject, int>();
    }

    public static turnActionManager inst()
    {
        return mInst;
    }

    private void registerSingleton()
    {
        if (mInst == null)
        {
            mInst = this;
        }
        else
        {
            throw new UnityException("ERROR: Cannot create another instance of singleton class CEnemyManager.");
        }
    }
     public void addAction(CGameObject skill, CGameObject target, int turns)
    {
        base.add(skill);
        targetAndTurns.Add(target, turns);
    }
    //cuando se setea 
    public void setDamage (int baseDamage, int skillPercentage)
    {
        turndamage = (baseDamage * skillPercentage) / 100;
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
        base.destroy();
        mInst = null;
    }
}