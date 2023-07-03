using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
namespace SpaceShooter
{ 
public class LevelSequenceController : MonoSingleton<LevelSequenceController>
{
        public static string MainMenuSceneNickName = "main_menu";

        public Episode CurrentEpisode { get; private set; }

        public int CurrentLevel { get; private set; }

        public static SpaceShip PlayerShip { get; set; }

        public bool LastLevelResult { get; private set; }

        public PlayerStatistics LevelStatistics { get; private set; }

        private int m_PlayerTime;

        public void StartEpisode (Episode e)
        {
            CurrentEpisode = e;
            CurrentLevel = 0;

            LevelStatistics = new PlayerStatistics();
            LevelStatistics.Reset();

            SceneManager.LoadScene(e.Levels[CurrentLevel]);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
        }

    public void FinishCurrentLevel(bool succes)
        {
            LastLevelResult = succes;
            CalculateLevelStatistic(LastLevelResult);

            ResultPanelController.Instance.ShowResults(LevelStatistics, succes);
        }

        public void AdvanceLevel()
        {
            LevelStatistics.Reset();
            
            CurrentLevel++;

            if(CurrentEpisode.Levels.Length<=CurrentLevel)
            {
                SceneManager.LoadScene(MainMenuSceneNickName);
            }
            else
            {
                SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
            }
        }

        private void CalculateLevelStatistic(bool succes)
        {
            LevelStatistics.score = Player.Instance.Score;
            LevelStatistics.numKills = Player.Instance.NumKills;
            LevelStatistics.time = (int)LevelController.Instance.LevelTime;

            if (succes)
            {
                LevelStatistics.bonusScore = (LevelController.Instance.ReferenceTime - LevelStatistics.time) * LevelController.Instance.TimeBonus;
            }
            else LevelStatistics.bonusScore = 0;
                
                LevelStatistics.finalScore = LevelStatistics.score + LevelStatistics.bonusScore;

            m_PlayerTime = PlayerPrefs.GetInt("PlayerTime", 0);
            m_PlayerTime = m_PlayerTime + LevelStatistics.time;

            int m_PlayerScore = PlayerPrefs.GetInt("PlayerScore", 0);
            m_PlayerScore = m_PlayerScore + LevelStatistics.finalScore;
            PlayerPrefs.SetInt("PlayerScore", m_PlayerScore);

            int m_PlayerKills = PlayerPrefs.GetInt("PlayerKills", 0);
            m_PlayerKills= m_PlayerKills+ LevelStatistics.numKills;
            PlayerPrefs.SetInt("PlayerKills", m_PlayerKills);
            

            PlayerPrefs.SetInt("PlayerTime", m_PlayerTime);
           
            
        }
}
}
