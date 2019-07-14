using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassUI : MonoBehaviour {


    public GameObject player;
    public Transform CompassContainer;
    
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = player.transform.localEulerAngles;
        float yValue = direction.y;

        Vector3 rotation = CompassContainer.transform.localEulerAngles;
        CompassContainer.transform.localEulerAngles = new Vector3(rotation.x, rotation.y, yValue);
    }
}
