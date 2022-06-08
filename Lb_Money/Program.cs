using System; 

namespace Lb_Money
{

    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Количество байт в куче: {0}\nМаксимальное количество поддерживаемых поколений объектов: {1}",
                GC.GetTotalMemory(false), GC.MaxGeneration + 1);
             

            Money[] obj = new Money[30];
            for (int i = 0; i < 30; i++)
                using (obj[i] = new Money(i))
                {
                    Console.WriteLine(obj[i].ToString());
                }


            GC.Collect(0, GCCollectionMode.Forced); 

            Console.WriteLine("Количество байт в куче: {0}\nМаксимальное количество поддерживаемых поколений объектов: {1}",
                GC.GetTotalMemory(false), GC.MaxGeneration + 1);

            //Money m = new Money(123.45);
            //Console.WriteLine(m.ToString());
            //m.Count = m.Count + 0.25;
            //Console.WriteLine(m.ToString());
        }
    }
     
    class Money : IDisposable
    { 

        public void Dispose()
        {
            Console.WriteLine("Освобождение ресурсов объекта!"); 
        }

        
        double count = 0.0;

        public Money()
        {
            Count = 0.0;
        }
        public Money(double c)
        {
            Count = c;
        }

        public double Count 
        {
            get
            {
                return count;
            } 
            set
            {
                try
                {
                    if (value < 0) throw new Exception("Bankrot");
                    else count = value;
                }
                catch (Exception a)
                {
                    Console.WriteLine(a.Message);
                    count = 0;
                } 
            }
        }

        public override string ToString()
        {
            string s = "Счет: " + Count; 
            return s;
        }

        public static Money operator ++(Money m1)
        {
            m1.Count += 0.01;
            return m1;
        }

        public static Money operator --(Money m1)
        {
            m1.Count -= 0.01;
            return m1;
        }

        public static Money operator /(Money m1, int x)
        { 
            m1.Count = m1.Count / x;
            return m1;
        }

        public static Money operator *(Money m1, double x)
        {
            m1.Count = m1.Count * x;
            return m1;
        }

        public static Money operator +(Money m1, double x)
        { 
            m1.Count = m1.Count + x;
            return m1;
        }

        public static Money operator -(Money m1, double x)
        {
            m1.Count = m1.Count - x;
            return m1;
        }

        public static bool operator ==(Money m1, double x)
        {
            if (m1.Count == x) return true;
            else return false;
        }

        public static bool operator !=(Money m1, double x)
        {
            if (m1.Count != x) return true;
            else return false;
        }

        public static bool operator <(Money m1, double x)
        {
            if (m1.Count < x) return true;
            else return false;
        }

        public static bool operator >(Money m1, double x)
        {
            if (m1.Count > x) return true;
            else return false;
        }
    }
} 