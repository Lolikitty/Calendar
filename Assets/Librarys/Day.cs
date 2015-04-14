using UnityEngine;
using System.Collections;

public class Day : MonoBehaviour {

	public int year;
	public int month;
	public UILabel day;
	public GameObject dayButton;

	static string TEMP = "";
	string temp = "";

	void Awake () {
		UIEventListener.Get (dayButton).onClick = DayButton;
	}

	void DayButton (GameObject obj) {
		Calendar.CHOOSE_YEAR = year;
		Calendar.CHOOSE_MONTH = month;
		Calendar.CHOOSE_DAY = int.Parse(day.text);

		UIButton b = dayButton.GetComponent<UIButton> ();
		b.defaultColor = Calendar.CHOOSE_DAY_COLOR;

		temp = month + "" + day.text;
		TEMP = temp;
	}

	void Update(){
		if(TEMP != temp){
			UIButton b = dayButton.GetComponent<UIButton> ();			
			b.defaultColor = Calendar.NOT_CHOOSE_DAY_COLOR;
		}
	}
}
