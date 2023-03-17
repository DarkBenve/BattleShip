﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace BattleShip
{
    public class DontDestroyObject : MonoBehaviour
    {
        [HideInInspector]
        public string objectId;

        private MainMenu _mainMenu;

        private void Awake()
        {
            objectId = name + transform.position.ToString() + transform.eulerAngles.ToString();
        }

        private void Start()
        {
            for (int i = 0; i < FindObjectsOfType<DontDestroyObject>().Length; i++) {
                if (FindObjectsOfType<DontDestroyObject>()[i] != this) {
                    if (FindObjectsOfType<DontDestroyObject>()[i].objectId == objectId) {
                        Destroy(gameObject);
                    }
                }
            }
            DontDestroyOnLoad(gameObject);
            _mainMenu = FindObjectOfType<MainMenu>();
            _mainMenu._onReset += DestroyObject;
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene().buildIndex < 1) {
                DestroyImmediate(gameObject);
            }
        }

        private void DestroyObject()
        {
            DestroyImmediate(gameObject);
        }
    }
}
