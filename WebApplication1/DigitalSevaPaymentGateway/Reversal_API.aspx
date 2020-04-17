<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reversal_API.aspx.cs" Inherits="WebApplication1.DigitalSevaPaymentGateway.Reversal_API" %>

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
						
                      <table width="100%" style="height: 188px">
                            <tr>
                            
                             <td> 
                              Merchant Txn <span style="color:Red">*</span>
                             </td>
                             <td>
                              <asp:TextBox ID="txtMerchantTxn" runat="server" class="form-control" Height="27px" Width="146px" ></asp:TextBox>
                        
                                      
                             </td>
                            <td>Merchant Date <span style="color:Red">*</span></td>
                             <td>
                                 <asp:TextBox ID="txtMerchantDate" runat="server" class="form-control"  ></asp:TextBox>
                        
                                      
                             </td>
               </tr>
                         
                           <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnRecon" runat="server" Text="Reversal" OnClick="btnRecon_Click" />
                             </td>
                               <td colspan="4" align="left" >&nbsp;&nbsp;&nbsp;
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
