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

public class TurnScript : MonoBehaviour
{
    private RaycastHit _hitPointBack;
    private RaycastHit _hitPointFront;
    private GameObject _level;
    private GameObject _player;
    private Rigidbody _playerRigidbody;
    private bool _rotateworld;
    private float _rotspeed;
    private GameObject _skybox;
    private bool _stopRotateWorld;
    private float _worldrotate;
    public float rotatespeed = 1.5f;


    private void Start()
    {
        _player = GameObject.Find("Player");
        _playerRigidbody = _player.GetComponent<Rigidbody>();
        _skybox = GameObject.Find("skybox");
        _level = GameObject.Find("level");
        _skybox.transform.position = new Vector3(_skybox.transform.position.x, _skybox.transform.position.y,
            _level.transform.position.z);
    }

    private void Update()
    {
        var posTmpFront = new Vector3(_player.transform.position.x + _playerRigidbody.velocity.x/4,
            _player.transform.position.y - 2, _player.transform.position.z - 100);
        var posTmpBack = new Vector3(_player.transform.position.x + _playerRigidbody.velocity.x/4,
            _player.transform.position.y - 2, _player.transform.position.z + 100);
        //Debug.DrawLine(player.transform.position, PosTMPFront);
        if (Physics.Raycast(posTmpFront, Vector3.forward, out _hitPointFront, 300f) && !_rotateworld)
        {
            Debug.DrawLine(_player.transform.position, _hitPointFront.point);
            if (_hitPointFront.point.z > _player.transform.position.z)
            {
                //print("HitPointFront");
                _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y,
                    _hitPointFront.point.z + 0.2f);
            }
        }
        if (Physics.Raycast(posTmpBack, Vector3.back, out _hitPointBack, 300f) && !_rotateworld)
        {
            Debug.DrawLine(_player.transform.position, _hitPointBack.point);
            if (_hitPointBack.point.z < _player.transform.position.z)
            {
                //print("HitPointBack");
                _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y,
                    _hitPointBack.point.z - 0.2f);
            }
        }
        if (Input.GetButtonDown("TurnLeft") && !_rotateworld)
        {
            _rotateworld = true;
            _worldrotate = Mathf.Repeat(_worldrotate + 90, 360);
            _rotspeed = rotatespeed;
        }
        if (Input.GetButtonDown("TurnRight") && !_rotateworld)
        {
            _rotateworld = true;
            _worldrotate = Mathf.Repeat(_worldrotate - 90, 360);
            _rotspeed = -rotatespeed;
        }
        if (_rotateworld)
        {
            Time.timeScale = 0;
            Debug.DrawLine(Vector3.zero, _player.transform.position);
            transform.RotateAround(_player.transform.position, Vector3.up, _rotspeed);
            _skybox.transform.position = new Vector3(_skybox.transform.position.x, _skybox.transform.position.y,
                _level.transform.position.z);
        }
        if (transform.eulerAngles.y > _worldrotate - 0.1 && transform.eulerAngles.y < _worldrotate + 0.1)
        {
            if (_stopRotateWorld)
            {
                _rotateworld = false;
                _stopRotateWorld = false;
                transform.eulerAngles = new Vector3(Mathf.Round(transform.eulerAngles.x),
                    Mathf.Round(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));
                Time.timeScale = 1;
            }
        }
        if (transform.eulerAngles.y < _worldrotate - 2 || transform.eulerAngles.y > _worldrotate + 2)
        {
            _stopRotateWorld = true;
        }
    }
}