using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestGame
{
    public class GameManager : Singleton<GameManager>
    {
        public bool paused;
        public PlayerMovement player;
        public GameObject gameOverButton;

        private void Start()
        {
            if(paused)
                PauseGame();
        }

        public void PauseGame()
        {
            Time.timeScale = 0.0f;
            paused = true;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1.0f;
            paused = false;
        }

        public Vector3 GetPlayerPosition()
        {
            return player.transform.position;
        }

        public void MovePlayer()
        {
            player.Move();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoseGame()
        {
            gameOverButton.SetActive(true);
            PauseGame();
        }
    }
}