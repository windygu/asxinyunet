using System;
using System.ComponentModel;
using NewLife.CommonEntity;
using XCode;

namespace DotNet.Tools.Authority.Entity
{
    /// <summary>
    /// 管理员
    /// </summary>
    [BindTable("Admin", Description = "管理员", ConnName = "YWS")]
    public class Admin : Administrator<Admin, Role, Menu, RoleMenu, NewLife.CommonEntity.Log>
    {
        private String _QQ;
        /// <summary>
        /// QQ
        /// </summary>
        [Description("QQ")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("QQ", Description = "名称", DefaultValue = "", Order = 3)]
        public String QQ
        {
            get { return _QQ; }
            set { if (OnPropertyChange("QQ", value)) _QQ = value; }
        }

        private String _MSN;
        /// <summary>
        /// MSN
        /// </summary>
        [Description("MSN")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("MSN", Description = "MSN", DefaultValue = "", Order = 3)]
        public String MSN
        {
            get { return _MSN; }
            set { if (OnPropertyChange("MSN", value)) _MSN = value; }
        }

        private String _Email;
        /// <summary>
        /// 邮件
        /// </summary>
        [Description("邮件")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Email", Description = "邮件", DefaultValue = "", Order = 3)]
        public String Email
        {
            get { return _Email; }
            set { if (OnPropertyChange("Email", value)) _Email = value; }
        }

        private String _Phone;
        /// <summary>
        /// 电话
        /// </summary>
        [Description("电话")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Phone", Description = "电话", DefaultValue = "", Order = 3)]
        public String Phone
        {
            get { return _Phone; }
            set { if (OnPropertyChange("Name", value)) _Phone = value; }
        }
    }
}