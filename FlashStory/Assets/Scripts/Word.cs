using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Word : MonoBehaviour {
	public string context;
	public bool editable;
	public float secondsforinput = 5.0f;
	public float secondsforwatch = 0.5f;
	public bool wordenabled;
	public int index;


	// Use this for initialization
	void Start () {
		GetComponent<Text> ().enabled = false;
		GetComponent<Text> ().text = context;
	//	this.wordenabled = true;
	
	}

	// Update is called once per frame
	void Update () {
	//	if(wordenabled){
		//	OnRun ();
		//}

	}

	public void OnRun(){
		//Debug.Log ("OnRun");
		GetComponent<Text> ().enabled = true;
		if (editable && secondsforinput > 0) {
				secondsforinput -= Time.deltaTime;
				WaitForEdit ();
			CheckTimer (secondsforinput);
		//	Debug.Log ("editable start");

			}
		else if(!editable && secondsforwatch > 0){
			secondsforwatch -= Time.deltaTime;
			CheckTimer (secondsforwatch);
		//	Debug.Log ("watch start");
		}
		
	}

	public void EndRun(){
		context = GetComponent<Text> ().text;
		//this text enabled has some problems
		GetComponent<Text> ().enabled = false;
		this.wordenabled = false;
		//Debug.Log ("called");
		//call next
	}

	//function for just listening the keyboard input
	public void WaitForEdit(){
		if (editable) {
			foreach(char c in Input.inputString){
				if (c == "\b" [0]) {
					if (GetComponent<Text> ().text.Length != 0) {
						GetComponent<Text> ().text = GetComponent<Text> ().text.Substring (0, GetComponent<Text> ().text.Length - 1);
					}
				}
				else if (c == "\n"[0] || c == "\r"[0]) {
					EndRun ();
				}
				else GetComponent<Text> ().text += (""+c);
			}
		}
	}

	//Check the timer is smaller than 0, if so call EndRun();
	public void CheckTimer(float t){
		if(t <= 0){
			EndRun ();
			//Debug.Log ("endRun");
		}
	}


}
