using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestItems : MonoBehaviour {
	//Texture2D texture = Resources.Load("Texture") as Texture2D;
	public GUISkin skin1 = null;
	public Rect winRect1 = new Rect(20, 20, 430, 200);
	public string sR = "nothing";
	public string sT = "nothing";

	
	public int selGridInt = 0;
	public GUIContent[] contentModeOptions;

	private List<string> listItems = new List<string>();

	
	
	// Use this for initialization
	void Start () {
		listItems.Add("look");
		listItems.Add("open");
		listItems.Add("walk");

		contentModeOptions = new GUIContent[] {
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Height"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Terrain"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Height"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Terrain"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Pointer"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Terrain"),
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Object") ,
			new GUIContent(Resources.Load("white", typeof(Texture2D)) as Texture2D, "Mode_Object") 
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI() {
		GUI.skin = skin1;
		winRect1 = GUI.Window(0, winRect1, drawWin1, "noobtuts.com");
		// Wrap everything in the designated GUI Area
		GUILayout.BeginArea (new Rect (0,0,300,300));
		
		// Begin the singular Horizontal Group
		
		// Arrange two more Controls vertically beside the Button
		GUILayout.BeginVertical();
		GUILayout.Label (sR);
		if (GUILayout.Button ("+ Tell" ))
			addItem ("tell");
		if (GUILayout.Button ("- Walk" ))
			delItem ("walk");
		GUILayout.Label (sT);
		// End the Groups and Area
		GUILayout.EndVertical();
		GUILayout.EndArea();
		
		
	}
	void drawWin1(int windowID) { 
		selGridInt = GUILayout.SelectionGrid(selGridInt, contentModeOptions, 5);
		if (GUI.changed)
		{
			sR=selGridInt.ToString();
			sT = contentModeOptions[selGridInt].tooltip;
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
	void addItem(string sItem) {
		listItems.Add (sItem);
		for (int i = 0; i < contentModeOptions.GetUpperBound(0); i++) // Loop through List with for
		{
			if(i < listItems.Count) {
				contentModeOptions[i] =new GUIContent (Resources.Load (listItems[i], typeof(Texture2D)) as Texture2D, listItems[i]);
			} else {
				contentModeOptions[i] =new GUIContent (Resources.Load ("white", typeof(Texture2D)) as Texture2D, "white");
			}
		}


	}
	void delItem(string sItem) {
		listItems.Remove (sItem);
		for (int i = 0; i < contentModeOptions.GetUpperBound(0); i++) // Loop through List with for
		{
			if(i < listItems.Count) {
				contentModeOptions[i] =new GUIContent (Resources.Load (listItems[i], typeof(Texture2D)) as Texture2D, listItems[i]);
			} else {
				contentModeOptions[i] =new GUIContent (Resources.Load ("white", typeof(Texture2D)) as Texture2D, "white");
			}
		}
		
		
	}

}
