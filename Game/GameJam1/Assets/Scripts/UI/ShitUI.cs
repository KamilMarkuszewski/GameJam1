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

    Color baseColor = new Color(178f / 255f, 160f / 255f, 105f / 255f, 255f / 255f);
    Color redColor = new Color(255f / 255f, 50f / 255f, 50f / 255f, 255f / 255f);

    // Update is called once per frame
    void Update () {
        gutContent = UpdateGutContent();

        int percent = (gutContent * 100) / 20;

        gutContentText.text = percent + "%";

        if (percent > 10)
        {
            gutContentText.color = baseColor;
        }
        else
        {
            gutContentText.color = redColor;
        }
    }

    private int UpdateGutContent()
    {
        return gameModel.gutContent;
    }
}
