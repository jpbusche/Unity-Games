using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {Cell, Sheets0, Sheets1, Lock0, Lock1, Mirror, CellMirror, Freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.Cell;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.Cell) StateCell();
		//else if (myState == States.Sheets0) StateSheets0();
		//else if (myState == States.Sheets1) StateSheets1();
		//else if (myState == States.Lock0) StateLock0();
		//else if (myState == States.Lock1) StateLock1();
		//else if (myState == States.Mirror) StateMirror();
		//else if (myState == States.CellMirror) StateCellMirror();
		//else if (myState == States.Freedom) StateFreedom();
	}

	void StateCell() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror and L to view Lock";
		if (Input.GetKeyDown (KeyCode.S)) myState = States.Sheets0;
		else if (Input.GetKeyDown (KeyCode.M)) myState = States.Mirror;
		else if (Input.GetKeyDown (KeyCode.L)) myState = States.Lock0;
	}
}