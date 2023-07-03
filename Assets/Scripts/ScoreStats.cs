
using UnityEngine;
using UnityEngine.UI;
namespace SpaceShooter
{ 
public class ScoreStats : MonoBehaviour
{
        [SerializeField] private Text m_ScoreText;
        [SerializeField] private Text m_LifeText;
        [SerializeField] private Text m_HitPontsText;
        [SerializeField] private Text m_LevelText;
        [SerializeField] private Text m_TimerText;

        [SerializeField] private Image m_ShipImage;
        private Sprite m_ShipSprite;

        private int m_LastScore=0;
        private int m_LastTimer=0;
        private int m_LastLife=0;
        private int m_LastHitPoints=0;
        private int m_LastLevel=100;
        private int m_NumLevels;


        // Update is called once per frame
        private void Start()
        {
            m_ShipSprite = Player.Instance.ActiveShip.PreviewImage;
            m_ShipImage.GetComponent<Image>().sprite = m_ShipSprite;
            m_NumLevels = LevelSequenceController.Instance.CurrentEpisode.Levels.Length;
            Debug.Log("num levels" + m_NumLevels);

        }

        void Update()
    {
            UpdateScore();
    }
        private void UpdateScore()
        {
            if(Player.Instance!=null)
            {
                int currentScore = Player.Instance.Score;
                int currentHitPoints = Player.Instance.ActiveShip.HitPoints;
                int currentLevel = LevelSequenceController.Instance.CurrentLevel;
                int currentLifes = Player.Instance.NumLives;
                int currentTimer = (int)LevelController.Instance.LevelTime;

                Debug.Log("cur levels" + currentLevel);


                if (m_LastScore!=currentScore)
                {
                    m_LastScore = currentScore;
                    m_ScoreText.text = "Score :" + m_LastScore.ToString();
                }

                if (m_LastLife != currentLifes)
                {
                    m_LastLife = currentLifes;
                    m_LifeText.text = m_LastLife.ToString();
                }

                if (m_LastHitPoints != currentHitPoints)
                {
                    m_LastHitPoints = currentHitPoints;
                    m_HitPontsText.text = m_LastHitPoints.ToString();
                }

                if (m_LastTimer != currentTimer)
                {
                    m_LastTimer = currentTimer;
                    m_TimerText.text = "Time: " + m_LastTimer.ToString();
                }

                if (m_LastLevel != currentLevel)
                {
                    m_LastLevel = currentLevel;
                    m_LevelText.text = "Level "+(m_LastLevel+1).ToString()+"/"+m_NumLevels.ToString();
                }
            }



        }
}
}
