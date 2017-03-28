using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIndicator : MonoBehaviour {
    private Transform _playerPos;
    private Rigidbody2D _playerRB;
    public GameObject _indicatorArrow;
    private Transform _indicatorArrowOriginalRotation;
    private float _tempGravityScale;

    private bool _facingUp = true;


	// Use this for initialization
	void Start () {
        _playerPos = gameObject.transform;
        _playerRB = gameObject.GetComponent<Rigidbody2D>();
       

	}
	
	// Update is called once per frame
	void Update () {


		
        if(_playerRB.gravityScale <0)
        {
            if(_facingUp == true)
            {
                _indicatorArrow.transform.RotateAround(_playerPos.position, Vector3.forward, 180.0f);
                _facingUp = false;
            }
           
        }
        else if (_playerRB.gravityScale > 0)
        {
            if (_facingUp == false)
            {
                _indicatorArrow.transform.RotateAround(_playerPos.position, Vector3.forward, 180.0f);
                _facingUp = true;
            }

        }




    }
}
