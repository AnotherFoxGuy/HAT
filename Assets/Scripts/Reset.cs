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

public class Reset : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            Destroy(otherObj.gameObject);
        }
    }
}