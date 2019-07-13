using Assets.Scripts.GameModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour {

    public Text waterValue;
    public ModelSo gameModel;
	
	// Update is called once per frame
	void Update () {
        waterValue.text = gameModel.waterLevel + "%";
	}
}

