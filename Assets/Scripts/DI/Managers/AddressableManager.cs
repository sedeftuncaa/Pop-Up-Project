using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Zenject;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DI.Managers
{
    public class AddressableManager: IInitializable, IDisposable,ITickable
    {
        private List<AsyncOperationHandle> _handles = new List<AsyncOperationHandle>();

        
        public void Initialize()
        {
            Addressables.InitializeAsync().Completed += OnInitializeComplete;
        }
        
        public async UniTask<Sprite> LoadSpriteByKey(string key)
        {
            Sprite result = null;
            try
            {
                var spriteHandle = Addressables.LoadAssetsAsync<Sprite>(key, null);
                await spriteHandle.Task;
                if (spriteHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    result = spriteHandle.Result.First();
                }
                else if (spriteHandle.Status == AsyncOperationStatus.Failed)
                {
                    Debug.Log($"<color=red>Sprite with key {key} failed to load!</color>");
                }
            }
            catch (Exception e)
            {
                Debug.Log($"Load Sprite by Key Error {e.Message}");
            }

            return result;
        }

        public async UniTask<GameObject> LoadGameObjectByKey(string key)
        {
            GameObject result = null;

            try
            {
                var handle = Addressables.LoadAssetsAsync<GameObject>(key, null);
                _handles.Add(handle);
                await handle.Task;
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    result = handle.Result.First();
                }
            }
            catch (Exception e)
            {
                Debug.Log($"Load GameObject by Key Error {e.Message}");
            }

            return result;
        }

        private void OnInitializeComplete(AsyncOperationHandle<IResourceLocator> obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("AddressableManager initialized successfully");
            }
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }
    }
}