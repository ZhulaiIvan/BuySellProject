using Content.Scripts.Character;
using Zenject;

namespace Content.Scripts.Entry
{
    public class ClientInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<CharacterData>()
                .AsSingle();
        }
    }
}