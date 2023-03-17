using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace BattleShip
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject panelMultiplayerChoose;
        public Action _onReset;
        private void Start()
        {
            ClosePanelMultiplayer();
        }

        public void StartSingleGame()
        {
            SceneManager.LoadScene("OrderShip");
        }

        #region MultiPlayerSelection

        public void OpenPanelMultiplayer()
        {
            panelMultiplayerChoose.SetActive(true);
        }

        public void ClosePanelMultiplayer()
        {
            panelMultiplayerChoose.SetActive(false);
        }

        public void MultiPlayerStart()
        {

        }

        #endregion

        public void ResetShip()
        {
            _onReset.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void Restart()
        {
            SceneManager.LoadScene("MainMenu");
        }


        public void ReturnMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
