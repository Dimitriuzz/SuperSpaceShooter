using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SpaceShooter
{
    public class LevelObjectiveController : MonoSingleton<LevelObjectiveController>
    {
       
        [SerializeField] private Text m_Score;
        [SerializeField] private Text m_Time;
        [SerializeField] private Text m_Level;
              
        [SerializeField] private Text m_BonusScoreText;
        [SerializeField] private LevelConditionScore m_ScoreObjective;


        //LevelSequenceController m_LevelNumber;


        private void Start()
        {

            m_Level.text = "Level " + (LevelSequenceController.Instance.CurrentLevel+1).ToString();
            m_Score.text = m_ScoreObjective.Score.ToString();
            m_Time.text = LevelController.Instance.ReferenceTime.ToString();
            m_BonusScoreText.text = LevelController.Instance.TimeBonus.ToString();

            Debug.Log(m_ScoreObjective.Score + " " + LevelController.Instance.ReferenceTime + " " + LevelController.Instance.TimeBonus);
            Time.timeScale = 0;

        }

        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
           
        }
    }
}
