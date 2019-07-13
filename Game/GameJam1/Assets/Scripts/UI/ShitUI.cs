using Assets.Scripts.GameModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShitUI : MonoBehaviour {

    private int gutContent;
    public Text gutContentText;
    public ModelSo gameModel;
	
	// Update is called once per frame
	void Update () {
        gutContent = UpdateGutContent();

        int percent = (gutContent * 100) / 20;

        gutContentText.text = percent + "%";
	}

    private int UpdateGutContent()
    {
        return gameModel.gutContent;
    }
}
