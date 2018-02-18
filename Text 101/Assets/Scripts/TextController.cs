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
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.S)) myState = States.Stairs0;
		else if(Input.GetKeyDown(KeyCode.F)) myState = States.Floor;
		else if(Input.GetKeyDown(KeyCode.C)) myState = States.ClosetDoor;
    }

    void StateCorridor1() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.S)) myState = States.Stairs1;
        else if(Input.GetKeyDown(KeyCode.P)) myState = States.InCloset;
    }

    void StateCorridor2() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.S)) myState = States.Stairs2;
        else if(Input.GetKeyDown(KeyCode.B)) myState = States.InCloset;
    }

    void StateCorridor3() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.S)) myState = States.Courtyard;
        else if(Input.GetKeyDown(KeyCode.U)) myState = States.InCloset;
    }

    void StateFloor() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.H)) myState = States.Corridor1;
        else if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor0;
    }

    void StateStairs0() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor0;
    }

    void StateStairs1() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor1;
    }

    void StateStairs2() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor2;
    }

    void StateClosetDoor() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor0;
    }

    void StateInCloset() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.D)) myState = States.Corridor3;
        else if(Input.GetKeyDown(KeyCode.R)) myState = States.Corridor2;
    }

    void StateCourtyard() {
        text.text = "You are in the corridor.\n\n";
        if(Input.GetKeyDown(KeyCode.P)) myState = States.Cell;
    }
}