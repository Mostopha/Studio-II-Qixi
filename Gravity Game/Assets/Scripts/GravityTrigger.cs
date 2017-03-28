using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : MonoBehaviour {

    public Rigidbody2D minRanage;
    public float minDistance = 1;
    public float range = 10; //how close the objects need to be to each other to gravity shift;

    private Transform player1;
    private Transform player2;
    private float distance;
    private float noDistance = 0;
    private CircleCollider2D minRanageCollider;
    private Light glow1;
    private Light glow2;

    public static bool inShiftRange = false;

    public static Vector3 middlePoint;

    private string _tag;

    private void Awake() {
        player1 = GameObject.Find("Player1").transform;
        player2 = GameObject.Find("Player2").transform;

        glow1 = player1.FindChild("Point light").GetComponent<Light>();
        glow2 = player2.FindChild("Point light").GetComponent<Light>();

        minRanageCollider = minRanage.gameObject.GetComponent<CircleCollider2D>();
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        distance = Vector3.Distance(player1.position, player2.position);
        middlePoint = (player1.position + player2.position) / 2;
        inRange();

        if(GameData.isPlayer1ReadytoHover == true && GameData.isPlayer2ReadytoHover == true) {
            minRanageCollider.radius = Mathf.MoveTowards(minRanageCollider.radius, minDistance, 5 * Time.deltaTime);
        } else {
            minRanageCollider.radius = Mathf.MoveTowards(minRanageCollider.radius, noDistance, 5 * Time.deltaTime);
        }
	}

    private void FixedUpdate() {
        if (minRanage != null) {
            minRanage.velocity = (middlePoint - minRanage.transform.position) * 10;
        }
    }

    void inRange()
    {
        if (distance <= range)
        {
            glow1.enabled = true;
            glow2.enabled = true;
            inShiftRange = true;
        }
        else
        {
            glow1.enabled = false;
            glow2.enabled = false;
            inShiftRange = false;
        }

    }
}
