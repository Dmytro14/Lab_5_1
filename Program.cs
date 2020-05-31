using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_5_1
{

    abstract public class Kiosk
    {
    public string Name { get; set; }
    public string Address { get; set; }

    public static List<TouringTrip> ReadDate(string path)
    {
        List<TouringTrip> g = new List<TouringTrip>();
        string text = "";
        using (StreamReader sr = new StreamReader(path))
        {
            text = sr.ReadToEnd();
        }
        string[] Times = text.Split('/');
        foreach (string s in Times)
        {
            string[] MetaDete = s.Split('|');
            if (MetaDete.Length == 5)
            {
                TouringTrip d = new TouringTrip
                {
                    Coment = MetaDete[0],
                    Time = MetaDete[1],
                    Count = Convert.ToInt32(MetaDete[2]),
                    Name = MetaDete[3],
                    Address = MetaDete[4]
                };
                g.Add(d);
            }
        }
        return g;
    }
    public static void SaveDate(List<TouringTrip> Time, string path)
    {
        using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
        {
            foreach (TouringTrip g in Time)
            {

                sw.WriteLine(g.Coment.Trim() + "|" + g.Time + "|" + g.Count + "|" + g.Name + "|" + g.Address + "/");

            }
        }
    }
    public static void ChangeDate(List<TouringTrip> Time)
    {
        Console.WriteLine("Enter Time that`s need to change");
        string Nam = Console.ReadLine();
        TouringTrip Choosen = new TouringTrip();
        Choosen.Name = "";
        foreach (TouringTrip g in Time)
        {
            if (g.Time == Nam)
            {
                Choosen = g;
                break;
            }
        }
        if (Choosen.Name != "")
        {
            Console.WriteLine();
            Console.WriteLine("1)Change Coment\n2)Change Time\n3)Change Count\n4)Change Name\n5)Change Address\n6)Delete");
            char key = Console.ReadKey().KeyChar;
            Console.WriteLine("Enter new value");
            try
            {
                if (key == '1')
                {
                    Choosen.Coment = Console.ReadLine();
                }
                if (key == '2')
                {

                    Choosen.Time = Console.ReadLine();
                }
                if (key == '3')
                {
                    Choosen.Count = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(Choosen.Count);

                }
                if (key == '4')
                {
                    Choosen.Name = Console.ReadLine();
                }
                if (key == '5')
                {
                    Choosen.Address = Console.ReadLine();
                }
                if (key == '6')
                {
                    Time.Remove(Choosen);
                }
            }
            catch
            {
                Console.WriteLine("New value is incorrect");
            }
            
        }
        else
        {
            Console.WriteLine("TouringTrip Not found");
        }

    }
    public static void AddNew(List<TouringTrip> Date)
    {
        Console.WriteLine("Enter Comment");
        TouringTrip neww = new TouringTrip();
        neww.Coment = Console.ReadLine();
        Console.WriteLine("Enter Time");
        neww.Time = Console.ReadLine();
        Console.WriteLine("Enter Count");
        neww.Count = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter  Surname");
        neww.Name = Console.ReadLine();
        Console.WriteLine("Enter Address");
        neww.Address = Console.ReadLine();
        Date.Add(neww);
    }
    public static void ShowTable(List<TouringTrip> TouringTrip)
    {
        int MaxI = 8;
        int MaxN = 12;
        int MaxW = 7;
        int MaxC = 15;
        int MaxL = 11;
        Console.WriteLine("|  Coment  |Time\t Count |   Surname   | Address |");
        foreach (TouringTrip g in TouringTrip)
        {
            int ni = MaxI - Convert.ToString(g.Coment.Trim()).Length;
            int nn = MaxN - g.Time.Count();
            int nw = MaxW - Convert.ToString(g.Count).Length;
            int nc = MaxC - Convert.ToString(g.Name).Length;
            int nl = MaxL - Convert.ToString(g.Address).Length;
            Console.WriteLine("|" + Convert.ToString(g.Coment.Trim()) + PS(ni) + "|" + g.Time + PS(nn) + "\t|" +
             Convert.ToString(g.Count) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
             + Convert.ToString(g.Address) + PS(nl) + "|");
        }
        Console.WriteLine(" p - Edit/Delete,\n d - Create\n n - search\n m - The Smallest Count"+
            "\n t - To search Comment\nEnter - exit");
    }
    public static string PS(int count)
    {
        string s = "";
        for (int i = 0; i < count; i++)
        {
            s += " ";
        }
        return s;
    }
    //--------------------------------------------------------------------
    public abstract int Smallest(List<TouringTrip> lst);
    public abstract void ToComment(List<TouringTrip> lst);
    public abstract char Total(List<TouringTrip> lst);
}
//Похідний класс
public class TouringTrip : Kiosk
    {
    public string Coment { get; set; }
    public string Time { get; set; }
    public int Count { get; set; }
    //-------------------------------------------------------------------
    public override int Smallest(List<TouringTrip> lst)
    {
        Console.Clear();
        int IndexMin = 0;
        foreach (TouringTrip gs in lst)
        {
            if (lst[IndexMin].Count > gs.Count)
            {
                IndexMin = lst.IndexOf(gs);
            }
        }
        int MaxI = 8;
        int MaxN = 12;
        int MaxW = 7;
        int MaxC = 15;
        int MaxL = 11;
        TouringTrip g = lst[IndexMin];
        Console.WriteLine("|  Coment  |Time\t| Count |   Surname   | Address |");
        int ni = MaxI - Convert.ToString(g.Coment.Trim()).Length;
        int nn = MaxN - g.Time.Count();
        int nw = MaxW - Convert.ToString(g.Count).Length;
        int nc = MaxC - Convert.ToString(g.Name).Length;
        int nl = MaxL - Convert.ToString(g.Address).Length;
        Console.WriteLine("|" + Convert.ToString(g.Coment.Trim()) + PS(ni) + "|" + g.Time + PS(nn) + "\t|" +
         Convert.ToString(g.Count) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
         + Convert.ToString(g.Address) + PS(nl) + "|");
        return g.Count;
    }
    public override void ToComment(List<TouringTrip> lst)
    {

        Console.WriteLine("Enter Coment");
        string cim = Console.ReadLine();
        Console.Clear();
        int MaxI = 8;
        int MaxN = 12;
        int MaxW = 7;
        int MaxC = 15;
        int MaxL = 11;
        Console.WriteLine("|  Coment  |Time\t| Count |   Surname   | Head Name |");
        foreach (TouringTrip g in lst)
        {
            if (g.Coment.Trim() == cim.Trim())
            {
                int ni = MaxI - Convert.ToString(g.Coment.Trim()).Length;
                int nn = MaxN - g.Time.Count();
                int nw = MaxW - Convert.ToString(g.Count).Length;
                int nc = MaxC - Convert.ToString(g.Name).Length;
                int nl = MaxL - Convert.ToString(g.Address).Length;
                Console.WriteLine("|" + Convert.ToString(g.Coment.Trim()) + PS(ni) + "|" + g.Time + PS(nn) + "\t|" +
                 Convert.ToString(g.Count) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
                 + Convert.ToString(g.Address) + PS(nl) + "|");
            }

        }
        Console.WriteLine("Press any key for beak into full table");
        Console.ReadKey();
    }
    public override char Total(List<TouringTrip> lst)
    {
        Console.WriteLine("Total Count:");            
        Console.Clear();
            int t = 0;
            foreach(TouringTrip g in lst){
                t += g.Count;
            }            
            Console.WriteLine(t);
            Console.WriteLine("Press any key to return into table");
            Console.ReadLine();
        return 't';


    }
}
    //Основна програма
    class Program
    {
        
        static void Main()
        {
            Console.Clear();
            task1();
            Console.WriteLine((Char)Console.ReadKey().KeyChar);
        }
        static void task1()
        {
            string path = "";
            List<TouringTrip> goods = new List<TouringTrip>();
            Console.WriteLine("Enter path to file like '' or enter any to create new file");
            path = Console.ReadLine();
            try
            {
                goods = Kiosk.ReadDate(path);
            }
            catch
            {
                path = "Data.txt";
            }

            while (true)
            {
                Console.Clear();
                Kiosk.ShowTable(goods);
                var press = Console.ReadKey().Key;
                if (press.ToString() == "Enter")
                {
                    Main();
                }
                if (press.ToString() == "P")
                {
                    Console.WriteLine();
                    Kiosk.ChangeDate(goods);
                    Kiosk.SaveDate(goods, path);
                }
                if (press.ToString() == "D")
                {
                    Console.WriteLine();
                    Kiosk.AddNew(goods);
                    Kiosk.SaveDate(goods, path);
                }
                if (press.ToString() == "M")
                {
                    Console.WriteLine();
                    if (goods.Count > 0)
                    {
                        goods[0].Smallest(goods);
                        Console.WriteLine("Press any key to return into table");
                        Console.ReadKey();
                    }
                    Kiosk.SaveDate(goods, path);
                }
                if (press.ToString() == "T")
                {
                    Console.WriteLine();
                    if (goods.Count > 0)
                    {
                        goods[0].ToComment(goods);
                    }
                    Kiosk.SaveDate(goods, path);
                }
                if (press.ToString() == "N")
                {
                    Console.WriteLine();
                    if (goods.Count > 0)
                    {
                        goods[0].Total(goods);
                    }
                    Kiosk.SaveDate(goods, path);
                }
            }
        }
    }
}
