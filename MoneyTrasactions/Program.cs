//testing of arrays, use of arrays for storage of information in a struct. use of rectangular arrays and searching

Finance.Money account = new(34.56, 78.90);

account.PrintAccount();
account.Pay(34.21);
account.PrintAccount();

//arrays
string[] payAug= new string[5];
{
    payAug[0] = "tom";
    payAug[1] = "jack";
    payAug[2] = "steve";
    payAug[3] = "maria";
    payAug[4] = "anne";
}
double[] depAug = new double[] { 21.33, 44.55, 67.88, 44.23, 12.34 };

string[] paySep = { "Greg", "Steve", "Amy", "Gee" };
double[] depSep = { 12.89, 123.55, 1232131.34, 545.12 };

Finance.Transactions depositAug = new(payAug, depAug);
Finance.Transactions depositSep = new(paySep, depSep);

depositAug.Print();
depositSep.Print();

depositAug.LastDep();
depositSep.LastDep();


namespace Finance
{
    public class Money
    {
        double dollars;
        double pounds;
        public Money(double d = 0, double p = 0)
        {
            dollars = d;
            pounds = p;
        }
        public double Pay(double amount)
        {   //pay with the currency you have the most, returns the change
            return (this.MostMoney() == dollars) ? (dollars -= amount) : (pounds -= amount);
        }
        public double MostMoney() { return (dollars > pounds) ? dollars : pounds; }
        public double GetDlr() { return dollars; }
        public double GetPnd() { return pounds; }
        public double AddDlr(double d)
        {
            dollars = checked(dollars + d);
            return dollars;
        }
        public double AddPnd(double d)
        {
            pounds = checked(pounds + d);
            return pounds;
        }
        public void PrintAccount()
        {
            Console.WriteLine($"there is a total of ${dollars} and an additional £{pounds}");
        }
    }

    public struct Transactions
    {
        string[,] trans;
        int length;
        public Transactions(string[] names, double[]deposit)
        {
            trans = new string[2, names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                trans[0, i] = names[i];
                trans[1, i] = deposit[i].ToString();
            }
            length = names.Length;
        }
        public void AddTrans(string[] names, string[] deposit)
        {
        
        }
        public void Print()
        {
            for (int i = 0; i < trans.GetLength(1); i++)
            {
                Console.WriteLine(trans[0, i]);
                Console.WriteLine(trans[1, i]);
            }
        }
        public string LastDep()
        {
            string last = trans[1,GetLen()-1];
            Console.WriteLine(last);
            return last;
        }
        public int GetLen() { return length; }
    }
}