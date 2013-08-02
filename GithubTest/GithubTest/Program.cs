/*渣打编程马拉松Github测试题主程序*/
/*王晨，447648965@qq.com*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
namespace GithubTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentline;//当前从input.txt读取到的一整行
            string[] strarray;//以空格' '作为分隔符，将每一行拆分保存至该数组
            List<double> result=new List<double>();//保存计算结果
            double factor;//单位转换系数
            double multipler;//单位前乘的倍数
            Hashtable ht1 = new Hashtable();//用于记录单位转化规则
            Hashtable ht2 = new Hashtable();//用于记录单位名称单复数之间对应关系
            
            //将单位名称单复数的转换规则存入Hashtable表ht2
            ht2.Add("meters", "meter");
            ht2.Add("miles", "mile");
            ht2.Add("yards", "yard");
            ht2.Add("inches", "inch");
            ht2.Add("feet", "foot");
            ht2.Add("faths", "fath");
            ht2.Add("furlongs", "furlong");
            try
            {
                //设置读取input.txt的流
                FileStream inputFile = new FileStream("input.txt", FileMode.Open);
                StreamReader sr = new StreamReader(inputFile);
                //以下代码用于读取input的单位转换规则部分，并存入Hashtable表ht1
                currentline = sr.ReadLine();
                while (currentline != null && currentline != "")
                {
                    strarray = currentline.Trim().Split(' ');
                    ht1.Add(strarray[1], strarray[3]);
                    currentline = sr.ReadLine();
                }
                ht1.Add("meter", "1");
                //以下代码用于读取input中每一行的单位转换测试以及加减运算部分,并得到计算结果
                currentline = sr.ReadLine();
                while (currentline != null && currentline != "")
                {
                    double temp = 0;
                    strarray = currentline.Trim().Split(' ');//将当前行以空格为分隔符拆分成数组                
                    Console.WriteLine(currentline);
                    for (int i = 0; i < strarray.Length;)
                    {   
                        //遇到加号
                        if (strarray[i] == "+")
                        {
                            multipler = Convert.ToDouble(strarray[i + 1]);
                            //如果是单位的复数形式，还要先通过ht2进行转化，以在规则库中匹配查找转换系数
                            if (ht1[strarray[i + 2]] == null)
                            {
                                factor = Convert.ToDouble(ht1[ht2[strarray[i + 2]]]);
                            }
                            else
                            {
                                factor = Convert.ToDouble(ht1[strarray[i + 2]]);
                            }
                            temp += multipler * factor;
                            i += 3;
                        }
                        //遇到减号
                        else if (strarray[i] == "-")
                        {
                            multipler = Convert.ToDouble(strarray[i + 1]);
                            //如果是单位的复数形式，还要先通过ht2进行转化，以在规则库中匹配查找转换系数
                            if (ht1[strarray[i + 2]] == null)
                            {
                                factor = Convert.ToDouble(ht1[ht2[strarray[i + 2]]]);
                            }
                            else
                            {
                                factor = Convert.ToDouble(ht1[strarray[i + 2]]);
                            }
                            temp -= multipler * factor;
                            i += 3;
                        }
                        //无加减运算
                        else
                        {
                            multipler = Convert.ToDouble(strarray[i]);
                            //如果是单位的复数形式，还要先通过ht2进行转化，以在规则库中匹配查找转换系数
                            if (ht1[strarray[i + 1]] == null)
                            {
                                factor = Convert.ToDouble(ht1[ht2[strarray[i + 1]]]);
                            }
                            else
                            {
                                factor = Convert.ToDouble(ht1[strarray[i + 1]]);
                            }
                            temp += multipler * factor;
                            i += 2;
                        }
                    }
                    result.Add(temp);
                    Console.WriteLine("result:{0}",temp.ToString("0.00"));
                    Console.WriteLine();
                    currentline = sr.ReadLine();
                }
                sr.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //下面将结果输出到output.txt文件中
            try
            {
                //设置写入output.txt的流
                FileStream outputFile = new FileStream("output.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(outputFile);
                sw.WriteLine("447648965@qq.com");
                sw.WriteLine();
                foreach (double d in result)
                {
                    sw.WriteLine("{0} m",d.ToString("0.00"));
                }
                sw.Close();
            }
            catch (System.Exception ex)
            {
            	Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Finished !!!");
            Console.ReadKey();

        }
    }
}
