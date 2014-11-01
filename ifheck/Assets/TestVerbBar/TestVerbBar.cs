using UnityEngine;
using System.Collections;

public class TestVerbBar : MonoBehaviour {
	//Texture2D texture = Resources.Load("Texture") as Texture2D;
	public GUISkin skin1 = null;
	public Rect winRect1 = new Rect(20, 20, 430, 200);
	public string sR = "nothing";


	public int selGridInt = 0;
	public GUIContent[] contentModeOptions;


	// Use this for initialization
	void Start () {
		contentModeOptions = new GUIContent[] {
			new GUIContent(Resources.Load("walk", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("look", typeof(Texture2D)) as Texture2D, "Mode_Height"),
			new GUIContent(Resources.Load("get", typeof(Texture2D)) as Texture2D, "Mode_Terrain"),
			new GUIContent(Resources.Load("open", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("close", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("tell", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("use", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("give", typeof(Texture2D)) as Texture2D, "Mode_Terrain"),
			new GUIContent(Resources.Load("move", typeof(Texture2D)) as Texture2D, "Mode_Object") ,
			new GUIContent(Resources.Load("items", typeof(Texture2D)) as Texture2D, "Mode_Object") 
		};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		GUI.skin = skin1;
		winRect1 = GUI.Window(0, winRect1, drawWin1, "noobtuts.com");
		// Wrap everything in the designated GUI Area
		GUILayout.BeginArea (new Rect (0,0,0,0));
		
		// Begin the singular Horizontal Group

		// Arrange two more Controls vertically beside the Button
		GUILayout.BeginVertical();
		GUILayout.Label (sR);
		// End the Groups and Area
		GUILayout.EndVertical();
		GUILayout.EndArea();


	}
	void drawWin1(int windowID) {    
		selGridInt = GUILayout.SelectionGrid(selGridInt, contentModeOptions, 5);
		if (GUI.changed)
		{
			sR=selGridInt.ToString();
//			print ("The toolbar was clicked");
//			
//			if (selGridInt == 0)
//			{
//				print ("First button was clicked");
//			}
//			else
//			{
//				print ("Second button was clicked");
//			}
		}

		GUI.DragWindow();
		// simple button
//		if (GUI.Button(new Rect(50, 100, 100, 50), "Clicked: " + counter))
//			counter = counter + 1;
//		
//		// simple label
//		GUI.Label(new Rect(170, 100, 200, 35), "I love noobtuts.com");
//		
//		// box without any text
//		GUI.Box(new Rect(50, 180, 150, 50), "");
//		
//		// box with text
//		GUI.Box(new Rect(220, 180, 150, 50), "BoxText");
//		
//		// text field (always needs a string to save the text)
//		text = GUI.TextField(new Rect(50, 240, 150, 50), text);
//		
//		// toggle
//		toggle = GUI.Toggle(new Rect(50, 290, 150, 50), toggle, "Toggle Me");        
	}


}
