using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    //public GameObject leftDoor;
    //public Material colorChange;

    public Animator elevatorAnim;
    public Renderer door;
    public Animator doorAnim;

    private string objectName;
    private Animator buttonAnim;

    private void Awake() {
        objectName = this.gameObject.name;
        buttonAnim = this.gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {

	}

    private void Update() {
        if(GameData.greenDoorisActivate == true && GameData.redDoorisActivate == true) {
            if(doorAnim != null) {
                doorAnim.SetBool("isOpen", true);
            }

            GameData.isWin = true;
        }

        if(GameData.bottomElevatorisActivate == true && GameData.topElevatorisActivate == true) {
            if(elevatorAnim != null) {
                elevatorAnim.SetBool("isActivated", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D _col) {

        //leftDoor.GetComponent<MeshRenderer> ().material = colorChange;

        if ((objectName == "GreenBtn_Elevator" && _col.gameObject.tag == "Player1") || (objectName == "RedBtn_Elevator" && _col.gameObject.tag == "Player2")) {
            ActivateElevator();
        }

        if ((objectName == "GreenBtn_Door" && _col.gameObject.tag == "Player1") || (objectName == "RedBtn_Door" && _col.gameObject.tag == "Player2")) {
            ActivateDoor();
        }
    }

    private void ActivateElevator() {
        buttonAnim.SetBool("isPressed", true);
        if(objectName == "GreenBtn_Elevator") {
            GameData.bottomElevatorisActivate = true;
        }else if (objectName == "RedBtn_Elevator") {
            GameData.topElevatorisActivate = true;
        }
    }

    private void ActivateDoor() {
        //Do something for the door here!
        Debug.Log("Door Activated!");
        buttonAnim.SetBool("isPressed", true);

        if(objectName == "GreenBtn_Door") {
            door.material.color = Color.green;
            GameData.greenDoorisActivate = true;
        }else if (objectName == "RedBtn_Door") {
            door.material.color = Color.red;
            GameData.redDoorisActivate = true;
        }
    }
}