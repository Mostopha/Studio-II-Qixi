using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoveringController : MonoBehaviour {
    public float speed = 10;
    public float inAirSpeed;
    public float jump = 5;

    public static int jumpDirection;

    private Rigidbody2D _rig;
    private string _tag;

    private ParticleSystem _playerEffect;

    private string _gravityShiftKey;

    private string _directionPad;
    private string _jumpPad;
    private bool isGournd = false;

    private void Awake() {
        _rig = this.GetComponent<Rigidbody2D>();
        _tag = this.gameObject.tag;
        _playerEffect = transform.FindChild("PlayerEffect").GetComponent<ParticleSystem>();
    }

    // Use this for initialization
    void Start () {
        //Detect which player is and set control scheme
        if (_tag == "Player1") {
            _rig.gravityScale = 1;
            _directionPad = "Horizontal";
            _jumpPad = "Jump";
            _gravityShiftKey = "ShiftButton";
        } else if (_tag == "Player2") {
            _rig.gravityScale = -1;
            _directionPad = "GamePad_H";
            _jumpPad = "GamePad_Jump";
            _gravityShiftKey = "GamePad_Shift";
        }

        inAirSpeed = speed * 0.8f;
    }
	
	// Update is called once per frame
	void Update () {

        if (GravityTrigger.inShiftRange == true) {
            if (Input.GetButton(_gravityShiftKey)) {
                _playerEffect.gameObject.SetActive(true);

                if (_tag == "Player1") {
                    GameData.isPlayer1ReadytoHover = true;
                }else if (_tag == "Player2") {
                    GameData.isPlayer2ReadytoHover = true;
                }


                if (GameData.isPlayer1ReadytoHover == true && GameData.isPlayer2ReadytoHover == true) {
                    _rig.gravityScale = 0;
                    _rig.velocity = (GravityTrigger.middlePoint - this.transform.position) * 2;
                }
            } else if (Input.GetButtonUp(_gravityShiftKey)) {
                if (GameData.isPlayer1ReadytoHover == true && GameData.isPlayer2ReadytoHover == true) {
                    GameData.player1GravityScale *= -1;
                    GameData.player2GravityScale *= -1;
                }
                
                if (_tag == "Player1") {
                    _rig.gravityScale = GameData.player1GravityScale;
                    GameObject.Find("Player2").GetComponent<Rigidbody2D>().gravityScale = GameData.player2GravityScale;
                } else if (_tag == "Player2") {
                    _rig.gravityScale = GameData.player2GravityScale;
                    GameObject.Find("Player1").GetComponent<Rigidbody2D>().gravityScale = GameData.player1GravityScale;
                }
                NotReadyToShiftGravity();
            }
        } else {
            NotReadyToShiftGravity();
        }

        if (Input.GetButtonDown(_jumpPad) && isGournd == true) {
            _rig.AddForce(new Vector2(_rig.velocity.x, jump * _rig.gravityScale), ForceMode2D.Impulse);
        }

        Debug.Log("Player1 is ready = " + GameData.isPlayer1ReadytoHover + "; " + "Player2 is ready = " + GameData.isPlayer2ReadytoHover);
    }

    private void FixedUpdate() {
        if(isGournd == true) {
            _rig.velocity = new Vector2(Input.GetAxis(_directionPad) * speed, _rig.velocity.y);
        } else {
            _rig.velocity = new Vector2(Input.GetAxis(_directionPad) * inAirSpeed, _rig.velocity.y);
        }
    }

    //Check the player is on the ground or not;
    private void OnCollisionStay2D(Collision2D _col) {
        if (_col.gameObject.tag == "Untagged") {
            Debug.LogWarning("Ground Object is not tagged. Some script may not work!");
        }
        if(_col.gameObject.tag == "Ground") {
            isGournd = true;
        }
    }

    private void OnCollisionExit2D(Collision2D _col) {
        if (_col.gameObject.tag == "Untagged") {
            Debug.LogWarning("Ground Object is not tagged. Some script may not work!");
        }
        if (_col.gameObject.tag == "Ground") {
            isGournd = false;
        }
    }

    private void NotReadyToShiftGravity() {
        GameData.isPlayer1ReadytoHover = false;
        GameData.isPlayer2ReadytoHover = false;

        if (_tag == "Player1") {
            _rig.gravityScale = GameData.player1GravityScale;
            GameObject.Find("Player2").GetComponent<Rigidbody2D>().gravityScale = GameData.player2GravityScale;
        } else if (_tag == "Player2") {
            _rig.gravityScale = GameData.player2GravityScale;
            GameObject.Find("Player1").GetComponent<Rigidbody2D>().gravityScale = GameData.player1GravityScale;
        }

        _playerEffect.gameObject.SetActive(false);
    }
}
