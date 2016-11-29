using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public List<Word> wlist;
	public GameObject lastshow;
	public bool gameover;
	private bool once = true;
	//GameObject manager;
	// Use this for initialization
	void Start () {
		gameover = false;
		//add all word prefabs to the array
		Word[] wl = FindObjectsOfType (typeof(Word)) as Word[];
		//transfering to a list
		List<Word> words = new List<Word> (wl);

		//before sorting check the list

		//sorting the words by index!
		SortWords(words);
		wlist = new List<Word>(words);

	}
	
	// Update is called once per frame
	void Update () {
		CheckOver ();
		CallWord ();

	}
		

	//magic sorting the list
	void SortWords(List<Word> thelist){
		for(int i=0; i < thelist.Count; i++){
			for(int j=0; j < thelist.Count; j++){
				if (thelist[i].index < thelist [j].index) {
					Word temp = thelist [i];
					thelist [i] = thelist [j];
					thelist [j] = temp;
				}
			}
		}
	}

	public void CallWord(){
		//get the first word that is enabled in the list, and grab the instance of it;
		Word w = wlist.Find(x => x.wordenabled == true);
		Debug.Log (w.index);
		//if gameover or not;
		//if not, show all words respectly
		if (!gameover) {
			if (w.wordenabled) {
				//call the run function of the current active word. 
				//NOTE: each time there is only 1 Word being called
				w.OnRun ();

			}
		}

	


	}

	public void CheckOver(){
		Word wo = wlist.Find(x => x.wordenabled == true);
		if(!(wo is Word)){
		     gameover = true;
				Debug.Log ("GAMEOVER");

			//only do this chunk once
				if(once){
					foreach (Word wor in wlist) {
						lastshow.GetComponent<Text> ().enabled = true;
						lastshow.GetComponent<Text> ().text += wor.context;
						lastshow.GetComponent<Text> ().text += " ";
						Debug.Log ("go home");
						once = false;
				}
			}
		}
	}

}
