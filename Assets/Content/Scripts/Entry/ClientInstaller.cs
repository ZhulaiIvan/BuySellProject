using Content.Scripts.Character;
using Content.Scripts.Inventory;
using Content.Scripts.States;
using Content.Scripts.Trigger;
using Zenject;

namespace Content.Scripts.Entry
{
    public class ClientInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<AppStateContr>()
                .FromInstance(new AppStateContr());
            
            BindModels();
        }

        private void BindModels()
        {
            Container
                .Bind<CharacterModel>()
                .FromInstance(new CharacterModel(new PlayerInventory()))
                .AsSingle();
        }
    }
}