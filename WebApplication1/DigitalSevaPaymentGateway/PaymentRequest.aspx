<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentRequest.aspx.cs" Inherits="WebApplication1.DigitalSevaPaymentGateway.PaymentRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
						
                      <asp:Button ID="btnFirstProduct" runat="server" Text="Make Payment"  class="btn btn-info" 
                            onclick="btnFirstProduct_Click"/>
					</div>
                             
				</div>
			</div>
			
			
		</div>
    </div>
    </div>
    </div>
    </div>
    
    </div>
    </div>
    
    </form>
</body>
</html>
