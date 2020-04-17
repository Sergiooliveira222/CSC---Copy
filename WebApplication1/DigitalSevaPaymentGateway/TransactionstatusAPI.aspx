<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionstatusAPI.aspx.cs" Inherits="WebApplication1.DigitalSevaPaymentGateway.TransactionstatusAPI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
     <div style="margin-top: 10px;">
    <div class="grid"> 
    
    <div class="row" >
		
        <div class="col-md-12">
        <div class="row content-column shadow" style="background-color: white;">
	        <div class="col-md-6">
            <img name="Logo" src="Header/logo.jpg" alt="logo">
            </div>
            <div class="col-md-6">
            <img name="Logo" src="Header/digital-india.jpg" alt="logo" style="float:right;">
            </div>
    </div>
        </div>
        </div>
        
    	<div class="row" >
	
		<div class="col-md-12">
			<div class="row content-column shadow" >
	<div class="col-md-12">
    <div class="row">
			
	<table width="100%" >
                          <tr>
                            
                             <td> 
                              Public Key <span style="color:Red">*</span>
                             </td>
                             <td>
                              <asp:TextBox ID="txtpublickey" runat="server" class="form-control" Height="144px" Width="265px" TextMode="MultiLine" ></asp:TextBox>
                        
                                      
                             </td>
                             <td>
                                privatekey <span style="color:Red">*</span>
                             </td>
                             <td>
                              <asp:TextBox ID="txtprivatekey" runat="server" Height="144px" Width="265px" TextMode="MultiLine"  class="form-control"  ></asp:TextBox>
                        
                                      
                             </td>
               </tr>
                          <tr>
                            
                             <td> 
                              Merchant Id <span style="color:Red">*</span>
                             </td>
                             <td>
                              <asp:TextBox ID="txtmerchantid" runat="server" class="form-control" Height="27px" Width="146px" ></asp:TextBox>
                        
                                      
                             </td>
                             <td>
                                 <span style="color:Red">*</span>
                             </td>
                             <td>
                            
                        
                                      
                             </td>
               </tr>
                            <tr>
                            
                             <td> 
                              Merchant Txn <span style="color:Red">*</span>
                             </td>
                             <td>
                              <asp:TextBox ID="txtMerchantTxn" runat="server" class="form-control" Height="27px" Width="464px" ></asp:TextBox>
                        
                                      
                             </td>
                             <td>
                                CSC Txn <span style="color:Red">*</span>
                             </td>
                             <td>
                              <asp:TextBox ID="txtCSCTxn" runat="server"  class="form-control" Width="332px"  ></asp:TextBox>
                        
                                      
                             </td>
               </tr>
                           
                         
                           
                           <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnRecon" runat="server" Text="REcon" OnClick="btnRecon_Click" />
                             </td>
                               <td colspan="4" align="left" >&nbsp;&nbsp;&nbsp;
                                   </td>
                           </tr>
                     </table>
			
			
		</div>
    </div>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    </div>
    </div>
    
    </div>
    </div>
    
    </form>
</body>
</html>
