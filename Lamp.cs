namespace ex2
{
    public class Lamp
    {
        private bool State;

        public void TurnOn(){
            State = true;
        }
        public void TurnOff(){
            State = false;
        }
        public bool CheckState(){
            return State;
        }
    }
}