using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SpaceShooter
{
    public class LevelObjective : MonoSingleton<LevelObjective>
    {
       
        [SerializeField] private Text m_Score;
        [SerializeField] private Text m_Time;
              
        [SerializeField] private Text m_BonusScoreText;

        private LevelConditionScore m_ScoreObjective;

        

        private void Start()
        {
            Time.timeScale = 0;

            m_Score.text = m_ScoreObjective.Score.ToString();
            m_Time.text = LevelController.Instance.ReferenceTime.ToString();
            m_BonusScoreText.text = LevelController.Instance.TimeBonus.ToString();
            

            
        }

        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
           
        }
    }
}
