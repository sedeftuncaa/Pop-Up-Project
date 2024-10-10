using System;
using Enums;
using PopUpBase;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
    public class LevelCompletedPopUp: PopUpBase<LevelInfoData>
    {
        //[SerializeField] private Button _closeButton;
        
        
        public LevelCompletedPopUp() : base(PopUpTypes.LevelCompletedPopUp)
        {
        }


        private void OnEnable()
        {
            ShowPopUp();
           // _closeButton.onClick.AddListener(async ()=>await HandleButtonClickAsync(_closeButton,OnCloseButtonClick));
        }

        private void OnCloseButtonClick()
        {
            //it can be customized
        }


        public override void ShowPopUp()
        {
            var data = base.GetData();
            Debug.Log($"Showing LeveComplete PopUp!");
            if (data!=null)
            {
                Debug.Log($"LevelCompleted PopUp is Active, Score DATA IS:{data.Score}");
            }
            else
            {
                Debug.LogWarning($"LevelCompleted PopUp is Active and DATA IS NULL!");
            }
        }
        
        
       
    }
    
   
    
    
}