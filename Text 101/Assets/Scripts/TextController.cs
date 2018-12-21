using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {
        Cell, Sheets0, Sheets1, Lock0, Lock1, Mirror, CellMirror, Corridor0, Corridor1,
        Corridor2, Corridor3, Floor, Stairs0, Stairs1, Stairs2, ClosetDoor, InCloset, Courtyard
    };
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.Cell;
	}
	
	// Update is called once per frame
	void Update () {
		if(myState == States.Cell) StateCell();
		else if(myState == States.Sheets0) StateSheets0();
		else if(myState == States.Sheets1) StateSheets1();
		else if(myState == States.Lock0) StateLock0();
	    else if(myState == States.Lock1) StateLock1();
		else if(myState == States.Mirror) StateMirror();
		else if(myState == States.CellMirror) StateCellMirror();
		else if(myState == States.Corridor0) StateCorridor0();
        else if(myState == States.Corridor1) StateCorridor1();
		else if(myState == States.Corridor2) StateCorridor2();
		else if(myState == States.Corridor3) StateCorridor3();
	    else if(myState == States.Floor) StateFloor();
		else if(myState == States.Stairs0) StateStairs0();
		else if(myState == States.Stairs1) StateStairs1();
		else if(myState == States.Stairs2) StateStairs2();
        else if(myState == States.ClosetDoor) StateClosetDoor();
		else if(myState == States.InCloset) StateInCloset();
		else if(myState == States.Courtyard) StateCourtyard();
	}

	void StateCell() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror and L to view Lock";
		if(Input.GetKeyDown(KeyCode.S)) myState = States.Sheets0;
		else if(Input.GetKeyDown(KeyCode.M)) myState = States.Mirror;
		else if(Input.GetKeyDown(KeyCode.L)) myState = States.Lock0;
	}

    void StateMirror() {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to Take the mirror, or R to Return to cell";
        if(Input.GetKeyDown(KeyCode.T)) myState = States.CellMirror;
        else if(Input.GetKeyDown(KeyCode.R)) myState = States.Cell;
    }

    void StateSheets0() {
        text.text = "You can't believe you sleep in these things. Surely it's " +
                    "time somebody changed them. The pleasures of prison life " +
                    "I guess!\n\n" +
                    "Press R to Return to roaming your cell";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Cell;
    }

    void StateLock0() {
        text.text = "This is one of those button locks. You have no idea what the " +
                    "combination is. You wish you could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n\n" +
                    "Press R to Return to roaming your cell";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Cell;
    }

    void StateCellMirror() {
        text.text = "You are still in your cell, and you STILL want to escape! There are " +
                    "some dirty sheets on the bed, a mark where the mirror was, " +
                    "and that pesky door is still there, and firmly locked!\n\n" +
                    "Press S to view Sheets, or L to view Lock";
        if(Input.GetKeyDown(KeyCode.S)) myState = States.Sheets1;
        else if(Input.GetKeyDown(KeyCode.L)) myState = States.Lock1;
    }

    void StateSheets1() {
        text.text = "Holding a mirror in your hand doesn't make the sheets look " +
                    "any better.\n\n" +
                    "Press R to Return to roaming your cell";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.CellMirror;
    }

    void StateLock1() {
        text.text = "You carefully put the mirror through the bars, and turn it round " +
                    "so you can see the lock. You can just make out fingerprints around " +
                    "the buttons. You press the dirty buttons, and hear a click.\n\n" +
                    "Press C to Corridor, or R to Return to your cell";
        if(Input.GetKeyDown(KeyCode.C)) myState = States.Corridor0;
        else if(Input.GetKeyDown(KeyCode.R)) myState = States.CellMirror;
    }

    void StateCorridor0() {
        text.text = "You're out of your cell, but not out of trouble." +
                    "You are in the corridor, there's a closet and some stairs leading to " +
                    "the courtyard. There's also various detritus on the floor.\n\n" +
                    "C to view the Closet, F to inspect the Floor, and S to climb the Stairs";
        if(Input.GetKeyDown(KeyCode.S)) myState = States.Stairs0;
		else if(Input.GetKeyDown(KeyCode.F)) myState = States.Floor;
		else if(Input.GetKeyDown(KeyCode.C)) myState = States.ClosetDoor;
    }

    void StateCorridor1() {
        text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
                    "Now what? You wonder if that lock on the closet would succumb to " +
                    "to some lock-picking?\n\n" +
                    "P to Pick the lock, and S to climb the Stairs";
        if(Input.GetKeyDown(KeyCode.S)) myState = States.Stairs1;
        else if(Input.GetKeyDown(KeyCode.P)) myState = States.InCloset;
    }

    void StateCorridor2() {
        text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
                    "Press R to Return to the closet, and S to climb the Stairs";     
        if(Input.GetKeyDown(KeyCode.S)) myState = States.Stairs2;
        else if(Input.GetKeyDown(KeyCode.R)) myState = States.InCloset;
    }

    void StateCorridor3() {
        text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
                    "You strongly consider the run for freedom.\n\n" +
                    "Press S to take the Stairs, or U to Undress";
        if(Input.GetKeyDown(KeyCode.S)) myState = States.Courtyard;
        else if(Input.GetKeyDown(KeyCode.U)) myState = States.InCloset;
    }

    void StateFloor() {
        text.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
                    "Press R to Return to the standing, or H to take the Hairclip.";
        if(Input.GetKeyDown(KeyCode.H)) myState = States.Corridor1;
        else if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor0;
    }

    void StateStairs0() {
        text.text = "You start walking up the stairs towards the outside light. " +
                    "You realise it's not break time, and you'll be caught immediately. " +
                    "You slither back down the stairs and reconsider.\n\n" +
                    "Press R to Return to the corridor.";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor0;
    }

    void StateStairs1() {
        text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
                    "confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
                    "Press R to Return to the corridor";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor1;
    }

    void StateStairs2() {
        text.text = "You feel smug for picking the closet door open, and are still armed with " +
                    "a hairclip (now badly bent). Even these achievements together don't give " +
                    "you the courage to climb up the staris to your death!\n\n" +
                    "Press R to Return to the corridor";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor2;
    }

    void StateClosetDoor() {
        text.text = "You are looking at a closet door, unfortunately it's locked. " +
                    "Maybe you could find something around to help enourage it open?\n\n" +
                    "Press R to Return to the corridor";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor0;
    }

    void StateInCloset() {
        text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
                    "Seems like your day is looking-up.\n\n" +
                    "Press D to Dress up, or R to Return to the corridor.";
        if(Input.GetKeyDown(KeyCode.D)) myState = States.Corridor3;
        else if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor2;
    }

    void StateCourtyard() {
        text.text = "You walk through the courtyard dressed as a cleaner. " +
                    "The guard tips his hat at you as you waltz past, claiming " +
                    "your freedom. You heart races as you walk into the sunset.\n\n" +
                    "Press P to Play again, or Q to Quit the game.";
        if(Input.GetKeyDown(KeyCode.P)) myState = States.Cell;
        if(Input.GetKeyDown(KeyCode.Q)) Application.Quit();
    }
}