## 加密算法效率对比

### 1、建立一个 .net core 的控制台项目

建立一个 .net core 的控制台项目，然后安装 nuget 包，BenchmarkDotnet

### 2、定义加密算法类HashHelper

```
public static class HashHelper
{
    public static string GetMD5(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        using (var md5 = MD5.Create())
        {
            var buffer = Encoding.UTF8.GetBytes(input);
            var hashResult = md5.ComputeHash(buffer);
            return BitConverter.ToString(hashResult).Replace("-", string.Empty);
        }
    }

    public static string GetSHA1(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        using (var sha1 = SHA1.Create())
        {
            var buffer = Encoding.UTF8.GetBytes(input);
            var hashResult = sha1.ComputeHash(buffer);
            return BitConverter.ToString(hashResult).Replace("-", string.Empty);
        }
    }
}
```

### 3、编写测试类

```
[MaxColumn][MinColumn][MemoryDiagnoser]

public class TestContext
{
    [Params("https://www.baidu.com/img/bd_logo1.png", "https://www.baidu.com/img/bd_logo2.png")]
    //Params可将参数带入测试方法中，每个参数都会进行测试

    public string Content { get; set; }

    [Benchmark]
    public void TestMD5()
    {
        HashHelper.GetMD5(Content);
    }

    [Benchmark]
    public void TestSHA1()
    {
        HashHelper.GetSHA1(Content);
    }
}
```

### 4、修改Mian方法

```
public class Program
{
    public static void Main(string[] args)
    {
        Summary summary = BenchmarkRunner.Run<TestContext>();
        Console.ReadLine();
    }
}
```

### 5、修改项目启动方式

最后将 Debug 调成 Release 模式，开始执行(不调试)方式启动。
