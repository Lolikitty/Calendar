using UnityEngine;
using System.Collections;
using System;

public class Calendar : MonoBehaviour {

	public int minYear = 1970, maxYear = 2100;

	public Color chooseMonthColor;
	public Color notChooseMonthColor;
	public Color chooseDayColor;
	public Color notChooseDayColor;

	public UILabel year, month;
	public GameObject L_button, R_button;
	public Day [] day;

	public static int CHOOSE_YEAR, CHOOSE_MONTH, CHOOSE_DAY;
	public static Color CHOOSE_DAY_COLOR, NOT_CHOOSE_DAY_COLOR;

	void Awake () {
		Init ();
		UpdateDay ();
	}

	void Init(){
		CHOOSE_YEAR = DateTime.Now.Year;
		CHOOSE_MONTH = DateTime.Now.Month;

		year.text = CHOOSE_YEAR.ToString();
		month.text = CHOOSE_MONTH.ToString();

		CHOOSE_DAY_COLOR = chooseDayColor;
		NOT_CHOOSE_DAY_COLOR = notChooseDayColor;
				
		UIEventListener.Get (L_button).onClick = L_Button;
		UIEventListener.Get (R_button).onClick = R_Button;
	}

	void UpdateDay(){

		DateTime monthFirstDay = new DateTime (CHOOSE_YEAR, CHOOSE_MONTH, 1);

		int monthFirstDayOfWeek =(int) monthFirstDay.DayOfWeek;

		for(int i = 0; i < 7; i++){
			if(monthFirstDayOfWeek == i){
				day[i].day.text = "1";
				for(int k = 0; k < day.Length; k++){
					DateTime df = monthFirstDay.AddDays(k-i);
					day[k].day.text = df.Day.ToString();
					day[k].day.color = (df.Month == CHOOSE_MONTH) ? chooseMonthColor : notChooseMonthColor;
					day[k].year = df.Year;
					day[k].month = df.Month;
				}
				break;
			}
		}
	}

	void L_Button(GameObject obj) {
		CHOOSE_YEAR = int.Parse (year.text);
		CHOOSE_MONTH = int.Parse (month.text) - 1;

		if(CHOOSE_MONTH <= 0){
			CHOOSE_MONTH = 12;
			CHOOSE_YEAR--;
		}
		if(CHOOSE_YEAR > minYear){
			month.text = CHOOSE_MONTH.ToString();
			year.text = CHOOSE_YEAR.ToString();
			UpdateDay ();
		}
	}

	void R_Button(GameObject obj) {
		CHOOSE_YEAR = int.Parse (year.text);
		CHOOSE_MONTH = int.Parse (month.text) + 1;
		
		if(CHOOSE_MONTH > 12){
			CHOOSE_MONTH = 1;
			CHOOSE_YEAR++;
		}
		if(CHOOSE_YEAR < maxYear){
			month.text = CHOOSE_MONTH.ToString();
			year.text = CHOOSE_YEAR.ToString();
			UpdateDay ();
		}
	}
}
