using Assets.Scripts.GameModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DehydrationController : MonoBehaviour {

    public ModelSo gameModel;
    
	void Start () {
        gameModel.waterLevel = 100;
        InvokeRepeating("IncreaseDehydration", 1.0f, 0.1f);  //3f);
    }

    void IncreaseDehydration() {
        gameModel.waterLevel -= 1;
    }
}
