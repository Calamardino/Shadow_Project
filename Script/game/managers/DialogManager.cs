using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


static public class DialogManager 
{
    static private bool mInitialized = false;
    static private CSprite shadow;
    static private CAnimatedSprite characterPortrait;
    static private CText text;
    static private int currentDialog;
    static private List<Dialog> dialogs;

    private static int MARGIN = 80;
	
	public static void init()
	{
		if (mInitialized) 
		{
			return;
		}
		mInitialized = true;

        dialogs = new List<Dialog>();

        shadow = new CSprite();
        //Esta tambien el shadow solo que llena toda la pantalla
        shadow.setImage(Resources.Load<Sprite>("Sprites/dialogShadow/shadow"));
        shadow.setName("Dialog - Background");
        shadow.setSortingLayerName("UI");
        shadow.setXY(0, CGameConstants.SCREEN_HEIGHT / 3 * 2);
        shadow.setWidth(CGameConstants.SCREEN_WIDTH);
        shadow.setVisible(false);

        characterPortrait = new CAnimatedSprite();
        characterPortrait.setName("Character - Portrait");
        characterPortrait.setSortingLayerName("UI");
        characterPortrait.setXY(shadow.getX() + MARGIN, shadow.getY() + MARGIN);
        characterPortrait.setVisible(false);
        characterPortrait.setSortingOrder(1);

        text = new CText("");
        text.setFontSize(500.0f);
        text.setVisible(false);
        text.setXY(CGameConstants.SCREEN_WIDTH / 4 + MARGIN, shadow.getY() + MARGIN);
        text.setWidth(CGameConstants.SCREEN_WIDTH / 4 * 3 - MARGIN * 2);

    }

	public static void update()
	{
        shadow.update();
        text.update();
        characterPortrait.update();
        
        if (dialogs.Count > 0 && CKeyboard.firstPress(CKeyboard.ENTER))
        {

            if (dialogs[currentDialog].hasNextDialog())
            {
                text.setText(dialogs[currentDialog].goToNextDialog());
            }
            else if(currentDialog < dialogs.Count - 1)
            {
                currentDialog++;

                if(dialogs[currentDialog].hasPortrait())
                {
                    if(dialogs[currentDialog - 1].getPortrait() != dialogs[currentDialog].getPortrait())
                    {
                        characterPortrait.setFrames(Resources.LoadAll<Sprite>(dialogs[currentDialog].getPortrait()));
                        //characterPortrait.gotoAndPlay(1);
                        //characterPortrait.proceedAnimation();
                        characterPortrait.setVisible(true);
                    }
                }
                else
                {
                    characterPortrait.setVisible(false);
                }

                text.setText(dialogs[currentDialog].getCurrentDialog());
            }
            else
            {
                dialogs.Clear();
                text.setText("");
                shadow.setVisible(false);
                text.setVisible(false);
                currentDialog = 0;

                characterPortrait.setVisible(false);
            }
        }
	}

    public static void render()
    {
        shadow.render();
        text.render();
        if (characterPortrait.isVisible()){
            characterPortrait.render();
        }
        
    }

    //En esta funcion lo que hacemos es aceptar el dialogo y la fotoo del peronaje que habla 
    public static void startDialog(Dialog newDialog)
    {
        DialogManager.startDialog(new List<Dialog>() { newDialog });
    }

    public static void startDialog(List<Dialog> newDialogs)
    {
        if(newDialogs.Count <= 0 && newDialogs[0].getText().Length <= 0 || dialogs.Count > 0)
        {
            return;
        }

        if (newDialogs[0].hasPortrait())
        {
            characterPortrait.setFrames(Resources.LoadAll<Sprite>(newDialogs[0].getPortrait()));
            characterPortrait.initAnimation(1, characterPortrait.getFrames().Length, 2, true);
            characterPortrait.setVisible(true);
        }

        dialogs = newDialogs;
        currentDialog = 0;

        text.setText(dialogs[currentDialog].getCurrentDialog());

        shadow.setVisible(true);
        text.setVisible(true);
    }

    public static bool isTalking()
    {
        return dialogs.Count > 0;
    }
	
	public static void destroy()
	{
		if (mInitialized) 
		{
			mInitialized = false;

            shadow.destroy();
            text.destroy();
            characterPortrait.destroy();

        }
	}
}