using UnityEngine;
using System.Collections;

public class CGame : MonoBehaviour
{
	static private CGame mInstance;
	private CGameState mState;

	private CTileMap mMap;

	void Awake() 
	{
		if (mInstance != null)
		{
			throw new UnityException ("Error in CGame(). You are not allowed to instantiate it more than once.");
		}

		mInstance = this;

		CMouse.init();
		CKeyboard.init ();

        // INIT FIRST STATE
        setState(new CLevel1());
	}

	static public CGame inst()
	{
		return mInstance;
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		update ();
	}

	void LateUpdate()
	{
		render();
	}

	private void update()
	{
		CMouse.update ();
		CKeyboard.update ();
		mState.update ();
	}

	private void render()
	{
		mState.render ();
	}

	public void destroy()
	{
		CMouse.destroy ();
		CKeyboard.destroy ();
		if (mState != null) 
		{
			mState.destroy ();
			mState = null;
		}
		mInstance = null;
	}

	public void setState(CGameState aState)
	{
		if (mState != null) 
		{
			mState.destroy();
			mState = null;
		}

		mState = aState;
        Debug.Log("holi");
		mState.init ();
	}

	public CGameState getState()
	{
		return mState;
	}

	public void setMap(CTileMap aMap)
	{
		mMap = aMap;
	}

	public CTileMap getMap()
	{
		return mMap;
	}
}
