using UnityEngine;
using UnityEngine.SceneManagement;

namespace BattleShip
{
    public class MainMenu : MonoBehaviour
    {
        public void StartSingleGame()
        {
            SceneManager.LoadScene("OrderShip");
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
