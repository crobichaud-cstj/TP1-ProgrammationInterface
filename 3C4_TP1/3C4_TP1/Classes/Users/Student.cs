namespace _3C4_TP1
{
    public class Student : User
    {
        public override string ToString()
        {
            return base.Id + "-" + base.FirstName + " " + base.LastName;
        }
    }

}
