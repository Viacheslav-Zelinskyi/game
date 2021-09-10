namespace game
{
    class Winner
    {
        static public string whoWin(int move_user, int move_computer, int items_length){
                    if (move_user == items_length - 1 && move_computer == 0)
                    {
                       return "You Lose";
                    }
                    else if (move_user == 0 && move_computer == items_length - 1)
                    {
                        return "You Win";
                    }
                    else if (move_user == move_computer)
                    {
                        return "Draw";
                    }
                    else if (move_user > move_computer)
                    {
                        return "You Win";
                    }
                    else
                    {
                        return "You Lose";
                    }
        }
    }
}