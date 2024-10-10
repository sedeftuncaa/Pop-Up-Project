using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Structs;
using UnityEngine;
using Zenject;

namespace DI.Managers
{
    public class PopUpManager : IInitializable, IDisposable
    {

        private Dictionary<PopUpElementsStruct, GameObject> _popUpListDictionary;
        private List<GameObject> _popUpList = new List<GameObject>();
        
        #region Zenject


        private UIPack _uiPack;
        private DiContainer _diContainer;

        [Inject]
        public void Construct(List<PopUpElementsStruct> popUps,
            UIPack uiPack,
            DiContainer diContainer)
        {
            _uiPack = uiPack;
            _diContainer = diContainer;

            _popUpListDictionary = popUps.ToDictionary(popUp => popUp, popUp => popUp.PopUpGameObject);
        }

        #endregion
       


        public void Initialize()
        {
            CreatePopUp();
        }

        private void CreatePopUp()
        {
            foreach (var go in _popUpListDictionary)
            {
                GameObject prefabPopUp = _diContainer.InstantiatePrefab(go.Value, _uiPack.PopUpCanvas.transform);
                prefabPopUp.name = go.Key.PopUpTypes.ToString();
                prefabPopUp.SetActive(false);
                _popUpList.Add(prefabPopUp);
            }
        }

        public void SetPopUpActive(PopUpTypes popUp, bool isActive)
        {
            var filteredList = _popUpList.Where(go => go.name == popUp.ToString());
            foreach (var go in filteredList)
            {
                go.SetActive(isActive);
            }
        }
        
        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}