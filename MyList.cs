using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListConsole
{
    class MyList<T>
    {
        T[] mem;

        int len;
        int capcity;

        public MyList()
        {
            len = 0;
            capcity = 8;
            mem = new T[capcity];
        }

        public void Add(T n)
        {
            if (len == capcity)
            {
                capcity <<= 1;
                T[] newMem = new T[capcity];
                mem.CopyTo(newMem, 0);
                mem = newMem;
            }
            mem[len] = n;
            len++;
        }

        public bool RemoveAt(int index)
        {
            if (index == len)
            {
                len--;
            }
            else
            {
                len--;
                for (int i = index; i < len; i++)
                {
                    mem[i] = mem[i + 1];
                }
            }
            return true;
        }

        public void Set(T n,int index)
        {
            mem.SetValue(n, index);
        }

        public void Get(int index)
        {
            mem.GetValue(index);
        }

        public void Print(MyList<T> l)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write(l.mem[i] + " ");
            }

            Console.ReadKey();
        }

        public T PopFront()
        {
            var temp = mem[0];
            RemoveAt(0);
            return temp;
        }

        public void Insert(int index, T item)
        {
            if(index == len)
            {
                Add(item);
            }
            else if(index <0)
            {
                return;
            }
            else
            {
                if(len == capcity)
                {
                    capcity <<= 1;
                    T[] newMem = new T[capcity];
                    newMem[0] = item;
                    len++;
                    for (int i = 1; i < len; i++)
                    {
                        newMem[i] = mem[i - 1];
                    }
                    mem = newMem;
                }
                else
                {
                    T[] newMem = new T[capcity];
                    newMem[0] = item;
                    len++;
                    for (int i = 1; i < len; i++)
                    {
                        newMem[i] = mem[i - 1];
                    }
                    mem = newMem;
                }
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            MyList<string> l = new MyList<string>();
            l.Add("y");
            l.Add("a");
            l.Add("y");
            l.Add("a");
            l.Add("y");
            l.Add("a");
            l.Add("y");
            l.Add("a");


            l.Insert(0, "a");

            l.Print(l);
        }
    }
}
