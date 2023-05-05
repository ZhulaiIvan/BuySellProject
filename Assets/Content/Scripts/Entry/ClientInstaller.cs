using Content.Scripts.Character;
using Content.Scripts.Inventory;
using Zenject;

namespace Content.Scripts.Entry
{
    public class ClientInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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