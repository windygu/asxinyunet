<%@ Page Title="系统设置表管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true" CodeFile="WebSettingForm.aspx.cs" Inherits="Common_WebSettingForm"%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
   <script type="text/javascript" src="../../editor/ckeditor.js"></script>
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="4">系统设置表</th>
        </tr>
        <tr>
            <td align="right">名称：</td>
            <td><asp:TextBox ID="frmName" runat="server" Width="400px"></asp:TextBox></td>

             <td align="right">编码类型：</td>
            <td>
                  <XCL:DropDownList ID="frmCodeType" runat="server" Width="150px">           
                    <asp:ListItem Value="0">所有语言</asp:ListItem>
                    <asp:ListItem Value="1">中文</asp:ListItem>
                    <asp:ListItem Value="2">英文</asp:ListItem>                    
               </XCL:DropDownList>
         </td>
        </tr>
        
        <tr>
            <td align="right">值：</td>
            <td colspan="3"><asp:TextBox ID="frmValue" runat="server" TextMode="MultiLine" Width="700px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">类别：</td>
            <td>            
             <XCL:DropDownList ID="frmCategoryId" runat="server" DataTextField="Name" DataValueField="Id"
                    AppendDataBoundItems="True" Width="150px" >
                </XCL:DropDownList>        
            </td>
             <td align="right">排序码：</td>
            <td><XCL:NumberBox ID="frmSort" runat="server" Width="150px"></XCL:NumberBox></td>
        </tr>

        <tr>
            <td align="right">备注：</td>
            <td colspan="3"><asp:TextBox ID="frmRemark" runat="server" Width="710px"></asp:TextBox></td>
        </tr>
    </table>
    <table border="0" align="Center" width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" CausesValidation="True" Text='保存' />
                &nbsp;<asp:Button ID="btnCopy" runat="server" CausesValidation="True" Text='另存为新系统设置表' />
                &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;" Text="返回" />
            </td>
        </tr>
    </table>

<script type="text/javascript">
function addFileToEditor(fileUrl,fileExtension)
{
    if(fileExtension=='.gif' || fileExtension=='.jpg' || fileExtension=='.jpeg' || fileExtension=='.bmp' || fileExtension=='.png'){
        var imageTag="<img src=\""+fileUrl+"\"/>";
        
    }else{
        var imageTag="<a href=\""+fileUrl+"\">"+fileUrl+"</a>";
     
    }    
}

function createSummary(type) {

    var ckSummary =CKEDITOR.instances.<%=frmValue.ClientID %>;

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
   
    CKEDITOR.replace('<%=frmValue.ClientID %>',
				{
				    height: 150, width: '100%'
				    // Defines a simpler toolbar to be used in this sample.
				    // Note that we have added out "MyButton" button here.
				   // toolbar: [['Source', '-', 'Bold', 'Italic', 'Underline', 'Strike', '-', 'Link', '-']]
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