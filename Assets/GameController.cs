using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	// checkpoints - they're based on the rooms of a house
	private bool check_1, check_2, check_3;

	// winFlag[0]: 0-2,  winFlag[1]: 3-5, winFlag[2]: 6-8
	private int[] winFlag = new int[3];

	// set in inspector
	public Button button0;
	public Button button1;
    public Button button2;
    public Button button3;
	public Button restartButton;

	//button Animators
	Animator button0Anim;
	Animator button1Anim;
	Animator button2Anim;
	Animator button3Anim;

	//callfnc temp animators
	Animator pressedButtonAnim;
	Animator anAnim;
	Animator[] allAnims;

	// set in inspector
	public Sprite[] allTheImages;

    private enum States {  state_0, state_1,  
		state_2, state_3, state_4, state_5, state_6, state_7, 
		state_8, state_9, state_10, state_11, state_12, state_13,
		state_14, state_15, state_16, state_17, state_18, state_19,
		state_20, state_21, state_22 };

	// use in fnc as a place to store the correct state
	private States myStateA, myStateB, myStateC;

	// hold the position of the pressed button for animation
	int posHolder;

/// ************************

	public void Start () {
		
		//Initialize Animators for all 4 buttons.
		button0Anim = button0.GetComponent<Animator>();
		button1Anim = button1.GetComponent<Animator>();
		button2Anim = button2.GetComponent<Animator>();
		button3Anim = button3.GetComponent<Animator>();

		//Call the start function
		myStateA = States.state_0;
		Fnc_0 ();

	}
			
	IEnumerator AnimCoRoutine (States myState, Button pressedButton)
	{
		RunExitAnims (pressedButton);
		yield return new WaitForSeconds(0.5f);
		CallFnc (myState);
	}


	void RunExitAnims (Button pressedButton) {

		//get clicked button's animator
		pressedButtonAnim = pressedButton.GetComponent<Animator> ();
		pressedButtonAnim.Play ("Pressed");

		//get clicked button's position
		posHolder = pressedButtonAnim.GetInteger ("setPosition");

		//animate all dismissed / not chosen buttons
		//1. find the buttons that are not pressed
		//2. find their position
		//3. depending on position - choose animation to run
		allAnims = FindObjectsOfType<Animator> ();
		foreach (Animator anAnim in allAnims) {
			if (anAnim == button0Anim)
				anAnim.Play ("Dismissed");
			else if (anAnim != pressedButtonAnim)
				anAnim.Play ("NotChosen");
		}
	}

	void CallFnc (States myState){

		button0.onClick.RemoveAllListeners ();
		button1.onClick.RemoveAllListeners ();
		button2.onClick.RemoveAllListeners ();
		button3.onClick.RemoveAllListeners ();

		// start listener for restartbutton?
		//restartButton.onClick.AddListener (() => 

		switch (myState) {
		case States.state_0:
			Fnc_0 ();
			break;
		case  States.state_1:
			Fnc_1 ();
			break;
		case  States.state_2:
			Fnc_2 ();
			break;
		case  States.state_3:
			Fnc_3 ();
			break;
		case  States.state_4:
			Fnc_4 ();
			break;
		case  States.state_5:
			Fnc_5 ();
			break;
		case  States.state_6:
			Fnc_6 ();
			break;
		case  States.state_7:
			Fnc_7 ();
			break;
		case States.state_8:
			Fnc_8();
			break;
		case  States.state_9:
			Fnc_9 ();
			break;
		case  States.state_10:
			Fnc_10 ();
			break;
		case  States.state_11:
			Fnc_11 ();
			break;
		case  States.state_12:
			Fnc_12 ();
			break;
		case  States.state_13:
			Fnc_13 ();
			break;
		case  States.state_14:
			Fnc_14 ();
			break;
		case  States.state_15:
			Fnc_15 ();
			break;
		case  States.state_16:
			Fnc_16 ();
			break;
		case  States.state_17:
			Fnc_17 ();
			break;
		case  States.state_18:
			Fnc_18 ();
			break;
		case  States.state_19:
			Fnc_19 ();
			break;
		case  States.state_20:
			Fnc_20 ();
			break;
		case  States.state_21:
			Fnc_21 ();
			break;

		}
		
		Debug.Log (myState);

	} 

	void Fnc_0 () {

		check_1 = false;
		check_2 = false;
		check_3 = false;

		winFlag [0] = 9;
		winFlag [1] = 9;
		winFlag [2] = 9;

		button0.GetComponent<Image>().sprite = allTheImages [0];
		button1.GetComponent<Image> ().sprite = null;
		button2.GetComponent<Image>().sprite = allTheImages [1];
		button3.GetComponent<Image>().sprite = null;

		button0Anim.Play ("Beginning");          // main
		button2Anim.Play ("IntroducedCenter");  // center

		button0Anim.SetInteger("setPosition", 0);
		button1Anim.SetInteger("setPosition", 1);
		button2Anim.SetInteger("setPosition", 2);
		button3Anim.SetInteger("setPosition", 3);

		myStateB = States.state_1;
		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}


	void Fnc_1 () {

		//set button 0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [1];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}
	
		//set buttons 1,2 and 3 to the correct images and positions, run all the entrance animations.
		button1Anim.Play ("IntroducedLeft"); 
		if (check_1) {
			button1.GetComponent<Image> ().sprite = allTheImages [3];
			myStateA = States.state_3;
		} else {
			button1.GetComponent<Image> ().sprite = allTheImages [2];
			myStateA = States.state_2;
		}


		button2Anim.Play ("IntroducedCenter");
		if (check_2 && check_3) {
			button2.GetComponent<Image> ().sprite = allTheImages [9];
			myStateB = States.state_9;
		} else {
			button2.GetComponent<Image> ().sprite = allTheImages [8];
			myStateB = States.state_8;
		}


		button3Anim.Play ("IntroducedRight");  
		if (check_3 && check_2 && check_1) {
			button3.GetComponent<Image> ().sprite = allTheImages [21];
			myStateC = States.state_21;
		} else {
			button3.GetComponent<Image> ().sprite = allTheImages [20];
			myStateC = States.state_20;
		}


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));


	}
	
	void Fnc_2 ()
	{
		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [2];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = allTheImages [4];
		myStateA = States.state_4;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = null;


		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = allTheImages [1];
		myStateC = States.state_1;


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));

	}

	void Fnc_3 ()
	{

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [3];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = allTheImages [1];
		myStateB = States.state_1;

		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_4 ()
	{
		// Check Point 1
		check_1 = true;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [4];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = allTheImages [5];
		myStateA = States.state_5;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = allTheImages [6];
		myStateB = States.state_6;


		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = allTheImages [7];
		myStateC = States.state_7;


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));

	}

	void Fnc_5 ()
	{
		//this is a winning choice
		winFlag[0] = 0;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [5];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = allTheImages [1];
		myStateB = States.state_1;

		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_6 ()
	{
		//this is a losing choice
		winFlag[0] = 1;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [6];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = allTheImages [1];
		myStateB = States.state_1;

		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_7 ()
	{
		//this is a losing choice
		winFlag[0] = 2;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [7];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = allTheImages [1];
		myStateB = States.state_1;

		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_8 () {

		//set button 0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [8];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}


		//set buttons 1,2 and 3 to the correct images and positions, run all the entrance animations.
		button1Anim.Play ("IntroducedLeft"); 
		button1.GetComponent<Image> ().sprite = allTheImages [1];
		myStateA = States.state_1;


		button2Anim.Play ("IntroducedCenter");
		if (check_2) {
			button2.GetComponent<Image> ().sprite = null;
		} else {
			button2.GetComponent<Image> ().sprite = allTheImages [10];
			myStateB = States.state_10;
		}
	

		button3Anim.Play ("IntroducedRight");  
		if (check_3) {
			button3.GetComponent<Image> ().sprite = allTheImages [15];
			myStateC = States.state_15;
		} else {
			button3.GetComponent<Image> ().sprite = allTheImages [14];
			myStateC = States.state_14;
		}


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));


	}

	void Fnc_9 ()
	{

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [9];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = allTheImages [1];
		myStateB = States.state_1;

		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_10 ()
	{
		// Check Point 2
		check_2 = true;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [10];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = allTheImages [11];
		myStateA = States.state_11;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = allTheImages [12];
		myStateB = States.state_12;


		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = allTheImages [13];
		myStateC = States.state_13;


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));

	}

	void Fnc_11 ()
	{
		// this is a winning choice
		winFlag [1] = 3;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [11];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = allTheImages [1];
		myStateA = States.state_1;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = null;


		button3Anim.Play ("IntroducedRight");  
		if (check_3) {
			button3.GetComponent<Image> ().sprite = allTheImages [15];
			myStateC = States.state_15;
		} else {
			button3.GetComponent<Image> ().sprite = allTheImages [14];
			myStateC = States.state_14;
		}


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));

	}

	void Fnc_12 ()
	{
		// this is a losing choice
		winFlag [1] = 4;
		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [12];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = allTheImages [1];
		myStateA = States.state_1;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = null;


		button3Anim.Play ("IntroducedRight");  
		if (check_3) {
			button3.GetComponent<Image> ().sprite = allTheImages [15];
			myStateC = States.state_15;
		} else {
			button3.GetComponent<Image> ().sprite = allTheImages [14];
			myStateC = States.state_14;
		}


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));

	}

	void Fnc_13 ()
	{
		// this is a losing choice
		winFlag [1] = 5;
		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [13];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = allTheImages [1];
		myStateA = States.state_1;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = null;


		button3Anim.Play ("IntroducedRight");  
		if (check_3) {
			button3.GetComponent<Image> ().sprite = allTheImages [15];
			myStateC = States.state_15;
		} else {
			button3.GetComponent<Image> ().sprite = allTheImages [14];
			myStateC = States.state_14;
		}


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));

	}

	void Fnc_14 ()
	{
		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [14];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft"); 
		if (check_2) {
			button1.GetComponent<Image> ().sprite = allTheImages [9];
			myStateA = States.state_9;
		} else {
			button1.GetComponent<Image> ().sprite = allTheImages [8];
			myStateA = States.state_8;
		}


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = null;


		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = allTheImages [16];
		myStateC = States.state_16;


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));

	}

	void Fnc_15 ()
	{
		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [15];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft"); 
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		if (check_2) {
			button2.GetComponent<Image> ().sprite = allTheImages [9];
			myStateB = States.state_9;
		} else {
			button2.GetComponent<Image> ().sprite = allTheImages [8];
			myStateB = States.state_8;
		}


		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_16 ()
	{
		// Check Point 2
		check_3 = true;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [16];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = allTheImages [17];
		myStateA = States.state_17;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = allTheImages [18];
		myStateB = States.state_18;


		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = allTheImages [19];
		myStateC = States.state_19;


		button1.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button1))); 
		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));
		button3.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateC, button3)));

	}

	void Fnc_17 ()
	{
		//this is a winning choice
		winFlag[2] = 6;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [17];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		if (check_2) {
			button2.GetComponent<Image> ().sprite = allTheImages [9];
			myStateB = States.state_9;
		} else {
			button2.GetComponent<Image> ().sprite = allTheImages [8];
			myStateB = States.state_8;
		}


		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_18 ()
	{
		//this is a losing choice
		winFlag[2] = 7;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [18];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		if (check_2) {
			button2.GetComponent<Image> ().sprite = allTheImages [9];
			myStateB = States.state_9;
		} else {
			button2.GetComponent<Image> ().sprite = allTheImages [8];
			myStateB = States.state_8;
		}


		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_19 ()
	{
		//this is a winning choice
		winFlag[2] = 8;

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [19];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		if (check_2) {
			button2.GetComponent<Image> ().sprite = allTheImages [9];
			myStateB = States.state_9;
		} else {
			button2.GetComponent<Image> ().sprite = allTheImages [8];
			myStateB = States.state_8;
		}


		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_20 ()
	{

		//set button0 to the position of the clicked button
		//set button0's image to the correct image for that function
		//grow button0
		button0Anim.SetInteger ("setPosition", posHolder);
		button0.GetComponent<Image> ().sprite = allTheImages [20];
		switch (posHolder) {
		case 1:
			button0Anim.Play ("LeftChosen"); 
			break;
		case  2:
			button0Anim.Play ("CenterChosen"); 
			break;
		case  3:
			button0Anim.Play ("RightChosen"); 
			break;
		}

		//set buttons 1,2 and 3 to the correct images and positions, then run all the entrance animations.
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;


		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = allTheImages [1];
		myStateB = States.state_1;

		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		button2.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateB, button2)));

	}

	void Fnc_21 ()
	{
		//this last one is different - main image is determined by win flags
		button0Anim.SetInteger ("setPosition", posHolder);

		if (winFlag[0] == 0 & winFlag[1] == 3  & winFlag[2] == 6) {
			button0.GetComponent<Image> ().sprite = allTheImages [22];
		} else {
			button0.GetComponent<Image> ().sprite = allTheImages [23];
		}

		button0Anim.Play ("Finish");  


		//maybe set these buttons to links to web site or something???
		button1Anim.Play ("IntroducedLeft");  
		button1.GetComponent<Image> ().sprite = null;

		button2Anim.Play ("IntroducedCenter");  
		button2.GetComponent<Image> ().sprite = null;

		button3Anim.Play ("IntroducedRight");  
		button3.GetComponent<Image> ().sprite = null;


		// only place where the main image is a button - restarts game
		myStateA = States.state_0;
		button0.onClick.AddListener (() => StartCoroutine(AnimCoRoutine(myStateA, button0)));
	}

	public void CloseGame ()
	{
		Application.Quit ();
	}
}
