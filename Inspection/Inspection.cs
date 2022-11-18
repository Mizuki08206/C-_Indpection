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
            //P();
            //Q();
            //Start();
            S();

        }
        public static void T()
        {
            
        }
        public static void S()//匿名型
        {
            //匿名型はvarでしか宣言できない。
            //varにカーソルを当てるとAnonymouseTypeとなっている
            var data = new { No = 1, Name = "Suzuki" };
            Console.WriteLine("{0}：{1}", data.No, data.Name);
        }
        private static int Add(int x, int y)
        {
            return x + y;
        }
        public static void Start()
        {
            // 関数をデリゲートに登録
            Func<int, int, int> func1 = Add;

            // ラムダ式で作った関数を登録
            Func<int, int, int> func2 = (x, y) => x + y;//なぜAddが登録される？

            // 呼び出し
            Console.WriteLine(func1(10, 20));
            Console.WriteLine(func2(50, 20));
        }
        public static void R()//CS-32 デリゲート
        {
            //デリゲートは参照型のため、nullもOK
            //ポリモーフィズムをメソッドレベルで実現できる
            //フォームアプリを作成する際の、EventHandler<T>もデリゲートで、変数に入れて利用している
            //デリゲートがなくてもインターフェースでもできる
            //実行するメソッドを自由に差し替えて実行させる
            Action<int> a1 = Console.WriteLine;//Action<T>で指定した型でのみ、メソッドを呼び出せる
            a1(123);
            Action<string> a2 = Console.WriteLine;
            a2("string");

        }
        public static void Q()//コレクション（キュー、スタック、リスト、ディクショナリ）
        {
            List<int> list = new List<int>();
            Dictionary<int, string> dic = new Dictionary<int, string>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            for(int i=0;i<20;i++)
            {
                list.Add(i);
                dic.Add(i, "Hello");
                stack.Push(i);
                queue.Enqueue(i);
            }

            Console.WriteLine(stack.Pop());//取り出して削除される
            Console.WriteLine("=============");

            foreach (var s in stack)//list,dic,stack,queueを入れ替えて取り出し順を見る
            {
                Console.WriteLine(s);
            }
        }
        public static void P()//CS-30 null関係の演算子
        {
            //三項演算子
            //条件式　?　真の場合の値（式） : 偽の場合の値（式）
            //①
            int? tmp = null;
            var num1=tmp.HasValue? tmp.Value : 0;
            Console.WriteLine(num1);

            //これと同じことがメソッドで用意されている
            //②
            int? num2 = null;
            Console.WriteLine(num2.GetValueOrDefault());
            //GetValueOrDefault()はnullでなければValue、nullであればdefault値を返す
            
            //③
            //??演算子
            int?  num3= null;
            Console.WriteLine(num3 ?? 101);
            //num3がnullでなければnum3の値を、nullであれば101を返す
            //演算子のため、普通の参照型にも使用できる
            //var message = errorMessage ?? "正常終了" ;

            //①と②と③は同じ処理

            string str = null;
            Console.WriteLine("--{0}---",str);
            //str ??= "default string";//C# 8.0以上のバージョンが必要

            //?.演算子
            //途中の式がの結果がnullになった場合に、最終的な結果をnullとする。
            //例えば
            Person p = new Person();
            var s = p.Partner?.Company?.President.Partner?.Name ?? "is null";
            Console.WriteLine(s ?? "nullです");


        }
        public static void O()//CS-29 ジェネリック
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
    public class Company
    {
        public string Name { get; set; }
        public Person President { get; set; }//Companyクラスのメンバにすべき
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person Partner { get; set; }
        public Company Company { get; set; }
        
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
