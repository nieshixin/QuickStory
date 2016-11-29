using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
public class DisplayTimer : MonoBehaviour {
	public GameObject WM;
	GameManager gm;

	// Use this for initialization
	void Start () {
		gm = WM.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		Show ();
	
	}

	public void Show(){
		Word w = gm.wlist.Find(x => x.wordenabled == true);
		//special check
		if (w.editable && w.wordenabled) {
			this.GetComponent<Text>().enabled = true;
			Double n = Math.Round (w.secondsforinput);
			this.GetComponent<Text>().text = n.ToString();
		} else if (!w.editable && w.wordenabled) {
			//this.GetComponent<Text>().text = w.secondsforwatch.ToString();
			this.GetComponent<Text>().enabled = false;
		}
}
		
}
