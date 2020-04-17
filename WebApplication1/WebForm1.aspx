<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />

</head>
<body style="background:#F7F7F7;">
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
           
			<div class="col-md-12">
				<h2 style="font-size: 20px;"> </h2>
				
			</div>
		</div>
		
		
       
				
				<div class="row">
                <fieldset>
				<legend style="font-size:16px;"></legend>
						</fieldset>
                
    <div class="col-md-6">
        <asp:Button ID="btnLogin" runat="server" class="btn btn-info" Visible=false 
            Text="Login with Digital Seva Connect" onclick="btnLogin_Click" />

             <asp:Button ID="btnShop" runat="server" class="btn btn-info"  
            Text="Shop" onclick="btnShop_Click"  />
				
            <asp:Button ID="btnLogOut" runat="server" style="float:right;" class="btn btn-info" Visible="false"  
            Text="Logout" onclick="btnLogOut_Click"  />
						
				</div>
                </div>
		
            <div class="row">
            <div class="col-md-12">
	<!-- call response -->
	
	<h4>Digital Seva Connect Response</h4>
				<pre class="prettyprint linenums">					
					Decrypted Values: 
                    <asp:Label ID="lblsessiondata" runat="server" Text="Label"></asp:Label>  

					<br>
					
					
				</pre>
				
				
	
	
	
	</div>
            </div>
	
				<div class="row">
					
					<div class="col-md-12">
					
							<label>
								For any Queries in registration, please contact us at our helpline numbers:  1800 3000 3468
							</label>
						
					</div>
				</div>
                <legend style="font-size:16px;"></legend>
		
	
	</div>
</div>



		</div>
		
	</div>
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
    </form>
</body>
</html>

