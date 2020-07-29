namespace ex2
{
    public class Cell
    {
        public bool IsSet;
        private string Position;
        public Lamp Lamp;

        public string Show(){
            if(!IsSet)
                return Position;
            if(Lamp.CheckState())
                return "O";
            return "i";
        }

        public Cell(int position){
            Position = (position + 1).ToString();
            IsSet = false;
            Lamp = new Lamp();
        }
        public void SetCell(int player){
            IsSet = true;
            if(player % 2 == 0)
                Lamp.TurnOn();
            else
                Lamp.TurnOff();
        }
    }
}