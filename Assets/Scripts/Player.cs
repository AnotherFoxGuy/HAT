// This file is part of HAT
// 
// Copyright (c) 2016 sietze greydanus
// 
// HAT is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License version 3, as
// published by the Free Software Foundation.
// 
// HAT is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with HAT. If not, see <http://www.gnu.org/licenses/>.
// 

using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private int _coinsFound;
    private GameObject _playerMesh;
    private Rigidbody _playerMeshRigidbody;
    private GameObject _skybox;
    public float MaxSpeed = 7;


    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerMeshRigidbody = GetComponent<Rigidbody>();
        _playerMesh = GameObject.Find("PlayerMesh");
        _playerMesh.transform.eulerAngles = new Vector3(0, 90, 0);
        var coinsInLevelTotal = GameObject.FindGameObjectsWithTag("Coin");
        print("coinsInLevelTotal = " + coinsInLevelTotal.Length);
        _skybox = GameObject.Find("skybox");
    }

    private void Update()
    {
        _skybox.transform.position = new Vector3(transform.position.x, transform.position.y,
            _skybox.transform.position.z);
        if (Input.GetButtonDown("Jump"))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1.5f))
                _playerMeshRigidbody.AddForce(transform.TransformDirection(Vector3.up*400));
        }
        if (Physics.Raycast(transform.position, Vector3.down, 1.25f))
        {
            if (Input.GetButton("Right") || Input.GetButton("Left"))
                _animator.SetInteger("State", 1);
            else
                _animator.SetInteger("State", 0);
        }

        else
        {
            _animator.SetInteger("State", 2);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Right"))
        {
            _playerMesh.transform.eulerAngles = new Vector3(0, 90, 0);
            if (_playerMeshRigidbody.velocity.x < MaxSpeed)
                _playerMeshRigidbody.AddForce(transform.TransformDirection(Vector3.right*20));
        }
        if (Input.GetButton("Left"))
        {
            _playerMesh.transform.eulerAngles = new Vector3(0, 270, 0);
            if (_playerMeshRigidbody.velocity.x > -MaxSpeed)
                _playerMeshRigidbody.AddForce(transform.TransformDirection(Vector3.left*20));
        }
    }

    private void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.tag == "Coin")
        {
            Destroy(otherObj.gameObject);
            _coinsFound++;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 50, 150, 25), "Coins collected: " + _coinsFound);
    }
}