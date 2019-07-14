using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltimeterUI : MonoBehaviour
{
    public GameObject player;
    public Transform AltimeterContainer;

    private float MIN_POS_VALUE = 3.1f;
    private float MAX_POS_VALUE = 30f;

    private float MIN_EUL_VALUE = -140f;
    private float MAX_EUL_VALUE = 140f;

	// Update is called once per frame
	void Update () {

        float yValue = player.transform.position.y;
        float percent = (yValue - MIN_POS_VALUE) / (MAX_POS_VALUE - MIN_POS_VALUE);
        percent = 1 - percent;

        float eul = percent * (MAX_EUL_VALUE - MIN_EUL_VALUE) + MIN_EUL_VALUE;

        Vector3 rotation = AltimeterContainer.transform.localEulerAngles;
        AltimeterContainer.transform.localEulerAngles = new Vector3(rotation.x, rotation.y, eul);
    }
}
