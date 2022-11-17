using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace Inspection
{
    internal class Inspection
    {
        static void Main(string[] args)
        {
            //A();
            //B();
            //C();
            //E();
            //F();
            //G();
            //H();
            //I();
            //J();
            //K();
            L();

        }
        public static void L()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            Console.WriteLine("-----37---------");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                Console.WriteLine("----40----------");//ここまでしか実行されない。フォームアプリでやる必要がある？
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("----48----------");
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        Console.WriteLine("------57--------");
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            Console.WriteLine("--------------");
            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }
        public static void K()
        {
            try
            {
                using (var reader = new StreamReader("recode.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("END1");
            using (var reader = new StreamReader("record.txt"))//recode.txtは存在しない
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("END2");
        }
        public static void J()
        {
            string str = "Hello";
            Console.WriteLine(string.Concat(str," World"));
            string str2 = "Hello";
            Console.WriteLine(str == str2);
            Console.WriteLine(str.Equals(str2));
        }
        public static void I()
        {
            var a = new Animal() { Name = "aaa" };
            var b = new Cat() { Name = "bbb" };
            a.Bark();
            b.Bark();
        }
        public static void H()
        {
            //コンストラクタを使用しなくてもインスタンス化時に｛｝をつけることで初期化できる
            //new int[]{1, 2, 3}のような配列の初期化式と同じ
            var human = new Person()
            {
                Name = "Taro", Age = 28
            };
            human.Print();
            Console.WriteLine(human.Name);//Yuki
            Console.WriteLine(human.Age);//28
        }
        public static void G()
        {
            while (true)
            {
                string input=Console.ReadLine();
                if(int.TryParse(input, out int num))
                {
                    Console.WriteLine(PrintKuKu(num));
                    break;
                }
            }
        }
        public static bool PrintKuKu(int end)
        {
            bool flag = false;
            for(int i = 1; i <= end; i++)
            {
                for(int j=1; j <= end; j++)
                {
                    Console.Write("{0,5:d} ", i * j);
                    flag = true;
                }
                Console.WriteLine();
            }
            return flag;
        }
        public static void F()
        {
            var src = new int[] { 1, 2, 3 };
            int[] dest = new int[src.Length];
            for(int i= 0; i < src.Length; i++)
            {
                dest[i] = src[i];
            }
            src[0] = 0;
            foreach(var i in dest)
            {
                Console.WriteLine(i);
            }
        }
        public static void E()
        {
            //int num = 10;
            //Console.WriteLine(num);
            //D(ref num);
            //Console.WriteLine(num);
            string str = null;
            Console.WriteLine(str);
            int? i = null;
            Console.WriteLine(i);

            int num1 = 10;
            ref var num2 = ref num1;
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            num2 += 10;
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            num1 += 10;
            Console.WriteLine(num1);
            Console.WriteLine(num2);
        }
        public static void D(ref int num)
        {
            num += 10;
        }
        public static void C()
        {
            int[][] array = new int[][]
            {
                new int[] { 1, 2 ,3},
                new int[] {10,20},
                new int[] {100,200,300,400}
            };
            foreach(var nums in array)
            {
                Console.WriteLine("長さは{0}",nums.Length);
                foreach(var num in nums)
                {
                    Console.WriteLine(num);
                }
            }
        }
        public static void B()
        {
            Console.WriteLine("半角スペース文字区切りで数値を入力");
            string[] inputs = Console.ReadLine().Split(' ');
            int[] nums=new int[inputs.Length];
            for(int i = 0; i < inputs.Length; i++)
            {
                if(int.TryParse(inputs[i], out nums[i]))
                {
                    Console.Write("{0} ", nums[i]);
                }
                else
                {
                    Console.WriteLine("数字以外が混じってます");
                }
            }
            Console.WriteLine();
            for(int i=0; i < nums.Length; i++)
            {
                for(int j=i;j < nums.Length; j++)
                {
                    if(nums[i] > nums[j])
                    {
                        int tmp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = tmp;
                    }
                }
            }
            foreach(var output in nums)
            {
                Console.WriteLine(output);
            }

        }
        public static void A()
        {
            int start = -1;
            int count = -1;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out start))
                {
                    if (start < 0 || 99 < start)
                    {
                        Console.WriteLine("startが不正です");
                        continue;
                    }
                    input = Console.ReadLine();
                    if (int.TryParse(input, out count))
                    {
                        if (count < 0)
                        {
                            Console.WriteLine("start+countが100以上");
                            continue;
                        }
                        break;
                    }
                }
                Console.WriteLine("正しく入力..");
            }
            count %= 100;
            int[] array = new int[100];
            for (int i = start; i <= start + count; i++)
            {
                array[i - 1] = i * i;
            }
            int sum = 0;
            for (int i = start; i < start + count; i++)
            {
                sum += array[i];
            }
            Console.WriteLine(sum);
            Console.WriteLine("END");
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {
        }
        public void Print()
        {
            Console.WriteLine("{0}は{1}歳です。",this.Name,this.Age);
        }
    }
    public class Cat : Animal
    {
        public override void Bark()
        {
            Console.WriteLine("{0}は鳴いた", this.Name);
        }
    }
    public class Animal
    {
        public string Name { get; set;}
        public virtual void Bark()
        {
            Console.WriteLine("{0}は吠えた",this.Name);
        }
    }
}
