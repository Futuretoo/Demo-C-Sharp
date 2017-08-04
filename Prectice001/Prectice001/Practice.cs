using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;

public class Practice
{
    private int age;
    //要定义私有和公有的两个变量，操作公有的属性会内部修改私有的属性
    //为了保护私有属性不暴露
    private string Name;
    public string name
    {
        //get、set访问器
        get
        {
            return this.Name;
        }
        set
        {
            //value是隐式参数
            if (value != null)
            {
                this.Name = value;
            }
            else
            {
                throw (new ArgumentNullException());
            }
        }
    }

    FolderBrowserDialog fd = new FolderBrowserDialog();

    [STAThreadAttribute]
    static void Main()
    {
        Practice a = new Practice();
        //a.matchDemo2();
        //a.cmdCheck_ScriptPlat();
        //a.matchDemo3();
        a.readENV();

        //InfoRunner info = new InfoRunner();
        //info.ReplaceString();


        Console.WriteLine("Done!");
        //让控制台可见，直到用户按下任意按键
        Console.ReadKey();
    }

    //获取Console输入
    public void echoName()
    {
        Console.WriteLine("please enter your name:");
        string message = "Welcome to you， " + Console.ReadLine();
        Console.WriteLine(message);
        Practice a = new Practice();
        a.name = "future";
        Console.WriteLine("a.Name is " + a.Name);
        a.boxing();
    }

    public void boxing()
    {
        int i = 10;
        object obj = i;
        i = 20;
        Console.WriteLine("obj = " + obj);
    }

    public void splitString(string str)
    {
        string[] strArray = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string a in strArray)
        {
            Console.WriteLine(a.Trim());
            if (a.Trim() == "1")
            {
                Console.WriteLine("match 1 !");
            }
        }
        Console.WriteLine(strArray.Length);
    }

    public void percent()
    {
        string a = "697";
        string b = "13115";
        Double num = 1 - (Double)Convert.ToInt32(a) / (Double)Convert.ToInt32(b);
        Double num2 = Math.Round(num, 4) * 100;
        Console.WriteLine(num2.ToString() + "%");
    }

    public void splitName()
    {
        string a = "C:\\Users\\wwx336515\\AppData\\Roaming\\eSpace_Desktop\\UserData\\wwx336515\\ReceiveFile\\InfoRunner手册\\dc_8090_cliref_en.chm";
        string path = a.Substring(0, a.LastIndexOf("\\"));
        string name = a.Substring(a.LastIndexOf("\\") + 1);
        Console.WriteLine("path = " + path);
        Console.WriteLine("name = " + name);
    }

    public void isExists()
    {
        string a = "";
        if (System.IO.Directory.Exists(a))
        {
            Console.WriteLine("\"\" is exists");
        }
        else
        {
            Console.WriteLine("\"\" is not exists");
        }
    }

    //命令行调用程序，打印返回
    public void cmdCheck_ScriptPlat()
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"D:\Code\工具小包\脚本管理平台\20170714_cmd\ScriptPlatForm.Ui.exe ");


            ////SDV
            //sb.Append("sdv ");
            //sb.Append("all ");
            //sb.Append(@"D:\Code\工具小包\脚本管理平台\20170714_cmd\用户自定义检查点.txt ");
            //sb.Append(@"C:\Users\wwx336515\AppData\Roaming\eSpace_Desktop\UserData\wwx336515\ReceiveFile\脚本检查用\CU_ACC11_0109 ");
            //sb.Append(@"C:\Users\wwx336515\Desktop\2");

            //ATN
            sb.Append("sdv ");
            sb.Append("all ");
            sb.Append(@"D:\Code\Tool-SVN\脚本管理平台_cmd\脚本管理平台\bin\Debug\用户自定义检查点.txt ");
            sb.Append(@"C:\Users\wwx336515\AppData\Roaming\eSpace_Desktop\UserData\wwx336515\ReceiveFile\脚本检查用\sunwei\NAT44411 ");
            sb.Append(@"C:\Users\wwx336515\Desktop\2");

            string checkInfo = sb.ToString();

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            //p.StartInfo.Arguments = runRubyPro;
            p.Start();
            #region
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(checkInfo + " &exit");

            //p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令



            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();

            Console.WriteLine(output);
            #endregion
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public void ifAifB(int a, int b)
    {
        if (a > 10)
        {
            if (b > 10)
            {
                Console.WriteLine("if A>10 if b>10");
            }
        }
    }
    public void ifAandifB(int a, int b)
    {
        if (a > 10 && b > 10)
        {
            Console.WriteLine("if A>10 and if b>10");
        }
    }


    public void split()
    {
        string remark = "{:tsu=>\"TESGINE_12_GEC\"}";
        string remarkTemp = remark.Substring(remark.IndexOf("\""), remark.LastIndexOf("\""));
        Console.WriteLine(remarkTemp);
    }

    //时间格式
    public void echoDate()
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); //大写的HH是24时制，小写的hh是12小时制
    }

    public void windowsSize()
    {
        if (fd.ShowDialog() == DialogResult.OK)
        {
            Console.WriteLine("OK");
        }
    }

    //用户自定义检查点.txt
    public void getConfigFile()
    {
        string userPoints = @"D:\Code\Tool-SVN\脚本管理平台_cmd\脚本管理平台\bin\Debug\用户自定义检查点.txt";
        List<string> sdvList = new List<string>();
        if (!File.Exists(userPoints))
        {
            Console.WriteLine("配置文件不存在！");
            return;
        }
        try
        {
            string filestring = "";
            using (StreamReader InitFileRead = new StreamReader(userPoints, Encoding.GetEncoding("UTF-8")))
            {
                filestring = InitFileRead.ReadToEnd();
            }
            if (!string.IsNullOrEmpty(filestring))
            {
                string[] strTemp = filestring.Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                //sdv
                string[] sdvArray = strTemp[1].Split(new char[] { ',', ' ', '=' }, System.StringSplitOptions.RemoveEmptyEntries);
                foreach (string checkPoint in sdvArray)
                {
                    if (checkPoint.Contains("_CheckPoint")) continue;
                    sdvList.Add(checkPoint);
                }
            }
            Console.WriteLine(sdvList);
        }
        catch (SystemException e)
        {
            Console.WriteLine("获取配置文件失败：" + e.Message);
        }
    }

    //模拟循环里面的异常
    public void tryCatch1()
    {
        string[] array1 = { "12a3", "asdasdas", "111111", "weerwaerwer", "asdaasd", "123", "asdfsdf" };
        try
        {
            foreach (string a in array1)
            {
                try
                {
                    int index = a.IndexOf("a");
                    int result = 5 / index;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("IN");
                    continue;
                }
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("OUT");
        }
    }

    //剔除因为大小写问题重复的本地脚本，同时输出重复的脚本
    public void removeRepeat()
    {
        Dictionary<string, List<string>> allScriptDict = new Dictionary<string, List<string>>();
        List<string> rScriptName = new List<string>();
        List<string> rScriptKey = new List<string>();
        //解析本地脚本
        List<string> lisScript = new List<string>();

        string[] itclFileArray = new string[] { "Aa1", "Aa2", "Aa3", "Aa4", "Aa5", "AA1", "aa1", "AA2", "aa2" };
        foreach (string tclfile in itclFileArray)
        {
            string tclfilename = tclfile.Trim().ToLower();
            if (allScriptDict.ContainsKey(tclfilename))
            {
                if (!rScriptKey.Contains(tclfilename))
                {
                    rScriptKey.Add(tclfilename);
                }
                allScriptDict[tclfilename].Add(tclfile);
                foreach (string name in allScriptDict[tclfilename])
                {
                    if (lisScript.Contains(name))
                    {
                        lisScript.Remove(name);
                    }
                }
                continue;
            }
            allScriptDict.Add(tclfilename, new List<string> { tclfile });
            lisScript.Add(tclfile);
        }
        if (rScriptKey.Count > 0)
        {
            foreach (string nameKey in rScriptKey)
            {
                foreach (string name in allScriptDict[nameKey])
                {
                    rScriptName.Add(name);
                }
            }
        }
        Console.WriteLine("remove done!");
    }

    //修改ip +1
    public void changeIP()
    {
        string ip = "192.168.1.1";
        try
        {
            string[] ipArray = ip.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            int trip = Convert.ToInt32(ipArray[3]) + 1;
            string newIP = ipArray[0] + "." + ipArray[1] + "." + ipArray[2] + "." + trip.ToString();
            Console.WriteLine(newIP);
        }
        catch (System.Exception ex)
        {

        }
    }

    public struct MapStruct
    {
        public string map;
        public List<string> newMapList;
        public List<string> addMapList;
    }
    //map约束的match
    public void matchDemo()
    {
        string newMap = "VNE9000";
        MapStruct ms = new MapStruct();
        ms.newMapList = new List<string>();
        ms.addMapList = new List<string>();

        MatchCollection mc = Regex.Matches(newMap.ToString(), @"\s*limit\s+", RegexOptions.IgnoreCase);
        int k = 0;
        while (k < mc.Count)
        {
            k++;
            if (k >= mc.Count)
            {
                ms.newMapList.Add(newMap.ToString().Substring(mc[k - 1].Index).Replace("\r", "").Replace("\n", ""));
                break;
            }
            else
            {
                ms.newMapList.Add(newMap.ToString().Substring(mc[k - 1].Index, mc[k].Index - mc[k - 1].Index).Replace("\r", "").Replace("\n", ""));
            }
        }
        if (mc.Count == 0)
        {
            ms.newMapList.Add(newMap.ToString());
        }
    }

    //获取目录下指定格式文件
    public void getDirectFiles()
    {
        string path = @"C:\Users\wwx336515\AppData\Roaming\eSpace_Desktop\UserData\wwx336515\ReceiveFile\Map约束刷新功能\tcl\script";
        bool a = Directory.GetFiles(path, "*.tcl").Length <= 0
                    || Directory.GetFiles(path, "*.topolimit").Length > 0;
        string[] files = Directory.GetFiles(path, "*.tcl");
    }

    //正则表达式匹配脚本名
    public void matchTestCase()
    {
        string[] testcases = { "RT_MBT_NAT444.BINDADRESSFUNC05.A83950.TC", 
                               "RT_CASE_CU_ACC.V10096.tc", 
                               "RT_MBT_IPOX_ACC.DelIntfListAndIntf-Func.B80003.tc" };

        string[] regs = { @"^rt_case(_story)?_[a-zA-Z0-9]+(_[a-zA-Z0-9-]+)*\.[A-Za-z0-9]?[0-9]{5}\.(t|T){1}(c|C){1}$",
                          @"^rt_mbt(_story)?_[a-zA-Z0-9]+(_[a-zA-Z0-9-]+)*\.[A-Za-z0-9]+\.[A-Za-z0-9]?[0-9]{5}\.(t|T){1}(c|C){1}$"};
        Regex CaseNameReg;
        foreach (string reg in regs)
        {
            CaseNameReg = new Regex(reg);
            foreach (string tcname in testcases)
            {
                if (CaseNameReg.IsMatch(tcname))
                {
                    Console.WriteLine("match: " + tcname);
                }
            }
            CaseNameReg = null;
        }
    }

    //读取ENV文件
    public void readENV()
    {
        try
        {
            string enxPath = "d:\\新建文件夹\\ip_hard_pipe\\ip_hard_pipe\\env\\1T_TSG_2DUT_5LINK_CIRCLE.enx";
            string enxName = enxPath.Substring(enxPath.LastIndexOf("\\")).Replace(".enx", "");
            string info = "";
            List<string> devList = new List<string>();

            using (StreamReader sr = new StreamReader(enxPath, Encoding.Default))
            {
                info = sr.ReadToEnd();
                sr.Close();
            }

            XmlDocument doc = new XmlDocument();
            //不要使用LoadXML方法，会出错
            //LoadXML只能读字符串友好
            //Load方法可以读文件，有重载
            doc.Load(enxPath);
            XmlNodeList nodeList = doc.DocumentElement.ChildNodes;
            //XmlNodeList nodeList = doc.SelectNodes("/devices/device");
            foreach (XmlNode xmlnode in nodeList)
            {
                string Pname = xmlnode.Name.Trim();
                if (Pname != "devices") continue;
                XmlNodeList snodeList = xmlnode.SelectNodes("device/parameters/parameter");
                foreach (XmlNode snode in snodeList)
                {
                    //<parameter name="name" value="tester" visible="false" description="LCM要求对象名称"/>
                    string snodeinfo = snode.OuterXml.ToString();
                    if (!snodeinfo.Contains("\"name\"")) continue;
                    string regex = "value\\s*=\\s*\"(?<devName>[\\s\\S]+?)\"";
                    Match devMatch = Regex.Match(snodeinfo, regex);
                    if (devMatch.Success)
                    {
                        string devName = devMatch.Groups["devName"].Value.ToString().Trim();
                        if (!string.IsNullOrEmpty(devName) && !devList.Contains(devName))
                        {
                            devList.Add(devName);
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {

        }
    }
}

