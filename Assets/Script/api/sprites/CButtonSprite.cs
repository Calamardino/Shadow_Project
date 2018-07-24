using UnityEngine;
using System.Collections;
using TMPro;

public class CButtonSprite : CAnimatedSprite
{
	public bool mIsMouseOver = false;
	protected CText buttonText;

	public CButtonSprite(string buttonText = null)
	{
		this.setName("Button - " + buttonText);
		this.setFrames(Resources.LoadAll<Sprite>("Sprites/ui"));
		this.gotoAndStop(1);
		this.setWidth(190);
		this.setHeight(50);
		this.setSortingLayerName("UI");

		this.buttonText = new CText(buttonText);
		this.buttonText.setColor(Color.white);
		this.buttonText.setWidth(this.getWidth());
		this.buttonText.setHeight(this.getHeight());
		this.buttonText.setAlignment(TextAlignmentOptions.Midline);
		this.buttonText.setFontSize(300f);
        this.buttonText.setPivot(0.5f, 0.5f);
	}

	public override void update()
	{
		base.update ();

		float scale = 1.0f;
		int frame = 1;

		Vector3 mousePos = CMouse.getPos ();
		mIsMouseOver = CMath.pointInRect (mousePos.x, mousePos.y, getX () - getWidth () / 2, getY () - getHeight () / 2, getWidth (), getHeight ());

		if (CMouse.pressed ()) 
		{
			if (mIsMouseOver) 
			{
				scale = 0.9f;
				frame = 2;
			}
		} 
		else 
		{
			if (mIsMouseOver)
			{
				scale = 1.1f;
				frame = 1;
			}
			else
			{
				scale = 1.0f;
				frame = 1;
			}
		}

		setScale (scale);
        this.buttonText.setScale(scale);

        gotoAndStop (frame);

		this.buttonText.setXY(this.getX(), this.getY());
		this.buttonText.update();
	}

	public override void render()
	{
		base.render ();
		this.buttonText.render();
	}

	public override void destroy()
	{
		base.destroy ();

		this.buttonText.destroy();
	}

	public bool isMouseOver()
	{
		return mIsMouseOver;
	}

	public bool pressed()
	{
		return (CMouse.pressed () && mIsMouseOver);
	}

	public bool clicked()
	{
		if(!this.isVisible())
		{
			return false;
		}
		
		Vector3 mousePos = CMouse.getPos ();

		if (CMouse.release ()) 
		{
			if (CMath.pointInRect (mousePos.x, mousePos.y, getX () - getWidth () / 2, getY () - getHeight () / 2, getWidth (), getHeight ()))
			{
				return true;
			}
		}

		return false;
	}
	
	override public void setVisible(bool aIsVisible)
	{
		base.setVisible(aIsVisible);
		this.buttonText.setVisible(aIsVisible);
	}
}