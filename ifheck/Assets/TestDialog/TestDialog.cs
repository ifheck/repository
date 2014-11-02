using UnityEngine;
using System.Collections;

public class TestDialog : MonoBehaviour {
	// private string dialogString = ""; 
	public GUISkin skin1 = null;
	public Rect winRect1 = new Rect(20, 20, 430, 430);
	public int selGridInt = 0;
	public GUIContent[] contentModeOptions;
	public string paragraphText = "paragraph nothing";
	public string sT = "nothing";


	private const int paratext = 0;
	private const int paralabel = 1;
	private const int onetext = 2;
	private const int onecommand = 3;
	private const int onevalue = 4;
	private const int twotext = 5;
	private const int twocommand = 6;
	private const int twovalue = 7;
	private const int threetext = 8;
	private const int threecommand = 9;
	private const int threevalue = 10;
	private const int paralen = 11;


	private int prg = 0;
	private bool dialogShow = true;
	private string dialogValue = "";

	void OnGUI() {
		GUI.skin = skin1;
		if (dialogShow)
			winRect1 = GUI.Window(0, winRect1, drawWin1, "test");
		// Wrap everything in the designated GUI Area

		
	}
	void drawWin1(int windowID) { 
		//GUILayout.BeginArea (new Rect (0,0,500,500));
		
		// Begin the singular Horizontal Group
		
		// Arrange two more Controls vertically beside the Button
		GUILayout.BeginVertical();
		GUILayout.Label (dialogArray[prg + paratext]);
		if (GUILayout.Button (dialogArray [prg + onetext])) {
			dialogValue = dialogArray [prg + onevalue];
			if (dialogArray [prg + onecommand] == "close") {
				dialogShow = false;
			} else {
				prg = WhichPara(dialogArray [prg + onecommand]);
			}
		}
		if (GUILayout.Button (dialogArray[prg + twotext] )){
			dialogValue = dialogArray [prg + twovalue];
			if (dialogArray [prg + twocommand] == "close") {
				dialogShow = false;
			} else {
				prg = WhichPara(dialogArray [prg + twocommand]);
			}
		}
		if (GUILayout.Button (dialogArray[prg + threetext] )){
			dialogValue = dialogArray [prg + threevalue];
			if (dialogArray [prg + threecommand] == "close") {
				dialogShow = false;
			} else {
				prg = WhichPara(dialogArray [prg + threecommand]);
			}
		}
		GUILayout.Label (dialogValue);

		// End the Groups and Area
		GUILayout.EndVertical();
		//GUILayout.EndArea();

		GUI.DragWindow();
	}

	int WhichPara(string paraLabel) {
		int p = -1;
		for (int i = 0; i < dialogArray.GetUpperBound(0); i += paralen) {
			if (paraLabel == dialogArray[i  + paralabel]) {
				p = i;
				break;
			}
		}
		return p;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//string.Join(",", arr);
	private string[] dialogArray = { 
		"This is the first paragraph.  It has some text.  Not a lot of text.", "para1",
		"Here is my first option. It goes to two.", "para2" , "hereispara1sent1", 
		"Here is my second option. It goes to three.", "para3", "", 
		"Here is my third option. It closes dialog.", "close", "", 
		"This is the second paragraph.  It has some text.  Not a lot of text.", "para2",
		"Here is my first option. It goes to one.", "para1" , "hereispara2sent1", 
		"Here is my second option. It goes to three.", "para3", "", 
		"Here is my third option. It closes dialog.", "close", "", 
		"This is the third paragraph.  It has some text.  Not a lot of text.", "para3",
		"Here is my first option. It goes to two.", "para2" , "hereispara3sent1", 
		"Here is my second option. It goes to one.", "para1", "threeandtwo", 
		"Here is my third option. It closes dialog.", "close", "" 

	};


}
