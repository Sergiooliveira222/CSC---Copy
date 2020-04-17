<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Refund_API.aspx.cs" Inherits="WebApplication1.DigitalSevaPaymentGateway.Refund" %>

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
		<div class="col-md-2-5">
			
		</div>
        <div class="col-md-7">
        <div class="row content-column shadow" style="background-color: white;">
	        <div class="col-md-4">
            <img name="Logo" src="Header/logo.jpg" alt="logo">
            </div>
            <div class="col-md-4" style="float:right;">
            <img name="Logo" src="Header/digital-india.jpg" alt="logo">
            </div>
    </div>
        </div>
        </div>
        
    	<div class="row" >
		<div class="col-md-2-5">
			
		</div>
		<div class="col-md-7">
			<div class="row content-column shadow" >
	<div class="col-md-12">
    <div class="row">
			
	<div class="col-lg-4">
				<div class="pricing-box-alt">
							
                        
					<div class="pricing-action">
						
                      <table width="100%" height="200px">
                            <tr>
                            
                             <td>
                              Merchant Txn <span style="color:Red">*</span>
                             </td>
                             <td>
                              <asp:TextBox ID="txtMerchantTxn" runat="server" Height="31px" Width="231px"  ></asp:TextBox>
                        
                                      
                             </td>
                               <td>
                                CSC Txn <span style="color:Red">*</span>
                             </td>
                             <td>
                              <asp:TextBox ID="txtCSCTxn" runat="server" Height="39px" Width="232px"  ></asp:TextBox>
                        
                                      
                             </td>
                        
                           <td>
                                &nbsp;</td>
                             <td>
                                 &nbsp;</td>
                     
                            </tr>

                            <tr>
                             
                             
                               <td colspan="3" align="right">
                                 <asp:Button ID="Button1" runat="server"  
                                       Text="Refund" onclick="btnSearch_Click"  />
                             </td>
                               <td colspan="3" align="left"> &nbsp &nbsp &nbsp
                                   </td>
                            </tr>
                               
                           
                            </table>
					</div>
                             
				</div>
			</div>
			
			
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
