using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
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
            //S();
            //Dentaku.Dntk();
            //T();

            Address ad = new Address();
            ad.Sub();

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
            //デリゲートがなくてもインターフェースでも実現可能
            //実行するメソッドを自由に差し替えて実行させるのが理想的な使い道
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
            //StackはLIFO、QueueはFIFOのアルゴリズム
            Console.WriteLine(stack.Pop());//取り出して削除される
            Console.WriteLine(queue.Dequeue());//取り出して削除される
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
    //----------------------------------------------------
    public class Dentaku
    {
        //TestCase
        //10 + 5 * 2 = 30
        //10 + 5 5 5 = Error
        //10 + * 5 = Error
        //aaa + 5 =Error
        //20 - ( 10 / 2 ) + ( 5 * 4 ) = 35
        //10 * ( 2 + ( ( 5 - 3 ) * 4 ) ) / ( ( 2 * 3 ) - 4 ) = 50
        //
        public static void Dntk()
        {
            Console.WriteLine("計算式を入力してください");
            var inputs = Console.ReadLine().Split(' ');

            //発展問題か簡易電卓かを判定
            bool which = false;
            foreach (var input in inputs)
            {
                if (input == "(" || input == ")")//( )の優先のみ対応
                {
                    which = true;
                }
            }
            if (which)
            {
                ECalc(inputs);
            }
            else
            {
                Calc(inputs);
            }
        }
        public static void ECalc(string[] inputs)
        {
            if (ECheck(inputs))
            {
                Console.WriteLine("計算式 is No Problem !!");
                //チェックは済んでいるため、正しい計算式が入ってくる前提
                //1.　）を見つける　
                //2.（　を見つける
                //3.計算してaで置換する
                //4.計算結果を、（のインデックスに格納する
                //5.aを削除して前に詰める
                int i = 0;
                while (i < inputs.Length)//括弧をなくすループ
                {
                    if (inputs[i] == ")")//このif内のどこかでArray.Resize
                    {
                        int sum = 0;
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (inputs[j] == "(")
                            {
                                Console.WriteLine("J={0},I={1}", j, i);
                                for (int k = j + 1; k < i; k++)
                                {
                                    Console.WriteLine("k=" + k);
                                    if (k == j + 1)
                                    {
                                        sum = int.Parse(inputs[k]);
                                        Console.WriteLine("sum=" + sum);
                                        continue;
                                    }
                                    Console.WriteLine("計算!");
                                    if (int.TryParse(inputs[k], out int num))//ここ後で怪しくなるかも
                                    {
                                        Console.WriteLine("num=" + num);
                                        switch (inputs[k - 1])
                                        {
                                            case "+":
                                                Console.WriteLine("{0}+{1}", sum, num);
                                                sum += num;
                                                break;
                                            case "-":
                                                Console.WriteLine("{0}-{1}", sum, num);
                                                sum -= num;
                                                break;
                                            case "*":
                                                Console.WriteLine("{0}*{1}", sum, num);
                                                sum *= num;
                                                break;
                                            case "/":
                                                Console.WriteLine("{0}/{1}", sum, num);
                                                sum /= num;
                                                break;
                                        }
                                    }
                                }
                                for (int l = j; l <= i; l++)
                                {
                                    inputs[l] = "aaa";
                                }
                                inputs[j] = sum.ToString();
                                break;
                            }
                        }

                        foreach (var output in inputs)
                        {
                            Console.Write(output + " ");
                        }

                        //aに書き換えるところとaを消して詰めるところ
                        int lc = 0;//aaaが何個重なっているか。いくつ前に詰めるか
                        int end = -1;//aaaが終わるインデックス

                        for (int j = 0; j < inputs.Length; j++)
                        {
                            if (inputs[j] == "aaa")
                            {
                                end = j;
                                lc++;
                            }
                        }
                        for (int k = end + 1; k < inputs.Length; k++)
                        {
                            inputs[k - lc] = inputs[k];
                        }
                        int tmp = inputs.Length;
                        Array.Resize<string>(ref inputs, tmp - lc);
                        Console.WriteLine("\n配列の長さが{0}=>{1}になりました。", tmp, tmp - lc);
                        i = 0;
                        Console.WriteLine("\n\n=======新しい式==================\n");
                        foreach (var output in inputs)
                        {
                            Console.Write(output + " ");
                        }
                        Console.WriteLine("\n\n=================================\n");
                    }
                    i++;
                }

                Calc(inputs);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public static bool ECheck(string[] inputs)//計算式が正しく並んでいるかをチェック
        {
            bool check = true;//計算式が正しく並んでいるか
            bool numor = true;//数値と演算子の順序のチェック
            int brackets = 0;//括弧の組み合わせのチェック、（　は+1で、　）は-1、最終0になれば問題なし
            foreach (var input in inputs)
            {
                if (numor)//数字もしくは括弧が入るべきところのチェック
                {
                    if (int.TryParse(input, out int tmp) || input == "(")
                    {
                        if (int.TryParse(input, out tmp))
                        {//括弧は次に演算子は来ないからfalseにしない
                            numor = false;//次は演算子もしくは閉じ括弧
                        }
                    }
                    else
                    {
                        check = false;
                    }
                }
                else//演算子が入るべきところのチェック
                {
                    if (input == "+" || input == "-" || input == "*" || input == "/" || input == ")")
                    {
                        if (input == "+" || input == "-" || input == "*" || input == "/")
                        {
                            numor = true;//次は数字もしくは開き括弧
                        }
                    }
                    else
                    {
                        check = false;
                    }
                }
                if (input == "(")//たぶん foreach < if < if の中に入れても同じ
                {
                    brackets++;
                }
                else if (input == ")")
                {
                    brackets--;
                }
            }
            if (brackets != 0)
            {
                check = false;
            }
            return check;
        }
        public static void Calc(string[] inputs)
        {
            if (Check(inputs))
            {
                //%2==0が数値
                //%2==1が演算子
                int.TryParse(inputs[0], out int sum);
                int lc = 2;
                while (lc < inputs.Length)
                {
                    switch (inputs[lc - 1])
                    {
                        case "+":
                            sum += int.Parse(inputs[lc]);
                            break;
                        case "-":
                            sum -= int.Parse(inputs[lc]);
                            break;
                        case "*":
                            sum *= int.Parse(inputs[lc]);
                            break;
                        case "/":
                            sum /= int.Parse(inputs[lc]);
                            break;
                    }
                    lc += 2;//必ず数値に添え字を置く
                }
                Console.WriteLine("合計:{0}", sum);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public static bool Check(string[] inputs)
        {
            bool flag = true;
            int lc = 0;
            while (inputs.Length > lc)//%2==0が数字かどうか
            {
                if (!int.TryParse(inputs[lc], out int tmp))
                {
                    flag = false;
                }
                lc += 2;
            }
            lc = 1;
            while (inputs.Length > lc)//%2==1が演算子かどうか
            {
                if (!(inputs[lc] == "+" || inputs[lc] == "-" || inputs[lc] == "*" || inputs[lc] == "/"))
                {
                    flag = false;
                }
                lc += 2;
            }
            if (!(inputs.Length % 2 == 1))//配列の数が正しいかどうか
            {
                flag = false;
            }
            return flag;
        }
    }
    //----------------------------------------------------
    public class Address
    {
        public Dictionary<string, List<string>> CommandList { get; set; } = new Dictionary<string, List<string>>();
        public List<Data> datalist=new List<Data>();

        public Address()//コマンドの格納（ここは省略できない気がする...）とメソッドの格納
        {
            CommandList[":list （一覧表示コマンド）"] = new List<string>() {"現在登録されている住所録データをすべて表示する",
                "表示形式は、先頭に通し番号（1スタート）を表示したうえで、登録された情報を半角スペース区切りで表示する" };
            CommandList[":exit （終了コマンド）"] = new List<string>() { "アプリケーションを終了する" };
            CommandList[":delete no （削除コマンド）"] = new List<string>() { "noで指定された通し番号（一覧表示時のNo）のデータを削除する",
                "削除後、通し番号は先頭から振り直される",
                "追加の情報は、半角スペースの後に続く仕様とする" };
            CommandList[":sort 項目名 （ソートコマンド）"] = new List<string>() { "項目名で指定された項目の昇順でデータをソートする",
                "有効な項目名は name,age,telno,address のいずれかとする" };
            CommandList[":save ファイルパス （ファイル保存コマンド）"] = new List<string>() { "指定されたテキストファイルに現在登録されている住所録情報を保存する" };
            CommandList[":load ファイルパス （ファイル読み込みコマンド）"] = new List<string>() { "指定されたテキストファイルから住所録データを読み込む",
                "ファイルの内容のデータにすべて置き換える仕様（既存の登録内容は失われてもよい）",
                "ファイルは:saveコマンドで出力されたものを指定する前提でOK" };
            CommandList[":help （ヘルプコマンド）"] = new List<string>() { "簡易住所録の使い方（各コマンドの使い方）を表示する" };
            CommandList[":clear （一括削除コマンド）"] = new List<string>() { "現在登録されている住所録情報をすべて削除する" };
            CommandList[":find 項目名 値 （検索コマンド）"] = new List<string>() {"指定された検索対象の項目名と値に合致する住所録データをすべて表示する",
                "例）:find age 22 =>年齢が22才の住所録データを表示",
                "表示形式は:listコマンドと同じとする" };
            
        }
        public void Sub()//メインで動かすメソッド
        {
            Load("data.txt");
            while (true)
            {
                Console.Write("入力>>>");
                var input = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(input))
                {
                    continue;
                }
                if (input.Substring(0, 1).Equals(":")){//コマンドが入力された場合
                    //Console.WriteLine(":は入力されている");
                    if (ComCheck(input))
                    {
                        Console.WriteLine(ComCheck(input));
                        //ここから下をどうにかして縮めたいけど思いつかない
                        if (input.Contains("list"))
                        {
                            ShowList();
                        }else if (input.Contains("exit"))
                        {
                            Exit();
                            break;
                        }else if (input.Contains("delete"))
                        {
                            var inputs=input.Split(' ');
                            Delete(int.Parse(inputs[1]));
                        }else if (input.Contains("sort"))
                        {
                            Sort(input);
                        }else if (input.Contains("save"))
                        {
                            Save(input);
                        }else if (input.Contains("load"))
                        {
                            Load(input);
                        }else if (input.Contains("help"))
                        {
                            Help();
                        }else if (input.Contains("clear"))
                        {
                            Clear();
                        }else if (input.Contains("find"))
                        {
                            Find(input);
                        }
                    }
                    else
                    {
                        Console.WriteLine("不正なコマンドです");
                    }
                }
                else//コマンド以外が入力された場合
                {
                    if (InputCheck(input))
                    {
                        var inputs = input.Split(' ');
                        datalist.Add(new Data(inputs[0], int.Parse(inputs[1]), inputs[2], inputs[3]));
                        Console.WriteLine("{0}を登録しました。", inputs[0]);
                    }
                    else
                    {
                        Console.WriteLine("登録できません。フォーマットを確認してください。\n名前 年齢 電話番号 住所（半角スペース区切り）");
                    }
                }
            }//無限ループ終了
        }
        public void ShowList()//一覧表示コマンド
        {
            if (datalist != null)
            {
                int i = 1;
                Console.WriteLine("=====================================");
                foreach (var output in datalist)
                {
                    Console.WriteLine("{0}:{1} {2} {3} {4}", i, output.Name, output.Age, output.Telno, output.Address);
                    i++;
                }
                Console.WriteLine("=====================================");
            }
            else
            {
                Console.WriteLine("何も入っていませんでした。\nデータを取得します");
                Load("data");
            }
        }
        public void Exit()//終了コマンド
        {
            Console.WriteLine("終了します。");
            Application.Exit();//Environment.Exit(0)かもしれない
        }
        public void Delete(int no)//削除コマンド
        {
            Console.WriteLine("{0}:{1}を削除しました。", no, datalist[no - 1].Name);
            datalist.RemoveAt(no-1);
        }
        public void Sort(string input)//ソートコマンド
        {
            var inputs=input.Split(' ');
            Console.WriteLine("{0}でソートします。。。", inputs[1]);
            if (inputs[1].Equals("name") || inputs[1].Equals("age") || inputs[1].Equals("telno") || inputs[1].Equals("address"))
            {
                switch (inputs[1])
                {
                    case "name":
                        for(int i = 0; i < datalist.Count; i++)
                        {
                            for(int j = i; j < datalist.Count; j++)
                            {
                                if(string.Compare(datalist[i].Name , datalist[j].Name)>0)
                                {
                                    var tmp=datalist[i];
                                    datalist[i] = datalist[j];
                                    datalist[j] = tmp;
                                }
                            }
                        }
                        break;
                    case "age":
                        for (int i = 0; i < datalist.Count; i++)
                        {
                            for (int j = i; j < datalist.Count; j++)
                            {
                                if (datalist[i].Age > datalist[j].Age)
                                {
                                    var tmp = datalist[i];
                                    datalist[i] = datalist[j];
                                    datalist[j] = tmp;
                                }
                            }
                        }
                        break;
                    case "telno":
                        for (int i = 0; i < datalist.Count; i++)
                        {
                            for (int j = i; j < datalist.Count; j++)
                            {
                                if (string.Compare(datalist[i].Telno, datalist[j].Telno) > 0)
                                {
                                    var tmp = datalist[i];
                                    datalist[i] = datalist[j];
                                    datalist[j] = tmp;
                                }
                            }
                        }
                        break;
                    case "address":
                        for (int i = 0; i < datalist.Count; i++)
                        {
                            for (int j = i; j < datalist.Count; j++)
                            {
                                if (string.Compare(datalist[i].Address, datalist[j].Address) > 0)
                                {
                                    var tmp = datalist[i];
                                    datalist[i] = datalist[j];
                                    datalist[j] = tmp;
                                }
                            }
                        }
                        break;
                }
            }
        }
        public void Save(string filePath)//ファイル保存コマンド
        {
            try
            {
                filePath = "data.txt";//ファイルが分散しないように書き換えてしまおう
                using(var stream = new StreamWriter(filePath,false,Encoding.UTF8))//falseで上書き
                {
                    foreach(var item in datalist)
                    {
                        stream.Write("{0} {1} {2} {3}\n", item.Name, item.Age, item.Telno, item.Address);
                    }
                    Console.WriteLine("データを書き込みました。");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\n\nファイルを開くことができませんでした。");
            }
        }
        public void Load(string filePath)//ファイル読み込みコマンド
        {
            try
            {
                filePath = "data.txt";//ファイルが分散しないように書き換えてしまおう
                using (var stream=new StreamReader(filePath))
                {
                    var tmplist = new List<Data>();
                    while (!stream.EndOfStream)
                    {
                        var inputs = stream.ReadLine().Split(' ');
                        tmplist.Add(new Data(inputs[0], int.Parse(inputs[1]), inputs[2], inputs[3]));
                    }
                    datalist = tmplist;
                    tmplist = null;
                    Console.WriteLine("読み込みました。");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\n\nファイルを開くことができませんでした。");
            }
        }
        public void Help()//ヘルプコマンド
        {
            Console.WriteLine("=====================================");
            foreach (var out1 in CommandList.Keys)
            {
                Console.WriteLine("{0}",out1);
                foreach(var out2 in CommandList[out1])
                {
                    Console.WriteLine("・{0}",out2);
                }
                Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine("=====================================");
        }
        public void Clear()//一括削除コマンド
        {
            datalist.Clear();
            Console.WriteLine("リストを一括削除しました。");
        }
        public void Find(string input)//検索コマンド
        {
            var inputs = input.Split(' ');
            Console.WriteLine("=====================================");
            if (inputs[1].Equals("name"))
            {

                foreach (Data data in datalist)
                {
                    if (data.Name.Equals(inputs[3]))
                    {
                        Console.WriteLine("{0} {1} {2} {3}", data.Name, data.Age, data.Telno, data.Address);
                    }
                }
            }else if (inputs[1].Equals("age"))
            {
                foreach (Data data in datalist)
                {
                    if (data.Age.Equals(inputs[3]))
                    {
                        Console.WriteLine("{0} {1} {2} {3}", data.Name, data.Age, data.Telno, data.Address);
                    }
                }
            }
            else if (inputs[1].Equals("telno"))
            {
                foreach (Data data in datalist)
                {
                    if (data.Telno.Equals(inputs[3]))
                    {
                        Console.WriteLine("{0} {1} {2} {3}", data.Name, data.Age, data.Telno, data.Address);
                    }
                }
            }
            else if (inputs[1].Equals("address"))
            {
                foreach (Data data in datalist)
                {
                    if (data.Address.Equals(inputs[3]))
                    {
                        Console.WriteLine("{0} {1} {2} {3}", data.Name, data.Age, data.Telno, data.Address);
                    }
                }
            }
            Console.WriteLine("=====================================");
        }
        public bool InputCheck(string input)//入力とチェック
        {
            //入力のチェック
            //年齢の範囲チェック
            //電話番号のフォーマットチェック
            //住所の県チェック

            bool check = true;
            var inputs = input.Split(' ');
            //区切り文字の数チェック
            if (inputs.Length !=4)
            {
                check = false;
                return check;
            }
            //年齢の範囲チェック
            if (int.TryParse(inputs[1],out int num))
            {
                if(num<0 || 120 < num)
                {
                    check = false;
                    return check;
                }
            }
            else
            {
                check = false;
            }
            //電話番号のフォーマットチェック
            if (!Regex.IsMatch(inputs[2], @"0[7-9]0-\d{4}-\d{4}"))
            {
                check=false;
                return check;
            }
            //住所の県チェック
            string[] prefectures = {"北海道","青森県","岩手県","宮城県","秋田県","山形県","福島県","茨城県",
                "栃木県","群馬県","埼玉県","千葉県","東京都","神奈川県","新潟県","富山県","石川県","福井県","山梨県",
                "長野県","岐阜県","静岡県","愛知県","三重県","滋賀県","京都府","大阪府","兵庫県","奈良県","和歌山県",
                "鳥取県","島根県","岡山県","広島県","山口県","徳島県","香川県","愛媛県","高知県","福岡県","佐賀県",
                "長崎県","熊本県","大分県","宮崎県","鹿児島県","沖縄県"};
            if (check)
            {
                bool precheck = false;
                for(int i = 0; i < prefectures.Length; i++)
                {
                    if (inputs[3].Contains(prefectures[i])){
                        precheck = true;
                    }
                }
                if (!precheck)
                {
                    check = false;
                    return check;
                }
            }
            return check;
        }
        public bool ComCheck(string input)//コマンドについてのチェック
        {
            //コマンドのチェック
            bool check = true;
            if (input.Equals(":list"))//なくても良い
            {
                //check = true;
            }
            else if (input.Equals(":exit"))//なくても良い
            {
                //check = true;
            }
            else if (input.Contains(":delete"))//delete No
            {
                var inputs = input.Split(' ');
                if (inputs.Length != 2)
                {
                    check = false;
                    return check;
                }
                if (int.TryParse(inputs[1],out int num))
                {
                    if (!(num-1 <= datalist.Count))
                    {
                        check = false;
                        return check;
                    }
                }
                else
                {
                    check = false;
                    return check;
                }
            }
            else if (input.Contains(":sort"))
            {
                var inputs=input.Split(' ');
                if(inputs.Length != 2)
                {
                    check = false;
                    return check;
                }
                if (!(inputs[1].Equals("name") || inputs[1].Equals("age") || inputs[1].Equals("telno") || inputs[1].Equals("address")))
                {
                    check = false;
                    return check;
                }
            }
            else if (input.Contains(":save"))
            {
                var inputs = input.Split(' ');
                if(inputs.Length != 2)
                {
                    check = false;
                    return check;
                }
                if (!(inputs[1].Contains(".txt")))
                {
                    input.Concat(".txt");
                    return check;
                }
            }
            else if (input.Contains(":load"))
            {
                var inputs = input.Split(' ');
                if (inputs.Length != 2)
                {
                    check = false;
                    return check;
                }
                if (!(inputs[1].Contains(".txt")))
                {
                    input.Concat(".txt");
                }
            }
            else if (input.Equals(":help"))//なくても良い
            {
                //check = true;
            }
            else if (input.Equals(":clear"))//なくても良い
            {
                //check=true;
            }
            else if (input.Contains(":find"))
            {
                var inputs=input.Split(' ');
                if (inputs.Length != 3)
                {
                    check = false;
                    return check;
                }
                if (!(inputs[1].Equals("name") || inputs[1].Equals("age") || inputs[1].Equals("telno") || inputs[1].Equals("address")))
                {
                    check = false;
                    return check;
                }
                if (inputs[1].Equals("age"))
                {
                    if (!(int.TryParse(inputs[2],out int age)))
                    {
                        check=false;
                        return check;
                    }
                }
            }
            else
            {
                check = false;
            }

            return check;
        }
    }
    public class Data
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Telno { get; set; }
        public string Address { get; set; }
        public Data(string name,int age,string telno,string address)
        {
            this.Name = name;
            this.Age = age;
            this.Telno = telno;
            this.Address = address;
        }
    }
    //----------------------------------------------------

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
