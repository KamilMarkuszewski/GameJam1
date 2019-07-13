using Assets.Scripts.GameModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour {

    public Text waterValue;
    public ModelSo gameModel;
    Color baseColor = new Color(178f / 255f, 160f / 255f, 105f / 255f, 255f / 255f);
    Color redColor = new Color(255f / 255f, 50f / 255f, 50f / 255f, 255f / 255f);

    private void Start() {
        waterValue.color = baseColor;
    }

    // Update is called once per frame
    void Update () {
        int percent = gameModel.waterLevel;
        waterValue.text = percent + "%";

        if (percent > 10) {
            waterValue.color = baseColor;
        } else {
            waterValue.color = redColor;
        }
        
	}
}

