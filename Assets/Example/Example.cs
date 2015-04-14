using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {

	void Update () {
		GetComponent<UILabel>().text 
			= "選擇的日期是：" + Calendar.CHOOSE_YEAR + " 年 "
				+ Calendar.CHOOSE_MONTH + "月 "
				+ Calendar.CHOOSE_DAY + "日";
	}
}
