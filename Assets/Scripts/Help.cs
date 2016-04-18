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

using System;
using UnityEngine;

public class Help : MonoBehaviour
{
    private bool _hinden;

    public void Awake()
    {
        var o = PlayerPrefs.GetInt("HelpHasShown");
        if (o != DateTime.Now.Hour)
        {
            PlayerPrefs.SetInt("HelpHasShown", DateTime.Now.Hour);
            print(DateTime.Now.Hour);
        }
        else
        {
            _hinden = true;
            gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        if (Input.anyKeyDown && !_hinden)
        {
            _hinden = true;
            gameObject.SetActive(false);
        }
    }

    public void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}