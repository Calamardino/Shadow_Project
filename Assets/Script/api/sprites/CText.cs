using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CText : CGameObject
{
	private TextMeshPro displayText;

	private static GameObject UICanvas = new GameObject();
	private GameObject text;
	public CText(string text)
	{
		this.text = new GameObject();

		if(! CText.UICanvas.GetComponent<Canvas>())
		{
			Canvas canvas = CText.UICanvas.AddComponent<Canvas>();
			CText.UICanvas.name = "Canvas";
			canvas.sortingLayerName = "UI";
		}

		this.displayText = this.text.AddComponent<TextMeshPro>();
		this.displayText.SetText(text);
		this.displayText.rectTransform.pivot = new Vector2(0, 1);
		this.setName(text);

		this.text.transform.SetParent(CText.UICanvas.transform);
		this.displayText.sortingLayerID = SortingLayer.NameToID("UI");
	}

	public void setText(string newText)
	{
		base.update();

		this.displayText.SetText(newText);
		this.setName(newText);
	}

	override public void update()
	{
		base.update();
		this.displayText.rectTransform.sizeDelta = new Vector2(this.getWidth(), this.getHeight());
	}

	override public void render()
	{
		base.render();

		Vector3 pos = new Vector3(getX(), getY() * -1, 0.0f);

		this.text.transform.position = pos;
		this.displayText.transform.position = pos;
	}

	override public void destroy()
	{
		base.destroy();

		Object.Destroy(this.displayText);
		Object.Destroy(this.text);
	}

	override public void setName(string aName)
	{
		base.setName("Texto - " + aName);
		this.text.name = "Texto - " + aName;
	}

	public void setColor(Color color)
	{
		this.displayText.color = color;
	}

	public void setFontSize(float size)
	{
		this.displayText.fontSize = size;
	}

	public void setCanAutoSize(bool canAutoSize)
	{
		this.displayText.autoSizeTextContainer = canAutoSize;
	}

	public void setAlignment(TextAlignmentOptions alignment)
	{
		this.displayText.alignment = alignment;
	}

	public void setVisible(bool visible)
	{
		this.displayText.enabled = visible;
	}

	public void setWrapping(bool wrapping)
	{
		this.displayText.enableWordWrapping = wrapping;
	}
 
	public static void setSortingLayerName(string aSortingLayerName)
	{
		CText.UICanvas.GetComponent<Canvas>().sortingLayerName = aSortingLayerName;
	}

    public void setPivot(float x, float y)
    {
        this.displayText.rectTransform.pivot = new Vector2(x, y);
    }

    public void setScale(float aScale)
    {
        this.displayText.transform.localScale = new Vector3(aScale, aScale, 0.0f);
    }

}