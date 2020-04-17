<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentResponse.aspx.cs" Inherits="WebApplication1.DigitalSevaPaymentGateway.PaymentResponse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
        <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
            <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        </div>
        </div>
        <div class="row" >
		<div class="col-md-2-5">
			
		</div>
		<div class="col-md-7">
			<div class="row content-column shadow" >
	<div class="col-md-12">
		<div class="row">
           
			<div class="col-md-12" style="">
				<h2 style="font-size: 20px;"> 
                    
                <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" Height="157px" Width="946px"></asp:TextBox>
                </h2>
				
			</div>
		</div>
		
		
       
				
				<div class="row">
                <fieldset>
				<legend style="font-size:16px;"></legend>
						</fieldset>
                <P>Transaction ID (CSC PG): <b><%=csc_txn %></b> </P>
                <P>merchant id : <b> <%=merchant_id%> </b></P>
                <P>csc_id : <b> <%=csc_id%></b></P>
				<P>txn ID:  <b><%=merchant_txn %></b></P>
				<P>Date: <b><%=merchant_txn_date_time %></b></P>
	            <P>txn_status: <b><%=txn_status %></b></P>
                     <P>txn_status_message: <b><%=txn_status_message %></b></P>
				<P>Product Id : <b><%=product_id%></b></P>                         
                <P>txn amount : <b> <%=txn_amount%></b></P>
                <P>pay_to_email : <b> <%=pay_to_email%></b></P>
                <P>amount_parameter : <b> <%=amount_parameter%></b></P>
                <P>txn_mode : <b> <%=txn_mode%></b></P>
                <P>txn_type : <b> <%=txn_type%></b></P>
                 <P>merchant_receipt_no : <b> <%=merchant_receipt_no%></b></P>                
                <P>csc_share_amount : <b> <%=csc_share_amount%></b></P>
                 <P>Currency : <b> <%=Currency%></b></P>
                <P>Discount : <b> <%=Discount%></b></P>
                 <P>param_1 : <b> <%=param_1%></b></P>
                 <P>param_2 : <b> <%=param_2%></b></P>
                 <P>param_3 : <b> <%=param_3%></b></P>
                 <P>param_4 : <b> <%=param_4%></b></P>
                   
            
        

                 
                 </div>
                 </div></div></div></div>

                 <div class="row" >
		<div class="col-md-2-5">
			
		</div>
        <div class="col-md-7" >
        <div class="row content-column shadow" style="background-color: white; text-align:center;color: black; font-weight: bold;">
	       Copyright ©2016. CSC e-Governance Services India Limited. All rights reserved.
    </div>
        </div>
        </div>
                 </div>
                 </div>
                 
                 
                 
    </div>
    </form>
</body>
</html>
