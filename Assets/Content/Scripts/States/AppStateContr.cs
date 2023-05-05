using Content.Scripts.Data;

namespace Content.Scripts.States
{
    public enum AppStates
    {
        Play,
        Market
    }
    public class AppStateContr
    {
        private ObservableByte _state;

        public ObservableByte State => _state;

        public AppStateContr()
        {
            _state = new ObservableByte(0);
        }

        public void ChangeState(AppStates state)
        {
            _state.Value = (byte)state;
        }
    }
}  