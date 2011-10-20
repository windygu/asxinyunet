using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("数据映射框架")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("新生命开发团队")]
[assembly: AssemblyProduct("XCode")]
[assembly: AssemblyCopyright("\x00a92002-2011 新生命开发团队")]
[assembly: AssemblyTrademark("四叶草")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: Dependency("NewLife.Core,", LoadHint.Always)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("fd577d2c-f8aa-4cc8-a697-d7990c264af3")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
// 可以指定所有这些值，也可以使用“修订号”和“内部版本号”的默认值，
// 方法是按如下所示使用“*”:
[assembly: AssemblyVersion("8.0.*")]
[assembly: AssemblyFileVersion("8.0.2011.0929")]

/*
 * XCode的重大改进
 * 
 * v8.0 标准化开放的接口，增强定制能力
 * v7.0 增强数据库架构的支持，支持更多数据库
 * v6.0 增强的缓存和扩展属性支持
 * v5.0 弱类型支持
 * v4.0 实体集合和缓存
 * v3.0 增加ORM的各种细节支持
 * v2.0 数据架构功能，实体和数据结构双向映射
 * v1.2 使用泛型基类
 * v1.0 创建XCode
 * /

/*
 * v8.0.2011.0929   修正IDataTable.Fix中对一对一关系处理的不足
 *                  修改Entity，根据唯一索引查询单对象时不加分页和排序，这使得在SQLite上特别是MySql上有性能提升
 * 
 * v8.0.2011.0917   给索引和关系模型增加Computed属性，标识是计算出来还是数据库内置的
 * 
 * v8.0.2011.0912   重构反向工程，废除DatabaseSchema类（旧版本的反向工程核心），将其功能合理分配到各个地方，兼容各种数据库在反向时的差异
 *                  增加ModelCheckModeAttribute特性，可用于控制实体类是在初始化连接时还是第一次使用该实体类的数据表时检查模型（反向工程）
 * 
 * v8.0.2011.0911   完善模型的模型特性，便于代码生成器中的模型管理
 * 
 * v8.0.2011.0910   数据层使用全新的接口IDataTable、IDataColumn、IDataIndex、IDataRelation
 *                  尝试使用服务提供者，外部可替代内部各接口实现
 *                  数据层/实体层、正向/反向工程 增加索引支持，在部署到生成环境时同步创建索引，保证系统最佳性能
 *                  丰富实体类的添删改查，增加多种常见页面用法
 *                  重点：把数据库=>实体类+页面的用法，改为模型+模版=>数据库+实体类+页面的使用方式，扩大数据架构的表现能力，全力支持魔方平台
 * 
 * v7.16.2011.0803  修正MSSQL中创建数据库指定文件位置时出错的BUG
 *                  增加设置项SQLPath，允许把SQL日志写入到单独的SQL日志中
 * 
 * v7.15.2011.0725  修正EntityFactory中创建实体操作者可能出现的BUG，解决非泛型继承的问题，如Admin=>Administrator=>Administrator<Administrator>
 * 
 * v7.14.2011.0723  增加实体缓存接口IEntityCache和单对象缓存接口ISingleEntityCache
 *                  IEntityOperate增加缓存等操作支持
 * 
 * v7.13.2011.0622  优化SQLite，如果外部不指定缓存大小等参数，则自动使用最高性能的参数
 * 
 * v7.12.2011.0614  SQLite增加对内存数据库的支持，数据源设置为:memory:或者空，即表示使用内存数据库
 * 
 * v7.11.2011.0613  修正v7.8.2011.0510中修改时遗留下来的问题，一个是SQLite.DropColumnSQL中把两个参数写反了，一个是DatabaseSchema中，如果先增加字段后删除字段会出错
 * 
 * v7.11.2011.0612  修正v7.10.2011.0608中修改时遗留下的问题，完整实现最大最小值分页，同时发现TopNotIn分页和MaxMin分页无法完美的支持GroupBy查询分页，只能查到第一页
 * 
 * v7.11.2011.0611  修正v7.10.2011.0608中修改时遗留下的问题，获取列表时默认使用自增字段降序，根据主键获取单记录的方法绕过此处，免受影响
 *                  非常重要：修改EntityBase，给实体类数据属性赋值时，如果新旧值相等，不影响脏数据，剐需要影响脏数据，请使用SetItem
 * 
 * v7.11.2011.0610  修改DbBase，对于需要外部提供者的数据库类型，在没有提供者程序集时，自动从网络上下载，等待3秒
 * 
 * v7.10.2011.0608  Entity中自增或者主键查询，记录集肯定是唯一的，不需要指定记录数和排序
 * 
 * v7.9.2011.0603   实体类增加三个根据实体缓存查找数据的方法，方便ObjectDataSource绑定
 * 
 * v7.9.2011.0602   修正EntityTree中的排序错误，增加升降排序方法，支持同级升降排序
 * 
 * v7.9.2011.0529   实体类添删改拆分两部分，OnInsert/OnUpdate/Delete作为操作数据的真实操作，Insert/Update/Delete作为调用者，配合以数据验证和事务保护
 *                  增加数据验证Valid，实体类可以重载，以实现Insert/Update前验证数据，将来可能根据数据字段特性进行自动化验证。
 *                  增加数据存在判断Exist，开发者可根据需要调用，建议用于业务主键的存在性判断。CheckExist可以在判断后抛出异常。
 * 
 * v7.9.2011.0526   重构XCode实体层元数据部分，使用公开的TableItem替代保护的XCodeConfig，配合FieldItem形成完成的实体元数据结构
 *                  使用专用类实现IEntityOperator接口，避免原来臃肿的结构
 * 
 * v7.8.2011.0512   更新SelectBuilder，更新QueryCount相关代码，保证生成最精简的QueryCount查询语句，对于MySql而言，避开子查询，有巨大的性能优势
 * 
 * v7.8.2011.0510   增强SQLite的反向工程能力，SQLite不支持修改字段和删除字段，但是可以通过新建表然后复制数据的方式替代，并且解决了新增不允许空且又没有默认值的字段时出错的问题
 * 
 * v7.7.2011.0429   修正Access创建表时不应该同时操作默认值的错误
 * 
 * v7.6.2011.0420   修正XCode中反向工程模块判断是否普通实体类的错误
 * 
 * v7.6.2011.0409   重新启用实体类的ToData，允许实体数据转化为DataRow
 *                  EntityList增加ToDataTable和ToDataSet等方法，允许实体集合转为数据集，并通过事件把数据集的添删改操作委托到实体操作
 *                  一级缓存默认设置改为请求级缓存，避免在Web项目中因不正当使用查询而带来的性能损耗
 * 
 * v7.5.2011.0403   修正XField中Xml序列化的问题
 * 
 * v7.5.2011.0401   增加Json支持
 * 
 * v7.4.2011.0331   实体类Insert后清空脏数据，避免连续两次Save变成一次Insert和一次Update
 *                  修正实现组件模型接口中的一些问题，测试通过，基本上满足WinForm开发要求
 * 
 * v7.4.2011.0330   修正3月23号更新SqlServer时带来的另一个错误——无法创建自增字段；同时增加了把原字段设置为自增字段的功能，先删后加！
 * 
 * v7.4.2011.0329   修正动态生成代码时属性名与类型重名导致编译出错的问题
 *                  XTable和XField实现克隆接口
 *                  EntityBase实现INotifyPropertyChanging, INotifyPropertyChanged, ICustomTypeDescriptor, IEditableObject接口
 *                  EntityList实现ITypedList, IBindingList, IBindingListView, ICancelAddNew接口
 * 
 * v7.4.2011.0325   Entity所有基类标识为可序列化
 * 
 * v7.4.2011.0323   修改反向工程，当多个实体类使用同一数据表时，优先使用非通用实体类
 *                  修改SqlServer提供者，支持修改字段的主键属性
 * 
 * v7.4.2011.0321   EntityList增加Join方法，串联指定成员，方便由实体集合构造用于查询的子字符串
 *                  进行异步数据初始化时，如果内部遇到其它数据初始化，则在当前线程进行处理，保证数据初始化的同步进行，保证某些业务数据的初始化安装预定顺序进行。
 * 
 * v7.4.2011.0318   实体缓存增加是否允许空的设置，如果不允许空则即使缓存未过期也进行数据刷新
 *                  稍微优化实体缓存和单对象缓存，提升性能
 *                  计划加强各个缓存，特别是单对象缓存，利用维护线程删除过期缓存项，也可能借助System.Web.Caching.Cache
 * 
 * v7.3.2011.0314   修正实体基类静态构造函数的死锁问题，感谢邱鹏发现该问题！
 * 
 * v7.3.2011.0313   扩展EntityTree，增加Contains、ChildKeys、ChildKeyString、AllChildKeys、AllChildKeyString
 *                  修改EntityBase，GetExtend方法增加是否缓存默认值的选项，使用者可以选择在取不到数据时是否缓存代表空的默认值
 *                  修改EntityTree的Root属性，不缓存空值，大多数情况下，树形结构的数据都不应该为空
 * 
 * v7.3.2011.0311   修正非MS数据库的分页错误
 * 
 * v7.3.2011.0310   修正判断保留字时使用泛型List导致性能低下的BUG，改为Dictionary
 * 
 * v7.3.2011.0307   增加对Firebird和PostgreSQL的支持，未完全测试通过
 * 
 * v7.2.2011.0303   实体操作接口增加InitData方法，实体类可以重载，用于在第一次使用数据库时初始化数据
 * 
 * v7.1.2011.0228   MSSQL中使用架构信息判断数据库和数据表是否存在，避免某些情况下没有权限使用系统视图而出错
 *                  IDatabase接口增加保留字和FormatName方法，只有关键字才进行格式化
 * 
 * v7.1.2011.0224   调整方法InsertAndGetIdentity
 *                  SQLite中去掉读写锁，改为写入时判断数据库是否锁定，如果已锁定则重试
 * 
 * v7.1.2011.0223   调整Oracle的数据架构功能
 *                  Oracle增加快速查找表记录数方法
 *                  XField调整，规范化长度、字节数、精度和位数
 * 
 * v7.1.2011.0222   SQLite使用完整读写锁，避免读取时有写入操作然后报文件锁定
 *                  SQLite写入操作允许重试两次，以解决高并发时文件锁定的小概率事件
 *                  修改数据库架构，在获取数据库是否存在出现异常时，默认数据库已存在，因为一般来说都是没有管理员权限造成的错误，并且大多数时候数据库都是存在的
 *                  修改DAL的构造函数，检查数据库架构的异常不应该影响DAL的正常使用
 * 
 * v7.1.2011.0215   热心网友 Hannibal 在处理日文网站时发现插入的日文为乱码（MSSQL），这里加上N前缀，同时给时间日期加上ts前缀
 *                  SQLite数据库处理字节数组时，加上X前缀
 *                  把实体类中的SQL方法，设为共有，便于外部获取SQL语句
 * 
 * v7.1.2011.0212   增加网络数据库提供者Network，把各种操作直接路由给远端
 *                  增加分布式数据库提供者Distributed，同时读写多个数据库
 *                  设计方案最佳实践：
 *                  1，使用MySql自身的集群，一主多从，XCode配置使用分布式提供者，更新写入主库，从各从库读取数据，实现负载均衡
 *                  2，使用网络数据库提供者实现路由中转，实现故障转移
 * 
 * v7.0.2011.0201   重写数据访问层，便于功能扩展
 *                  重写数据架构（反向工程），完善SQLite和MySql的反向工程支持
 * 
 * v6.6.2010.1230   修改XCode类型映射模型，统一使用Schema信息，不再人为指定类型映射，全部交由数据库提供者处理
 *                  由C#类型反向到数据类型的映射尚未完成
 * 
 * v6.5.2010.1223   修正SQLite已知的一些问题，查找dll文件路径不正确，执行插入语句不正确
 *                  IEntity增加CopyFrom方法，用于从指定实体对象复制成员数据
 *                  增加对二进制字段的支持，表现为Byte[]
 * 
 * v6.4.2010.1217   修正Entity中CheckColumn无法正确计算选择字段的错误
 *                  优化SelectBuilder，允许Where中使用GroupBy字句，ToString时自动分割到正确位置
 *                  实体类增加静态方法FindByKeyForEdit，用于替代模版生成中的FindByKeyForEdit，为将要实现的表单基类（自定义表单）做准备
 *                  ********************************
 *                  实体基类继承自BinaryAccessor，IEntity增加IIndexAccessor接口和IBinaryAccessor接口，增加对快速索引访问和二进制访问的支持
 *                  快速索引访问：实体类可以不必生成索引器代码，IIndexAccessor直接提供按名称访问属性
 *                  二进制访问：支持把实体对象序列化成二进制或者反向操作
 *                  这两个功能尚未经过严格测试，请不要用于正式系统使用！
 * 
 * v6.3.2010.1209   修正实体工厂EntityFactory缓存实体导致无法识别后加载实体程序集的错误
 * 
 * v6.2.2010.1202   SQLite增加读写锁，限制同时只能指定一个Excute操作
 *                  Entity的PageSplitSQL方法修正表名没有进行格式化的BUG
 * 
 * v6.1.2010.1119   取消依赖XLog，升级为依赖NewLife.Core，部分公共类库移植到NewLife.Core
 *                  修正EntityTree中FindChilds错误，增加排序字段的支持，如果指定排序字段，查询子级的时候将按排序字段降序排序
 *                  取消授权限制，但仍然混淆代码
 * 
 * v6.0.2010.1021   增加字典缓存DictionaryCache
 *                  增加弱引用泛型WeakReference<T>
 *                  单对象实体缓存改为弱引用，使得缓存对象在没有引用时得到回收
 *                  单对象实体缓存默认填充方法改为实体基类的FindByKey（前面某个版本增加，参数为Object），据说Delegate.CreateDelegate出来的委托会很慢
 *                  实体元数据类Meta增加单对象实体缓存SingleCache，给SingleCacheInt和SingleCacheStr加上过期标识，到v7.0将不再支持
 *                  实体元数据类Meta增加OnDataChange的数据改变事件，并使用弱引用，当该实体有数据改变后，触发事件，可用于在外部清楚该对象的缓存
 *                  （重要更新）实体基类增加字典缓存Extends，用于存储扩展属性，并增加专属的GetExtend方法用于获取扩展属性，向依赖实体类注册数据更改事件
 *                  （重要更新）实体树类升级为实体树基类，所有具有树形结构数据的实体类，继承自该类，享受树形实体的各种功能
 *                  实体基类增加虚拟的CreateXmlSerializer，允许实体类重载以改变Xml序列化行为，默认序列化行为改为序列化为特性
 *                  EntityList改变序列化行为，默认序列化为特性
 *                  EntityList判断元素是否存在Contains方法改为Exists
 *                  EntityList增加多字段排序方法Sort，可用于多个字段排序
 *                  修复快速访问方法、属性和字段所存在的问题，在实体基类索引器使用
 * 
 * v5.9.2010.1020   修正Database中QueryCountFast的严重错误
 * 
 * v5.8.2010.1018   增加实体树接口IEntityTree，用于解决实体树操作的一些共性问题，避免死循环
 * 
 * v5.7.2010.0930   XField中增加一个Table属性指向自己的XTable，创建XField时必须指定所属XTable
 *                  增加只读列表，各配置项使用只读列表返回，配置项自身检测列表是否被修改
 *                  实体操作接口增加Fields和FieldNames属性
 * 
 * v5.6.2010.0909   修改DAL，把QueryTimes和ExecuteTimes改为本线程的查询次数和执行次数
 *                  修改Entity，Meta.Count返回表的总记录数（快速），FindCount()使用普通方法查询真实记录数
 * 
 * v5.5.2010.0903   实体操作接口IEntityOperate返回的实体集合改为EntityList<IEntity>，因为使用操作接口时一般不知道具体类型，如果知道就没必要使用操作接口
 *                  增加数据连接名映射的配置，允许通过配置修改某一个实体或者某一个连接名实际对应的连接名
 *                  修改实体缓存和单对象缓存，使得缓存的数据因连接名或表名不同而不同，避免不同连接名或表名时缓存串号的问题
 *                  修改实体类结构模型，比如Area:Area<Area>:Entity<Area>，使得实体类可以通过继承实现二次扩展
 * 
 * v5.4.2010.0830   数据架构中的异步检查BeginCheck当启用检查时改为同步检查Check，保证数据库操作前先完成一次数据架构检查
 *                  唯一键为自增且参数小于等于0时，返回空
 *                  实体操作接口IEntityOperate增加ToList方法，实现把ICollection转为List<IEntity>
 *                  优化Entity的FindAll方法，处理海量数据尾页查询时使用优化算法
 * 
 * v5.3.2010.0826   DAL增加CreateOperate方法，为数据表动态创建实体类操作接口，支持在没有实体类的情况下操作数据库
 *                  该版本为不稳定版本
 * 
 * v5.2.2010.0726   IEntity接口增加SetItem方法，提供影响脏数据的弱类型数据设置
 *                  IEntityOperate接口增加Create方法，提供创建被类型实体对象的功能
 * 
 * v5.1.2010.0709   增加实体接口、实体操作接口、实体基类的基类，提供弱类型的Orm支持
 * 
 * v5.0.2010.0625   DAL优化
 *                  重新启用授权管理
 *                  EntityList增加排序方法Sort
 * 
 * v4.9.2010.0430   使用SelectBuilder来构造SQL语句，用于各层之间传递，准备将所有方法往SelectBuilder过度。该更新可能造成使用GroupBy的地方计算出错
 * 
 * v4.8.2010.0325   修改Entity索引器，新的快速调用方法在set的时候有问题
 *                  增加常用查询方法为Web方法
 * 
 * v4.8.2010.0301   增加实体类多表支持和多数据库支持
 *                  暴露几个常用的实体类静态方法供WebService引用
 * 
 * v4.7.2010.0130   数据架构中识别表名时不应该区分大小写
 *                  Entity中增加MakeCondition方法，以便于构造where语句
 * 
 * v4.6.2009.1226   改善分页算法，产生更简单的分页语句
 * 
 * v4.5.2009.1127   增加单实体缓存
 * 
 * v4.4.2009.1125   修改二级缓存，Entities改为EntityList类型，非空，支持FindAll操作
 * 
 * v4.3.2009.1121   修正Entity中Save方法判断自增字段不准确的BUG
 * 
 * v4.2.2009.1114   优化SqlServer取架构信息的性能，以及输出的SQL的可读性
 *                  支持Sql2008，通过Sql2005类
 *                  优化QueryCount方法，产生更简短的SQL
 * 
 * v4.1.2009.1028   增加快速获取单表总记录数方法QueryCountFast，修改Entity，在记录数大于1000时自动使用快速取总记录数
 * 
 * v4.0.2009.1011   增加实体类集合EntityList，Entity的所有FindAll返回EntityList
 *                  增强数据架构功能，支持Access、SQL2000、SQL2005
 * 
 * v3.7.2009.0907   修正DatabaseSchema中的一个小错误
 * 
 * v3.6.2009.0819   修正FindCount方法的错误
 * 
 * v3.5.2009.0714   Config类输出的FieldItem集合改为数组，防止被外部修改。
 *                  所有Select语句，使用*表示所有列，而不是列出所有列名。
 * 
 * v3.4.2009.0701   修正SqlServer 2000取主键的错误
 * 
 * v3.3.2009.0628   修改DAL，屏蔽Web请求级缓存DB的方法，似乎Web下多线程很不稳定，从而导致事务无法正常使用。
 * 
 * v3.2.2009.0623   修改Oracle，重载GetTables方法，修正无法从Oracle数据库取得构架信息的错误
 * 
 * v3.1.2009.0611   修改SqlServer类，使得每次返回构架信息时，都是从数据库取值。
 * 
 * v3.0.2009.0608   元数据类Meta增加一个字段名列表属性FieldNames
 *                  调整DatabaseSchema类，新增字段时，直接设置默认值，否则对于非空字段，创建字段将会失败
 *                  数据构架增加DatabaseSchema_Exclude配置项，用于指定要排除检查的链接名。
 *                  Entity中，增加ToXml输出的Xml的编码为UTF8，增加FromXml反序列化，增加Clone方法和CloneEntity方法
 *                  Database中，增加事务计数字段，支持多级事务。
 *                  Entity中，集合运算返回值改为List<T>，而不是IList<T>，更方便调用
 *                  在Database的QueryCount方法增加自动去除排序子句的功能
 *                  Entity中，增加ToString重载，默认显示Name属性
 *                  Entity中，Update时，增加了脏数据的判断，非脏数据的字段不更新，由于该功能的增加将导致以前所有的实体都无法Update到数据库，故版本改为3.0
 * 
 * v2.3.2009.0530   修正非自增字段做主键时也调用InsertAndGetIdentity的错误。
 * 
 * v2.2.2009.0527   数据表结构中，增加Int16和Int64两种类型
 * 
 * v2.1.2009.0408   修正DAL中_DBs空引用的问题，可能是因为该成员是线程静态，并没有在每一个线程上new一个对象。
 * 
 * v2.0.2009.0408   增加数据架构的功能。数据架构可以实现通过实体类反向更新数据库结构，不启用时，仅把更新SQL写入日志
 *                  修正Access类使用当前目录时拼接路径的错误。
 *                  
 * v1.2.2008.01.01  使用泛型基类重构
 * 
 * v1.1.2007.03.08  大量扩展功能，支持自定义表单、广义单点登录等项目
 *                  完善对Oracle的支持，支持电力生产管理系统等项目
 *                  完善对Sybase的支持，支持电力SCADA数据分析等项目
 * 
 * v1.0.2005.10.01  创建项目
 *                  支持C++客户端网络验证系统等项目
 *                  支持图片验证码识别等项目
*/