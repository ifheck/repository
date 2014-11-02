using UnityEngine;
using System.Collections;

public class TestDialog : MonoBehaviour {
	// private string dialogString = ""; 
	public GUISkin skin1 = null;
	public Rect winRect1 = new Rect(20, 20, 430, 200);
	public int selGridInt = 0;
	public GUIContent[] contentModeOptions;
	public string paragraphText = "paragraph nothing";
	public string sT = "nothing";


	enum dialogEnums {
		paratext,
		paralabel,
		onetext,
		onecommand,
		onevalue,
		twotext,
		twocommand,
		twovalue,
		threetext,
		threecommand,
		threevalue,
		LAST_ITEM

	};

	private int paralen = 0;
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
		GUILayout.BeginArea (new Rect (0,0,300,300));
		
		// Begin the singular Horizontal Group
		
		// Arrange two more Controls vertically beside the Button
		GUILayout.BeginVertical();
		GUILayout.Label (dialogArray[prg * paralen + (int)dialogEnums.paratext]);
		if (GUILayout.Button (dialogArray [prg * paralen + (int)dialogEnums.onetext])) {
			dialogValue = dialogArray [prg * paralen + (int)dialogEnums.onevalue];
			if (dialogArray [prg * paralen + (int)dialogEnums.onecommand] == "close") {
				dialogShow = false;
			} else {
				prg = WhichPara(dialogArray [prg * paralen + (int)dialogEnums.onecommand]);
			}
		}
		if (GUILayout.Button (dialogArray[prg * paralen + (int)dialogEnums.twotext] )){
			dialogValue = dialogArray [prg * paralen + (int)dialogEnums.twovalue];
			if (dialogArray [prg * paralen + (int)dialogEnums.twocommand] == "close") {
				dialogShow = false;
			} else {
				prg = WhichPara(dialogArray [prg * paralen + (int)dialogEnums.twocommand]);
			}
		}
		if (GUILayout.Button (dialogArray[prg * paralen + (int)dialogEnums.threetext] )){
			dialogValue = dialogArray [prg * paralen + (int)dialogEnums.threevalue];
			if (dialogArray [prg * paralen + (int)dialogEnums.threecommand] == "close") {
				dialogShow = false;
			} else {
				prg = WhichPara(dialogArray [prg * paralen + (int)dialogEnums.threecommand]);
			}
		}

		// End the Groups and Area
		GUILayout.EndVertical();
		GUILayout.EndArea();

		GUI.DragWindow();
	}

	int WhichPara(string paraLabel) {
		int p = -1;
		for (int i = 0; i < dialogArray.GetUpperBound(0); i += paralen) {
			Debug.Log(dialogArray[i * paralen + (int)dialogEnums.paralabel]);
			if (paraLabel == dialogArray[i * paralen + (int)dialogEnums.paralabel]) {
				Debug.Log("hello");
				p = i;
				break;
			}
		}
		return p;
	}

	// Use this for initialization
	void Start () {
		//dialogString = string.Join("~", dialogArray);
		paralen = (int)dialogEnums.LAST_ITEM - 1;
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
