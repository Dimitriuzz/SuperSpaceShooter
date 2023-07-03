using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceShooter
{ 
public class LevelConditionTarget : MonoBehaviour, ILevelCondition
{
        [SerializeField] private TargetObject m_Target;
        [SerializeField] GameObject m_ObjectivePrefab;
        [SerializeField] GameObject m_ObjectivePointer;


        private bool m_Reached;
        private bool m_AlreadyReached=false;

        bool ILevelCondition.IsCompleted
        {
            get
            {
                if(Player.Instance!=null&&Player.Instance.ActiveShip!=null)
                {
                    if(m_Target.reached)
                    {
                        m_Reached = true;
                        if (!m_AlreadyReached)
                        {
                            var obj=Instantiate(m_ObjectivePrefab,m_Target.transform);
                            Destroy(obj, 3);
                            m_ObjectivePointer.SetActive(false);
                        }
                        m_AlreadyReached = true;

                    }
                }
                return m_Reached;
            }
            
        }
    
}
}
