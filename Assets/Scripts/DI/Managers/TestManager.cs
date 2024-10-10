using Enums;
using MessagePipe;
using Popups;
using Sirenix.OdinInspector;
using Zenject;

namespace DI.Managers
{
    public class TestManager : SerializedMonoBehaviour
    {

        #region ZenjectSetup
        
        private PopUpManager _popUpManager;
        private IPublisher<PopUpTypes, object> _popUpPublisher;
        
        [Inject]
        public void Construct(PopUpManager popUpManager,
            IPublisher<PopUpTypes,object> popUpPublisher)
        {
            _popUpManager = popUpManager;
            _popUpPublisher = popUpPublisher;
        }
        
        #endregion
        
        
        
        [Button("OpenLevelCompletedPopup"), GUIColor(0f, 1f, 1)]
        [PropertySpace(SpaceBefore = 10)]
        private void OpenSuccess()
        {
            _popUpManager.SetPopUpActive(PopUpTypes.LevelCompletedPopUp,true);
        }
        
        
        [Button("Close Level Completed PopUp"), GUIColor(0f, 1f, 1)]
        [PropertySpace(SpaceBefore = 10)]
        private void Close()
        {
            _popUpManager.SetPopUpActive(PopUpTypes.LevelCompletedPopUp,false);
        }
        
        
        [Button("SendLevelCompletedInfo"), GUIColor(1f, 1.8f, 1.4f)]
        [PropertySpace(SpaceBefore = 10)]
        private void SendData()
        {
            _popUpPublisher.Publish(PopUpTypes.LevelCompletedPopUp, new LevelInfoData(1,3,5));
            _popUpManager.SetPopUpActive(PopUpTypes.LevelCompletedPopUp,true);
        }
        
        
        
    }
}