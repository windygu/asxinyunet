<%@ Page Title="新闻信息表管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true"  validateRequest="false"  CodeFile="NewsForm.aspx.cs" Inherits="Common_NewsForm"%>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <script type="text/javascript" src="../../editor/ckeditor.js"></script>

    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr> <th colspan="6" class="style1">新闻信息表</th> </tr>

        <tr>
           <td align ="right"  class="style7">新闻标题：</td>
           <td><asp:TextBox ID="frmTitle" runat="server" Width="288px"></asp:TextBox></td>
            <td align="right"  class="style6">作者：</td>
            <td>                       
            <XCL:DropDownList ID="frmAuthor" runat="server" DataTextField="Name" DataValueField="ID"
                    AppendDataBoundItems="True" Width="150px" >
                </XCL:DropDownList>
            </td>
           <td align="right" class="style3">类别编号：</td>         
           <td class="style2">
                <XCL:DropDownList ID="frmCategoryId" runat="server" DataTextField="Name" DataValueField="Id"
                    AppendDataBoundItems="True" Width="150px" >
                </XCL:DropDownList>              
           </td>  
           </tr>        

        <tr>           
            <td align="right" class="style8">来源：</td>
            <td class="style6"><asp:TextBox ID="frmOrigin" runat="server" Width="287px"></asp:TextBox></td>
            <td align="right" class="style6">关键字：</td>
            <td colspan="3" class="style6">
                <asp:TextBox ID="frmKeyWords" runat="server" 
                    Width="410px"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td align="right" class="style9">内容</td>
            <td  colspan="5" class="style5">
            <p><a href="upfilebyeditor.aspx?keepThis=true&getfile=1&TB_iframe=true&height=480&width=580" title="插入图片/文件" class="thickbox" target="_blank">插入图片/文件</a><a>   提示：Enter产生(换段), Shift+Enter产生(换行)</a></p>
            <asp:TextBox ID="frmContent" runat="server"  Width="930px" TextMode="MultiLine"  ></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <td align="right" class="style7">导读：</td>
            <td  colspan="5">
            <asp:TextBox ID="frmReview" runat="server" TextMode="MultiLine" Width="930px" ></asp:TextBox></td>
        </tr>

        <tr>
            <td align="right" class="style10">点击数：</td>
            <td class="style3"><XCL:NumberBox ID="frmHits" runat="server" Width="148px"></XCL:NumberBox></td>

            <td align="right" class="style6">编码类别：</td>
            <td class="style3">
                  <XCL:DropDownList ID="frmCodeType" runat="server">           
                    <asp:ListItem Value="0">所有语言</asp:ListItem>
                    <asp:ListItem Value="1">中文</asp:ListItem>
                    <asp:ListItem Value="2">英文</asp:ListItem>                    
        </XCL:DropDownList>
            </td>

             <td align="right" class="style3">文章状态：</td>
             <td class="style4">

                 <XCL:DropDownList ID="frmStatus" runat="server" Width="150">                          
                    <asp:ListItem Value="草稿">草稿</asp:ListItem>
                    <asp:ListItem Value="已发表">已发表</asp:ListItem>                    
        </XCL:DropDownList>
                   
             </td>
        </tr>
        
        <tr>           
            <td align="right" class="style7">添加时间：</td>
            <td><XCL:DateTimePicker ID="frmAddDateTime" runat="server"></XCL:DateTimePicker></td>
            <td align="right" class="style6">备注：</td>
            <td  colspan="3"><asp:TextBox ID="frmRemark" runat="server" Width="410px"></asp:TextBox></td>
        </tr>           
    </table>

    <table border="0" align="Center" width="80%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" CausesValidation="True" Text='保存' />
                &nbsp;<asp:Button ID="btnCopy" runat="server" CausesValidation="True" Text='另存为新新闻信息表' />
                &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;" Text="返回" />
            </td>
        </tr>
    </table>

<script type="text/javascript">
function addFileToEditor(fileUrl,fileExtension)
{
    if(fileExtension=='.gif' || fileExtension=='.jpg' || fileExtension=='.jpeg' || fileExtension=='.bmp' || fileExtension=='.png'){
        var imageTag="<img src=\""+fileUrl+"\"/>";
        CKEDITOR.instances.<%=frmContent.ClientID %>.insertHtml(imageTag); 
    }else{
        var imageTag="<a href=\""+fileUrl+"\">"+fileUrl+"</a>";
        CKEDITOR.instances.<%=frmContent.ClientID %>.insertHtml(imageTag);
    }    
}

function createSummary(type) {
    var ckContent =CKEDITOR.instances.<%=frmContent.ClientID %>;
    var ckSummary =CKEDITOR.instances.<%=frmReview.ClientID %>;

    var iLength  = ckSummary.getData().length;

    var r=true;
    if(iLength>0){
        if(!confirm('提取将会覆盖已有摘要,要继续吗?')){
		    r=false;
        }
    }
    if(r){
        if(type =='full'){
            ckSummary.setData(ckContent.getData());  
        }
        else{
		    ckSummary.setData(ckContent.getData().replace(/<[^>]+>/g, "").substring(0,500));     //CK会自动处理未闭合的标签，我们不用多管它。要是标签被切了一半显示出来了自己编辑下就好。
		}
    }
    return false;
}
</script>

<script type="text/javascript">
    CKEDITOR.replace('<%=frmContent.ClientID %>',
                     { height: 300, width: '98%'});
                     CKEDITOR.replace('<%=frmReview.ClientID %>',
				{
				    height: 100, width: '98%',
				    // Defines a simpler toolbar to be used in this sample.
				    // Note that we have added out "MyButton" button here.
				    toolbar: [['Source', '-', 'Bold', 'Italic', 'Underline', 'Strike', '-', 'Link', '-']]
				});
                </script>

<script type="text/javascript">
    function showTag() {
        if (document.getElementById('taglist').style.display == '') {
            document.getElementById('taglist').style.display = 'none';
        } else {
            document.getElementById('taglist').style.display = '';
        }
    }
</script>  

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="H">
    <style type="text/css">
        .style1 {
            height: 17px;
            width:100px;
        }
        .style2
        {          
            width:198px;
        }
        .style3
        {
            height: 20px;
            width:100px;
        }
        .style4
        {
            width: 198px;
            height: 20px;
        }
        .style5
        {
            height: 131px;
            
        }
        .style6
        {
            height: 21px;
            width:100px ;
        }
        .style7
        {
            width: 100px;
        }
        .style8
        {
            height: 21px;
            width: 100px;
        }
        .style9
        {
            height: 131px;
            width: 100px;
        }
        .style10
        {
            height: 20px;
            width: 100px;
        }
    </style>
</asp:Content>
