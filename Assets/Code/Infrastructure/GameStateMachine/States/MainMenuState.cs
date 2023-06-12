using EnotoButerbrodo.StateMachine;

namespace Code.Infrastructure
{
    public class MainMenuState : IState
    {
        private GameStateMachine _context;

        public MainMenuState(GameStateMachine context)
        {
            _context = context;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}