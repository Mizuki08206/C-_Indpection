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
            //L();
            //M();
            //N();
            //O();



        }
        public static void O()
        {
            var num = NullReturn();//numはNullable型のため、HasValueが使用できる
            if (num.HasValue)
            {
                Console.WriteLine(num.Value);
            }
            else
            {
                Console.WriteLine("nullでした");
            }
        }
        public static int? NullReturn()
        {
            //値型におけるT型とT?型（Nullable<T>型）は明確に異なる。例えば、int?とint
            //参照型におけるT型とT?型（Nullable<T>型）は内部的に同じ型
            //戻り値もint?で指定する必要がある
            int? num = null;
            return num;
        }
        public static void N()//CS-29 ジェネリック
        {
            Console.WriteLine(Max(5, 6.8)+"が大きい\n\n");
            foreach(var num in Array<double>())
            {
                Console.WriteLine(num);
            }

            int? value = null;
            if (value.HasValue)
            {
                Console.WriteLine("not null");
            }
            else
            {
                Console.WriteLine("null");
            }
            var num1=Num<int>();//intの部分が参照型だとエラー
            if (!num1.HasValue)
            {
                num1 = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(num1);
        }
        public static T? Num<T>() where T : struct//Tのnull許容型
        {
            T? num = null;
            Console.WriteLine(num.HasValue);
            //if (num.HasValue)
            //{
            //    Console.WriteLine(num);
            //}
            return num;
        }
        public static T[] Array<T>()//CS-29 ジェネリック
        {
            //指定された型で配列を作成し、default演算子を使用してビットパターンが「0」で表現される値で初期化をする
            //数値は「0」となり、参照型は「null」となる
            T[] values = new T[10];
            Console.WriteLine("{0}　なので、{1}で初期化をします。",typeof(T),default(T));
            for(int i=0;i<values.Length;i++)
            {
                values[i] = default(T);
            }
            return values;
        } 
        public static T Max<T>(T a,T b) where T : IComparable//CS-29 ジェネリック
        {
            //TもしくはTypeで記述
            //where 型引数　：　条件　を記載すると、T　は　実装もしくは継承することができる
            //実装もしくは継承したメンバを使用することができる
            Console.WriteLine("{0}と{1}の大小比較",a,b);
            return a.CompareTo(b) > 0 ? a : b;
        }
        public static void M()//CS-28 拡張メソッド
        {
            //拡張メソッドは、インスタンスを生成するクラスに対して、継承なしで追加のメソッドを定義できる
            //インスタンスを生成しなければ使うことができない
            Sample s=new Sample();
            Console.WriteLine(s.Print());
            Console.WriteLine(s.EPrint());
        }
        public static void L()//CS-23 例外
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            Console.WriteLine("-----37---------");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())//ここでファイルダイアログが出ると思ってた
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
        public static void K()//CS-22 ファイルIO
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
        public static void J()//CS-17 継承・オーバーライド
        {
            string str = "Hello";
            Console.WriteLine(string.Concat(str," World"));
            string str2 = "Hello";
            Console.WriteLine(str == str2);
            Console.WriteLine(str.Equals(str2));
        }
        public static void I()//CS-17 継承・オーバーライド
        {
            var a = new Animal() { Name = "aaa" };
            var b = new Cat() { Name = "bbb" };
            a.Bark();
            b.Bark();
        }
        public static void H()//CS-14 クラス・インスタンス
        {
            //コンストラクタを使用しなくてもインスタンス化時に｛｝をつけることで初期化できる
            //new int[]{1, 2, 3}のような配列の初期化式と同じだと思う
            var human = new Person()
            {
                Name = "Taro", Age = 28
            };
            human.Print();
            Console.WriteLine(human.Name);//Yuki
            Console.WriteLine(human.Age);//28
        }
        public static void G()//CS-10 メソッド
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
        public static bool PrintKuKu(int end)//CS-10 メソッド
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
        public static void F()//CS-09 値型・参照型
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
        public static void E()//CS-09 値型・参照型
        {
            int num = 10;
            Console.WriteLine(num);
            D(ref num);
            Console.WriteLine(num);
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
        public static void D(ref int num)//CS-09 値型・参照型
        {
            num += 10;
        }
        public static void C()//CS-08 配列
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
        public static void B()//CS-08 配列
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
                    return;
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
        public static void A()//CS-08 配列
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

    public static class ESample//staticクラスにする必要がある。Sampleクラスの拡張メソッドを定義
    {
        //static string s = "Hello World !!!";
        public static string EPrint(this Sample s)//staticとthisで定義して、引数には拡張するメソッドが定義されているクラスを指定する
        {
            return  "Hello World !! Extend";
        }
    }
    public class Sample
    {
        //内部的には
        //public static string EPrint(this Sample s) { return "Hello World !! Extend" ; }
        //上で作成したESampleクラスのEPrintメソッドがこちらのものとなる
        //
        public string Print()
        {
            return "Morning";
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
    public class Cat : Animal//CS-17 継承・オーバーライド
    {
        public override void Bark()
        {
            Console.WriteLine("{0}は鳴いた", this.Name);
        }
    }
    public class Animal//CS-17 継承・オーバーライド
    {
        public string Name { get; set;}
        public virtual void Bark()
        {
            Console.WriteLine("{0}は吠えた",this.Name);
        }
    }
}
