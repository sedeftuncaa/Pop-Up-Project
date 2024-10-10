using DI.Managers;
using Enums;
using MessagePipe;
using Zenject;

namespace DI.Installer
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Bindings go here

            var options = this.Container.BindMessagePipe();
            this.Container.BindMessageBroker<int>(options);
            
            Container.Bind<AddressableManager>().AsSingle();
            
            
            this.Container.BindMessageBroker<GameStates>(options);
            
            this.Container.BindMessageBroker<PopUpTypes,object>(options);
        
        }
    }
}