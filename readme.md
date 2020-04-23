# Lin.LogHelper

## 简介

一个简易的日志辅助类,不用任何配置,直接可用.日志保存到程序运行目录.
适用于工程已经开发到一半急需添加日志功能的情况下快速安装使用.

本库将Log分为4类:
以下按照 `紧急程度低` 到 `紧急程度高` 排序

| Type    | Description                                                                            | Method           |
| ------- | -------------------------------------------------------------------------------------- | ---------------- |
| Info    | 消息,通常输出运维人员可直接读懂的文本信息.                                             | LogForInfomation |
| Debug   | 调试信息,用于输出变量值等调试用的数据.                                                 | LogForDebug      |
| Warning | 警告,程序运行过程中,遇到小异常,不影响程序运行.对该类情况进行记录. | LogForWarning    |
| Error   | 程序错误,无法继续执行.                                                                 | LogForError      |

## 使用方法

nuget安装这个包之后,在需要使用扩展方法的文件里,引用如下命名空间:
```SHARP
using Lin.LogHelper;
```
### 文本日志

```SHARP
int a=10,b=5;
$"这是一个日志!".LogForInfomation();
$"a:{a} b:{b}".LogForDebug();
$"内存即将用完!CPU高温!".LogForWarning();
$"数据错误,程序无法继续执行!".LogForError();
```

### Byte[] 记入日志

有时候我们需要把一大块数据记录到log
这个库也可以记录Byte[],使用方法和文本差不多.
四个类都支持,但建议把Byte[]记录为Debug类.

```SHARP
var buff=new byte[]{0x00,0x12,0xAB};
buff.LogForDebug();
```

### Exception 记入日志

使用方法如上.只支持Error类

```SHARP
try
{
    string str = null;
    var len = str.Length;
}
catch (Exception err)
{
    err.LogForError();
}
```