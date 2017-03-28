using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    public static bool bottomElevatorisActivate = false;
    public static bool topElevatorisActivate = false;

    public static bool greenDoorisActivate = false;
    public static bool redDoorisActivate = false;

    public static bool isPlayer1ReadytoShift = false;
    public static bool isPlayer2ReadytoShift = false;

    public static bool isPlayer1ReadytoHover = false;
    public static bool isPlayer2ReadytoHover = false;

    public static float player1GravityScale = 1;
    public static float player2GravityScale = -1;


    public static bool isWin = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
