public class NumToBool
{
    public bool NumberToBool(int num)
    {
        if (num == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public int BoolToInt(bool b)
    {
        if(b == true)
        {
            return 1;
        } else
        {
            return 0;
        }
    } 
}