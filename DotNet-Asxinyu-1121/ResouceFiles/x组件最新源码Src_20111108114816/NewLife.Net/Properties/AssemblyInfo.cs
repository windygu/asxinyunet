﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("网络库")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("新生命开发团队")]
[assembly: AssemblyProduct("NewLife.Net")]
[assembly: AssemblyCopyright("\x00a92002-2011 新生命开发团队")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("53d97538-79f2-49ac-890c-4cf4a0463946")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
// 可以指定所有这些值，也可以使用“内部版本号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.6.*")]
[assembly: AssemblyFileVersion("1.6.2011.0624")]

/*
 * v1.6.2011.0624   全面支持IPV6，并实现了隐式探测支持，只要用到IPV6的地址（本地和远程），就自动采用IPV6通信
 * 
 * v1.5.2011.0413   改善NetServer，不再作为抽象基类，通过指定协议类型可直接创建Tcp/Udp服务器
 *                  重写Echo服务器和数据流服务器，把Tcp/Udp的实现统一起来
 *                  实现另外四个简单网络服务器
 * 
 * v1.4.2010.1201   增加Socket数据流SocketStream
 *                  增加Tcp和Udp数据流网络服务
 * 
 * v1.3.2010.1107   使用SocketAsyncEventArgs重建网络模型
 *                  2010-11-16 调整完成，基本上满足万级连接下工作的要求，一万以上连接需要服务器拥有更多的处理器核心，硬件越强，程序工作越强！
 * 
 * v1.2.2010.0915   优化读写内存流ReadWriteStream，增加读写阻塞和超时、超大时自动压缩缓冲区的功能
 * 
 * v1.1.2010.0816   增加增强的TCP客户端TcpClientEx，使用内存流解决粘包问题
 * 
 * v1.0.2010.0803   创建网络库
 *
**/