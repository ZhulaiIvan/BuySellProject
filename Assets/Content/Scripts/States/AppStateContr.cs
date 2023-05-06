using System.Collections.Generic;
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
        private Queue<AppStates> _statesQueue = new ();

        public ObservableByte State => _state;

        public AppStateContr()
        {
            _state = new ObservableByte(0);
            _statesQueue.Enqueue((AppStates)_state.Value);
        }

        public void ChangeState(AppStates state)
        {
            if(!_statesQueue.Contains((AppStates)_state.Value))
                _statesQueue.Enqueue((AppStates)_state.Value);
            
            _state.Value = (byte)state;
        }

        public void ReturnBack()
        {
            if(_statesQueue.Count == 0) return;
            
            _state.Value = (byte)_statesQueue.Dequeue();
        }
    }
}  