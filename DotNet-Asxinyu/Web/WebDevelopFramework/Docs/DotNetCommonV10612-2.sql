-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.1.35-community


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema CommonV1
--

CREATE DATABASE IF NOT EXISTS CommonV1;
USE CommonV1;

--
-- Definition of table `Log`
--

DROP TABLE IF EXISTS `Log`;
CREATE TABLE `Log` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `DbName` varchar(20) NOT NULL COMMENT '数据库名称',
  `TableName` varchar(30) NOT NULL COMMENT '表名称',
  `UserId` int(11) NOT NULL COMMENT '用户编号',
  `Category` varchar(30) NOT NULL COMMENT '日志类别',
  `Action` varchar(80) DEFAULT NULL COMMENT '操作行为',
  `Content` varchar(200) DEFAULT NULL COMMENT '操作内容',
  `OccurTime` datetime DEFAULT NULL COMMENT '发生时间',
  PRIMARY KEY (`Id`),
  KEY `UserId` (`UserId`),
  KEY `TableName` (`TableName`),
  KEY `DbName` (`DbName`) USING BTREE,
  KEY `Category` (`Category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='日志信息';

--
-- Dumping data for table `Log`
--

/*!40000 ALTER TABLE `Log` DISABLE KEYS */;
/*!40000 ALTER TABLE `Log` ENABLE KEYS */;


--
-- Definition of table `Menu`
--

DROP TABLE IF EXISTS `Menu`;
CREATE TABLE `Menu` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `ParentId` int(11) NOT NULL COMMENT '父编号',
  `DbName` varchar(20) NOT NULL COMMENT '数据库名称',
  `TableName` varchar(30) NOT NULL COMMENT '表名称',
  `MenuName` varchar(50) NOT NULL COMMENT '菜单名称',
  `Url` varchar(100) DEFAULT NULL COMMENT '链接',
  `IconsUrl` varchar(100) DEFAULT NULL COMMENT ' 图标链接',
  `SortCode` int(11) DEFAULT '9999' COMMENT '排序码',
  `IsEnable` tinyint(4) NOT NULL DEFAULT '1' COMMENT '是否有效',
  `Description` varchar(50) DEFAULT '' COMMENT '备注',
  PRIMARY KEY (`Id`),
  KEY `MenuName` (`MenuName`) USING BTREE,
  KEY `DbName` (`DbName`),
  KEY `TableName` (`TableName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='菜单表';

--
-- Dumping data for table `Menu`
--

/*!40000 ALTER TABLE `Menu` DISABLE KEYS */;
/*!40000 ALTER TABLE `Menu` ENABLE KEYS */;


--
-- Definition of table `Organize`
--

DROP TABLE IF EXISTS `Organize`;
CREATE TABLE `Organize` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `ParentId` int(11) NOT NULL COMMENT '父编号',
  `OrganizeCode` varchar(50) DEFAULT NULL COMMENT '组织代码',
  `ShortName` varchar(50) DEFAULT NULL COMMENT '简称',
  `FullName` varchar(100) DEFAULT NULL COMMENT '组织名称',
  `Category` varchar(30) DEFAULT NULL COMMENT '组织类别',
  `SortCode` int(11) DEFAULT '9999' COMMENT '排序码',
  `Description` varchar(50) DEFAULT '' COMMENT '备注',
  PRIMARY KEY (`Id`),
  KEY `OrganizeCode` (`OrganizeCode`) USING BTREE,
  KEY `ShortName` (`ShortName`) USING BTREE,
  KEY `FullName` (`FullName`) USING BTREE,
  KEY `ParentId` (`ParentId`),
  KEY `Category` (`Category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='组织部门信息表';

--
-- Dumping data for table `Organize`
--

/*!40000 ALTER TABLE `Organize` DISABLE KEYS */;
/*!40000 ALTER TABLE `Organize` ENABLE KEYS */;


--
-- Definition of table `Permission`
--

DROP TABLE IF EXISTS `Permission`;
CREATE TABLE `Permission` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `ParentId` int(11) NOT NULL COMMENT '父编号',
  `DbName` varchar(20) DEFAULT NULL COMMENT '数据库名称',
  `TableName` varchar(30) DEFAULT NULL COMMENT '表名',
  `Name` varchar(30) NOT NULL COMMENT '权限名称',
  `IsDataPermission` tinyint(4) DEFAULT '0' COMMENT '是否开启数据权限',
  `Constraint` varchar(100) DEFAULT NULL COMMENT '数据条件',
  `SortCode` int(11) DEFAULT '9999' COMMENT '排序码',
  `IsEnable` tinyint(4) NOT NULL DEFAULT '1' COMMENT '是否有效',
  `DeletionStatusCode` tinyint(4) NOT NULL DEFAULT '0' COMMENT '删除状态',
  `Description` varchar(50) DEFAULT '' COMMENT '备注',
  PRIMARY KEY (`Id`),
  KEY `Name` (`Name`) USING BTREE,
  KEY `DbName` (`DbName`),
  KEY `TableName` (`TableName`),
  KEY `ParentId` (`ParentId`),
  KEY `DbTable` (`DbName`,`TableName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='权限表';

--
-- Dumping data for table `Permission`
--

/*!40000 ALTER TABLE `Permission` DISABLE KEYS */;
/*!40000 ALTER TABLE `Permission` ENABLE KEYS */;


--
-- Definition of table `Role`
--

DROP TABLE IF EXISTS `Role`;
CREATE TABLE `Role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `RoleName` varchar(20) NOT NULL DEFAULT '' COMMENT '角色名称',
  `Category` varchar(30) DEFAULT '' COMMENT '角色分类',
  `SortCode` int(11) DEFAULT '9999' COMMENT '排序码',
  `IsEnable` tinyint(4) NOT NULL DEFAULT '1' COMMENT '是否有效',
  `Description` varchar(50) DEFAULT '' COMMENT '备注',
  PRIMARY KEY (`Id`),
  KEY `RoleName` (`RoleName`),
  KEY `Category` (`Category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='角色表';

--
-- Dumping data for table `Role`
--

/*!40000 ALTER TABLE `Role` DISABLE KEYS */;
/*!40000 ALTER TABLE `Role` ENABLE KEYS */;


--
-- Definition of table `RolePermission`
--

DROP TABLE IF EXISTS `RolePermission`;
CREATE TABLE `RolePermission` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `RoleId` int(11) NOT NULL COMMENT '角色编号',
  `PermissionId` int(11) NOT NULL COMMENT '权限编号',
  `IsEnable` tinyint(4) NOT NULL DEFAULT '1' COMMENT '是否有效',
  PRIMARY KEY (`Id`),
  KEY `RolePermission` (`RoleId`,`PermissionId`) USING BTREE,
  KEY `RoleId` (`RoleId`),
  KEY `PermissionId` (`PermissionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='角色权限表';

--
-- Dumping data for table `RolePermission`
--

/*!40000 ALTER TABLE `RolePermission` DISABLE KEYS */;
/*!40000 ALTER TABLE `RolePermission` ENABLE KEYS */;


--
-- Definition of table `Setting`
--

DROP TABLE IF EXISTS `Setting`;
CREATE TABLE `Setting` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `ParentId` int(11) NOT NULL COMMENT '父编号',
  `Name` varchar(50) NOT NULL COMMENT '名称',
  `Value` varchar(100) DEFAULT '' COMMENT '值',
  `SortCode` int(11) DEFAULT '9999' COMMENT '排序码',
  `Description` varchar(50) DEFAULT '' COMMENT '描述',
  PRIMARY KEY (`Id`),
  KEY `Name` (`Name`) USING BTREE,
  KEY `ParentId` (`ParentId`),
  KEY `Description` (`Description`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统设置表';

--
-- Dumping data for table `Setting`
--

/*!40000 ALTER TABLE `Setting` DISABLE KEYS */;
/*!40000 ALTER TABLE `Setting` ENABLE KEYS */;


--
-- Definition of table `Staff`
--

DROP TABLE IF EXISTS `Staff`;
CREATE TABLE `Staff` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `UserId` int(11) DEFAULT NULL COMMENT '用户编号',
  `OrganizeId` int(11) NOT NULL COMMENT '组织编号',
  `UserName` varchar(50) NOT NULL COMMENT '用户名',
  `RealName` varchar(30) NOT NULL COMMENT '姓名',
  `Code` varchar(50) DEFAULT NULL COMMENT '工号',
  `Sex` tinyint(4) NOT NULL COMMENT '性别',
  `IdCard` varchar(30) DEFAULT '' COMMENT '身份证号',
  `SortCode` int(10) DEFAULT NULL COMMENT '排序码',
  `IsEnable` tinyint(4) DEFAULT '1' COMMENT '是否有效',
  `Description` varchar(50) DEFAULT '' COMMENT '备注',
  PRIMARY KEY (`Id`),
  KEY `OrganizeId` (`OrganizeId`) USING BTREE,
  KEY `UserName` (`UserName`) USING BTREE,
  KEY `Code` (`Code`) USING BTREE,
  KEY `IdCard` (`IdCard`) USING BTREE,
  KEY `UserId` (`UserId`),
  KEY `RealName` (`RealName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='员工信息表';

--
-- Dumping data for table `Staff`
--

/*!40000 ALTER TABLE `Staff` DISABLE KEYS */;
/*!40000 ALTER TABLE `Staff` ENABLE KEYS */;


--
-- Definition of table `User`
--

DROP TABLE IF EXISTS `User`;
CREATE TABLE `User` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `UserName` varchar(30) NOT NULL COMMENT '用户名',
  `Password` varchar(50) NOT NULL COMMENT '密码',
  `SortCode` int(10) DEFAULT NULL COMMENT '排序码',
  `IsEnable` tinyint(4) DEFAULT '1' COMMENT '是否有效',
  PRIMARY KEY (`Id`),
  KEY `UserName` (`UserName`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户信息';

--
-- Dumping data for table `User`
--

/*!40000 ALTER TABLE `User` DISABLE KEYS */;
/*!40000 ALTER TABLE `User` ENABLE KEYS */;


--
-- Definition of table `UserPermission`
--

DROP TABLE IF EXISTS `UserPermission`;
CREATE TABLE `UserPermission` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `PermissionId` int(11) NOT NULL COMMENT '权限编号',
  `UserId` int(11) NOT NULL COMMENT '用户编号',
  `IsEnable` tinyint(4) NOT NULL DEFAULT '1' COMMENT '是否有效',
  PRIMARY KEY (`Id`),
  KEY `UserPermission` (`PermissionId`,`UserId`) USING BTREE,
  KEY `UserId` (`UserId`),
  KEY `PermissionId` (`PermissionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户权限表';

--
-- Dumping data for table `UserPermission`
--

/*!40000 ALTER TABLE `UserPermission` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserPermission` ENABLE KEYS */;


--
-- Definition of table `UserProfile`
--

DROP TABLE IF EXISTS `UserProfile`;
CREATE TABLE `UserProfile` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `UserId` int(11) NOT NULL COMMENT '用户编号',
  `Name` varchar(50) NOT NULL COMMENT '名称',
  `Value` varchar(100) DEFAULT '' COMMENT '值',
  `SortCode` int(11) DEFAULT '9999' COMMENT '排序码',
  `IsEnable` tinyint(4) NOT NULL DEFAULT '1' COMMENT '是否有效',
  `Description` varchar(50) DEFAULT '' COMMENT '描述',
  PRIMARY KEY (`Id`),
  KEY `UserId` (`UserId`),
  KEY `Name` (`UserId`,`Name`),
  KEY `Description` (`Description`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户配置信息表';

--
-- Dumping data for table `UserProfile`
--

/*!40000 ALTER TABLE `UserProfile` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserProfile` ENABLE KEYS */;


--
-- Definition of table `UserRole`
--

DROP TABLE IF EXISTS `UserRole`;
CREATE TABLE `UserRole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `UserId` int(11) NOT NULL COMMENT '用户编号',
  `RoleId` int(11) NOT NULL COMMENT '角色编号',
  `IsEnable` tinyint(4) NOT NULL DEFAULT '1' COMMENT '是否有效',
  PRIMARY KEY (`Id`),
  KEY `UserRole` (`UserId`,`RoleId`),
  KEY `UserId` (`UserId`),
  KEY `RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户角色表';

--
-- Dumping data for table `UserRole`
--

/*!40000 ALTER TABLE `UserRole` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserRole` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
