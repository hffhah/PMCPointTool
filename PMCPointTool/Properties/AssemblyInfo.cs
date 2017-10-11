using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("PMCPointTool")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("PMCPointTool")]
[assembly: AssemblyCopyright("Copyright ©ZIHAOZHU  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("8f8320a0-cce5-48d9-add1-242170dd516d")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      生成号
//      修订号
//
// 可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.1.1011")]



/*
 * 
 * ----------------------------------------------------
 * 版本号：  1.0.1.1011
 * 更新日期：2017/10/11
 * 更新者：  zihao
 * 更新内容：
 *      1.TIP点新增TIP_VAL_CURRENT_CT点
 *      2.TIP资源名由_T改成__T
 *      3.修改点BD0003 N200地址的错误
 *      4.增加报警点--首地址是5和37的选项
 *      
 * ----------------------------------------------------
 * 版本号：  1.0.1.0930
 * 更新日期：2017/9/21
 * 更新者：  zihao
 * 更新内容：
 *      1.打开配置路径默认为上次打开的路径
 *      2.“关于”中Copyright内容修改
 *      3.支持读取配置文件station_alarm配置多个设备的报警明细了
 *      4.报警明细条目超过最大数量后,将提示导出点文件错误。
 *      5.修复当配置列超过指定列数后程序报错的BUG
 *      6.保存文件后打开文件夹为选中文件状态
 *      7.增加对配置文件表名的判断
 * 
 * ----------------------------------------------------
 * 版本号：  1.0.0
 * 更新日期：2017/9/20
 * 更新者：  zihao
 * 更新内容：
 *      1.AB 生成报警点
 *      2.AB 生成产量点（含TIP选项）
 *      3.AB 生辰非产量点
 *      4.SIEMENS 仅支持生成产量点、非产量点。
 *      
 * 
 * 
 * */
