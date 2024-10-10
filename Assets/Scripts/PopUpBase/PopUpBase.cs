using System;
using Cysharp.Threading.Tasks;
using DI.Managers;
using Enums;
using JetBrains.Annotations;
using MessagePipe;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PopUpBase
{
    public abstract class PopUpBase <TData>: MonoBehaviour where TData :class
    {
        private TData _data;
       
        private PopUpTypes PopUpType { get; set; }


        protected PopUpBase(PopUpTypes popUpType)
        {
            PopUpType = popUpType;
        }


        #region Zenject
        private AudioManager _audioManager;
        private IDisposable _disposable;
        
        [Inject]
        public void Construct(AudioManager audioManager,
            ISubscriber<PopUpTypes,object> popUpSubscriber)
        {
            _audioManager = audioManager;

            var bag = DisposableBag.CreateBuilder();
            popUpSubscriber.Subscribe(PopUpType, OnPopUpDataPublished).AddTo(bag); //TODO will mention??
            _disposable = bag.Build();
        }

        #endregion

        public abstract void ShowPopUp();

        private void OnPopUpDataPublished(object obj)
        {
            SetData(obj as TData);
        }
        
        
        protected async UniTask HandleButtonClickAsync(Button button,Action action)
        {
            button.interactable = false;
            PlayButtonClickSound();
            action?.Invoke(); 
            await UniTask.Delay(TimeSpan.FromSeconds(0.25f));
            button.interactable = true;
        }

        private void PlayButtonClickSound()
        {
            _audioManager.PlayButtonClickSound();
        }
        

        protected virtual void SetData([CanBeNull]TData data=default)
        {
            _data = data;
        }

        [CanBeNull]
        protected virtual TData GetData()
        {
            return _data;
        }
       

      
    }
}