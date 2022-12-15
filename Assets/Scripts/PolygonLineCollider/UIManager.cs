using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public Text vechicleSpeed;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
}
