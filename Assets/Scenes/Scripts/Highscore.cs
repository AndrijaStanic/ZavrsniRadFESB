using UnityEngine;
using UnityEngine.UI;

namespace ZavrsniRadFESB.Assets.Scenes.Scripts
{
    public class Highscore : MonoBehaviour
    {
        public Text HighscoreText;
        public Text ScoreText;

        Player player;
        PlayerHealthBar playerHealthBar;
        private float highscore;
        private float score;

        private void Start() {
            player = FindObjectOfType<Player>();
            playerHealthBar = GetComponent<PlayerHealthBar>();
            HighscoreText.text = PlayerPrefs.GetFloat("Highscore", 0).ToString();
            
        }
        private void Update() {
            ScoreText.text = "" + player.currentHealthPoints;
            score = player.currentHealthPoints;
        }
        public void Setter() {
            SetHighscore();
        }

        public void SetHighscore()
        {
            
            if (score > PlayerPrefs.GetFloat("Highscore", 0))
            {
                PlayerPrefs.SetFloat("Highscore", score);
                HighscoreText.text = score.ToString();
            }
            
        }

        public  void Reset() {
            PlayerPrefs.DeleteKey("Highscore");
            HighscoreText.text = "0";
        }
    }
}