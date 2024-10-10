using System.Collections.Generic;
using DI.Managers;
using Structs;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace DI.Installer
{
    public class SceneInstaller : MonoInstaller
    {

        [SerializeField] private List<PopUpElementsStruct> _popUpElementsStructs;
        [SerializeField] private UIPack _UIPack;

        public override void InstallBindings()
        {
            Container.BindInstance(_popUpElementsStructs);
            Container.BindInstance(_UIPack);
            
            
            Container.BindInterfacesAndSelfTo<AudioManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<PopUpManager>().AsSingle();


            //Container.Bind<Utilities>().AsSingle();
        }
    }
}