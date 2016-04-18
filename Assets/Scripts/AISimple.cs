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

public class AISimple : MonoBehaviour
{
    private float _moveTo = 1;
    private int _one = 1;
    public float MaxSpeed = 7;
    public float MoveSpeed = 0.01f;

    private void Start()
    {
        _moveTo = MoveSpeed;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) < MaxSpeed)
            GetComponent<Rigidbody>().AddForce(_moveTo, 0, 0);
        var PosTMP = new Vector3(transform.position.x + _one, transform.position.y, transform.position.z);
        Debug.DrawLine(transform.position, PosTMP);
        if (!Physics.Raycast(PosTMP, Vector3.down, 1f))
        {
            if (_moveTo > 0)
            {
                _moveTo = -MoveSpeed;
                _one = -1;
            }
            else
            {
                _moveTo = MoveSpeed;
                _one = 1;
            }
        }
    }
}