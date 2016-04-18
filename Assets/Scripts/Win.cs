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

public class Win : MonoBehaviour
{
    private GameObject[] _coinsInLevelTotal;

    private GameObject _player;
    private Rigidbody _playerRigidbody;
    private float _timer = Mathf.Infinity;
    private bool _win;


    private void Start()
    {
        _player = GameObject.Find("Player");
        _playerRigidbody = _player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Time.time > _timer)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (_win)
        {
            _playerRigidbody.isKinematic = true;
            _player.transform.position = new Vector3(_player.transform.position.x,
                _player.transform.position.y + Time.deltaTime, _player.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            _coinsInLevelTotal = GameObject.FindGameObjectsWithTag("Coin");
            print("coins left = " + _coinsInLevelTotal.Length);
            _win = true;
            _timer = Time.time + 2;
        }
    }

    private void OnGUI()
    {
        if (_win)
        {
            GUI.Box(new Rect(Screen.width/2 - 75, Screen.height/5 - 25, 150, 50),
                "Win !!\n coins left = " + _coinsInLevelTotal.Length);
        }
    }
}