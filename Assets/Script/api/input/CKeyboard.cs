using UnityEngine;
using System.Collections;

public class CKeyboard
{
	static private bool mInitialized = false;

    // De F1 a F12
    public const KeyCode KEY_F1 = KeyCode.F1;
    public const KeyCode KEY_F2 = KeyCode.F2;
    public const KeyCode KEY_F3 = KeyCode.F3;
    public const KeyCode KEY_F4 = KeyCode.F4;
    public const KeyCode KEY_F5 = KeyCode.F5;
    public const KeyCode KEY_F6 = KeyCode.F6;
    public const KeyCode KEY_F7 = KeyCode.F7;
    public const KeyCode KEY_F8 = KeyCode.F8;
    public const KeyCode KEY_F9 = KeyCode.F9;
    public const KeyCode KEY_F10 = KeyCode.F10;
    public const KeyCode KEY_F11 = KeyCode.F11;

    // Números:
    public const KeyCode KEY_1 = KeyCode.Alpha1;
    public const KeyCode KEY_2 = KeyCode.Alpha2;
    public const KeyCode KEY_3 = KeyCode.Alpha3;
    public const KeyCode KEY_4 = KeyCode.Alpha4;
    public const KeyCode KEY_5 = KeyCode.Alpha5;
    public const KeyCode KEY_6 = KeyCode.Alpha6;
    public const KeyCode KEY_7 = KeyCode.Alpha7;
    public const KeyCode KEY_8 = KeyCode.Alpha8;
    public const KeyCode KEY_9 = KeyCode.Alpha9;
    public const KeyCode KEY_0 = KeyCode.Alpha0;

    // Letras:
    public const KeyCode KEY_Q = KeyCode.Q;
    public const KeyCode KEY_W = KeyCode.W;
    public const KeyCode KEY_E = KeyCode.E;
    public const KeyCode KEY_R = KeyCode.R;
    public const KeyCode KEY_T = KeyCode.T;
    public const KeyCode KEY_Y = KeyCode.Y;
    public const KeyCode KEY_U = KeyCode.U;
    public const KeyCode KEY_I = KeyCode.I;
    public const KeyCode KEY_O = KeyCode.O;
    public const KeyCode KEY_P = KeyCode.P;
    public const KeyCode KEY_A = KeyCode.A;
    public const KeyCode KEY_S = KeyCode.S;
    public const KeyCode KEY_D = KeyCode.D;
    public const KeyCode KEY_F = KeyCode.F;
    public const KeyCode KEY_G = KeyCode.G;
    public const KeyCode KEY_H = KeyCode.H;
    public const KeyCode KEY_J = KeyCode.J;
    public const KeyCode KEY_K = KeyCode.K;
    public const KeyCode KEY_L = KeyCode.L;
    public const KeyCode KEY_Z = KeyCode.Z;
    public const KeyCode KEY_X = KeyCode.X;
    public const KeyCode KEY_C = KeyCode.C;
    public const KeyCode KEY_V = KeyCode.V;
    public const KeyCode KEY_B = KeyCode.B;
    public const KeyCode KEY_N = KeyCode.N;
    public const KeyCode KEY_M = KeyCode.M;

    // Teclas del Keypad:
    public const KeyCode KEYPAD_0 = KeyCode.Keypad0;
    public const KeyCode KEYPAD_1 = KeyCode.Keypad1;
    public const KeyCode KEYPAD_2 = KeyCode.Keypad2;
    public const KeyCode KEYPAD_3 = KeyCode.Keypad3;
    public const KeyCode KEYPAD_4 = KeyCode.Keypad4;
    public const KeyCode KEYPAD_5 = KeyCode.Keypad5;
    public const KeyCode KEYPAD_6 = KeyCode.Keypad6;
    public const KeyCode KEYPAD_7 = KeyCode.Keypad7;
    public const KeyCode KEYPAD_8 = KeyCode.Keypad8;
    public const KeyCode KEYPAD_9 = KeyCode.Keypad9;
    public const KeyCode KEYPAD_DIVIDE = KeyCode.KeypadDivide;
    public const KeyCode KEYPAD_ENTER = KeyCode.KeypadEnter;
    public const KeyCode KEYPAD_EQUALS = KeyCode.KeypadEquals;
    public const KeyCode KEYPAD_MINUS = KeyCode.KeypadMinus;
    public const KeyCode KEYPAD_MULTIPLY = KeyCode.KeypadMultiply;
    public const KeyCode KEYPAD_PERIOD = KeyCode.KeypadPeriod;
    public const KeyCode KEYPAD_PLUS = KeyCode.KeypadPlus;

    // Teclas con Nombre propio:
    public const KeyCode RIGHT = KeyCode.RightArrow;
    public const KeyCode LEFT = KeyCode.LeftArrow;
    public const KeyCode SPACE = KeyCode.Space;
    public const KeyCode ESCAPE = KeyCode.Escape;
    public const KeyCode UP = KeyCode.UpArrow;
    public const KeyCode DOWN = KeyCode.DownArrow;
    public const KeyCode TAB = KeyCode.Tab;
    public const KeyCode LEFT_SHIFT = KeyCode.LeftShift;
    public const KeyCode LEFT_CTRL = KeyCode.LeftControl;
    public const KeyCode LEFT_ALT = KeyCode.LeftAlt;
    public const KeyCode BACK_QUOTE = KeyCode.BackQuote;
    public const KeyCode COMMA = KeyCode.Comma;
    public const KeyCode PERIOD = KeyCode.Period;
    public const KeyCode RIGHTALT = KeyCode.RightAlt;
    public const KeyCode RIGHT_CTRL = KeyCode.RightControl;
    public const KeyCode RIGHT_SHIFT = KeyCode.RightShift;
    public const KeyCode ENTER = KeyCode.Return;
    public const KeyCode BACKSPACE = KeyCode.Backspace;
    public const KeyCode MINUS = KeyCode.Minus;
    public const KeyCode PLUS = KeyCode.Plus;
    public const KeyCode LESS = KeyCode.Less;
    public const KeyCode GREATER = KeyCode.Greater;
    public const KeyCode EXCLAIM = KeyCode.Exclaim;
    public const KeyCode DOUBLE_QUOTE = KeyCode.DoubleQuote;
    public const KeyCode HASH = KeyCode.Hash;
    public const KeyCode DOLLAR = KeyCode.Dollar;
    public const KeyCode AMPERSAND = KeyCode.Ampersand;
    public const KeyCode QUOTE = KeyCode.Quote;
    public const KeyCode LEFT_PARENTHESIS = KeyCode.LeftParen;
    public const KeyCode RIGHT_PARENTHESIS = KeyCode.RightParen;
    public const KeyCode ASTERISK = KeyCode.Asterisk;
    public const KeyCode SEMICOLON = KeyCode.Semicolon;
    public const KeyCode SLASH = KeyCode.Slash;
    public const KeyCode COLON = KeyCode.Colon;
    public const KeyCode EQUALS = KeyCode.Equals;
    public const KeyCode QUESTION = KeyCode.Question;
    public const KeyCode AT = KeyCode.At;
    public const KeyCode LEFTBRACKET = KeyCode.LeftBracket;
    public const KeyCode RIGHTBRACKET = KeyCode.RightBracket;
    public const KeyCode CARET = KeyCode.Caret;
    public const KeyCode UNDERSCORE = KeyCode.Underscore;
    public const KeyCode NUMLOCK = KeyCode.Numlock;
    public const KeyCode CAPSLOCK = KeyCode.CapsLock;
    public const KeyCode SCROLL_LOCK = KeyCode.ScrollLock;
    public const KeyCode ALTGR = KeyCode.AltGr;
    public const KeyCode PRINT = KeyCode.Print;
    public const KeyCode SYSREQ = KeyCode.SysReq;
    public const KeyCode BREAK = KeyCode.Break;
    public const KeyCode MENU = KeyCode.Menu;


    public CKeyboard()
	{
		throw new UnityException ("Error in CKeyboard(). You're not supposed to instantiate this class.");
	}
	
	public static void init()
	{
		if (mInitialized) 
		{
			return;
		}
		mInitialized = true;
	}
	
	public static void update()
	{
	}
	
	public static void destroy()
	{
		if (mInitialized) 
		{
			mInitialized = false;
		}
	}
	
	public static bool pressed(KeyCode aKey)
	{
		return Input.GetKey(aKey);
	}

	public static bool firstPress(KeyCode aKey)
	{
		return Input.GetKeyDown (aKey);
	}
}