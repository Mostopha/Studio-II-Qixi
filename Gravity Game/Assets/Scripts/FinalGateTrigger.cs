using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGateTrigger : MonoBehaviour {

    private bool isPlayer1in = false;
    private bool isPlayer2in = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isPlayer1in == true && isPlayer2in == true) {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
	}

    private void OnTriggerEnter2D(Collider2D _col) {
        if (_col.gameObject.tag == "Player1") {
            isPlayer1in = true;
        } else if (_col.gameObject.tag == "Player2") {
            isPlayer2in = true;
        }
    }
}
