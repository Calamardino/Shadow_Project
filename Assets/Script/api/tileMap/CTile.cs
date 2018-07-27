using UnityEngine;
using System.Collections;

public class CTile : CSprite
{
	// Tile index. Starting from 0.
	private int mTileIndex;

    // True = se puede caminar. False = no se puede traspasar.
    private bool mIsWalkable;

    // Parametros: coordenada del tile (x, y) y el indice del tile.
    public CTile(int aX, int aY, int aTileIndex, Sprite aSprite)
	{
		setXY (aX, aY);
		setTileIndex(aTileIndex);

		setImage (aSprite);
		setSortingLayerName ("MapExplorer");
        setName("tile");
        setScale(2.0f);
    }

	public void setTileIndex(int aTileIndex)
	{
		mTileIndex = aTileIndex;

        // Set walkable information.
        if (aTileIndex == 1 || aTileIndex == 2)
            mIsWalkable = false;
        else
            mIsWalkable = true;
    }

	public int getTileIndex()
	{
		return mTileIndex;
	}

	override public void render()
	{
		base.render ();
	}

	override public void update()
	{
		base.update ();
	}

	override public void destroy()
	{
		base.destroy();
		this.mTileIndex = 0;
	}
    public bool isWalkable()
    {
        return mIsWalkable;
    }

    public void setWalkable(bool aIsWalkable)
    {
        mIsWalkable = aIsWalkable;
    }

    // Desde tilemap la llamamos para cambiar un tile con otro, incluyamosla para probar colisiones.
    public void clicked()
    {
        //setColor(Color.red);
    }
}
