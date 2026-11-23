<%@ Page Language="C#" AutoEventWireup="true" 
CodeBehind="AcademicLeave.aspx.cs" 
Inherits="AcademicLeaveManagement.AcademicLeave" %> 
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml"> 
<head runat="server"> 
<title>Academic Calendar & Leave Management</title> 
<style> 
body { 
margin: 0; 
font
family: Arial, Helvetica, sans
background
} 
/* Header */ 
.header { 
background
color: #f5f7fa; 
color: #174a7c; 
color: white; 
padding: 18px 10%; 
font
size: 25px; 
font
weight: bold; 
} 
/* Main container */ 
.container { 
width: 700px; 
margin: 30px auto; 
background
color: white; 
padding: 25px 30px; 
border: 1px solid #c8d8e8; 
border
radius: 5px; 
box--
serif; 
shadow: 0 2px 8px rgba(0,0,0,0.08); 
} 
/* Welcome */ 
.welcome { 
background
color: #e8f2fc; 
padding: 12px; 
color: #174a7c; 
font
size: 18px; 
font
weight: bold; 
margin
} 
bottom: 20px; 
/* Form rows */ 
        .row { 
            margin-bottom: 15px; 
        } 
        .label { 
            display: inline-block; 
            width: 130px; 
            font-weight: bold; 
            color: #333; 
        } 
        .textbox { 
            width: 250px; 
            padding: 8px; 
            border: 1px solid #aaa; 
            border-radius: 3px; 
        } 
        .dropdown { 
            width: 268px; 
            padding: 8px; 
            border: 1px solid #aaa; 
            border-radius: 3px; 
        } 
        /* Calendar */ 
        .calendar { 
            margin-left: 130px; 
            margin-top: 5px; 
        } 
        /* Buttons */ 
        .btn { 
            padding: 10px 22px; 
            border: none; 
            border-radius: 4px; 
            cursor: pointer; 
            font-weight: bold; 
            margin-right: 8px; 
        } 
        .apply { 
            background-color: #087ff5; 
            color: white; 
        } 
        .clear { 
            background-color: #777; 
            color: white; 
        } 
        .apply:hover { 
            background-color: #066dcc; 
        } 
        .clear:hover { 
            background-color: #555; 
        } 
        /* Success message */ 
        .success { 
            margin-top: 15px; 
            padding: 15px; 
            background-color: #e8f8ec; 
            border: 1px solid #55ad6c; 
            color: #176b2d; 
            border-radius: 4px; 
            line-height: 1.7; 
        } 
        /* Error */ 
        .error { 
            margin-top: 15px; 
            padding: 10px; 
            background-color: #ffecec; 
            border: 1px solid #dd5555; 
            color: #b00000; 
            border-radius: 4px; 
        } 
        /* Horizontal line */ 
        .line { 
            border-top: 1px solid #ddd; 
            margin: 30px 0 20px 0; 
        } 
        /* Academic Calendar */ 
        .academic-title { 
            color: #174a7c; 
            font-size: 20px; 
            font-weight: bold; 
            margin-bottom: 15px; 
        } 
        .academic-calendar { 
            margin-left: 130px; 
        } 
        /* Session */ 
        .session { 
            margin-top: 20px; 
            padding: 12px; 
            background-color: #e8f2fc; 
            border: 1px solid #9bc4ed; 
            color: #174a7c; 
            text-align: center; 
            border-radius: 4px; 
            font-weight: bold; 
        } 
 
    </style> 
</head> 
<body> 
<form id="form1" runat="server"> 
    <!-- Header --> 
    <div class="header"> 
            Academic Calendar & Leave Management 
    </div> 
    <!-- Main Container --> 
    <div class="container"> 
        <!-- Welcome --> 
        <div class="welcome"> 
 
            <asp:Label ID="lblUser" runat="server" 
                Text="Welcome, Student"> 
            </asp:Label> 
        </div > 
        <!-- Student Name --> 
        <div class="row"> 
            <span class="label"> 
                Student Name: 
            </span> 
            <asp:TextBox 
                ID="txtName" 
                runat="server" 
                CssClass="textbox"> 
            </asp:TextBox> 
 
        </div > 
        <!-- Leave Type --> 
        <div class="row"> 
            <span class="label"> 
                Leave Type: 
            </span> 
            <asp:DropDownList 
                ID="ddlLeave" 
                runat="server" 
                CssClass="dropdown"> 
                <asp:ListItem>Medical Leave</asp:ListItem> 
                <asp:ListItem>Casual Leave</asp:ListItem> 
                <asp:ListItem>Emergency Leave</asp:ListItem> 
                <asp:ListItem>Other</asp:ListItem> 
            </asp:DropDownList> 
        </div> 
        <!-- Leave Date --> 
        <div class="row"> 
            <span class="label"> 
                Leave Date: 
            </span> 
            <asp:Calendar 
                ID="calLeave" 
                runat="server" 
                CssClass="calendar" 
                BackColor="White" 
                BorderColor="#9bc4ed" 
                BorderWidth="1px" 
                DayNameFormat="Short" 
                Font-Names="Arial" 
                Font-Size="10pt" 
                ForeColor="#333333" 
                ShowGridLines="True" 
                Width="260px"> 
                <SelectedDayStyle 
                    BackColor="#087ff5" 
                    ForeColor="White" 
                    Font-Bold="True" /> 
                <TitleStyle 
                    BackColor="#dbeeff"
ForeColor="#174a7c" 
Font
Bold="True" 
Height="30px" /> 
<TodayDayStyle 
BackColor="#e8f2fc" 
ForeColor="#174a7c" /> 
<DayHeaderStyle 
BackColor="#f2f2f2" 
Font
Bold="True" /> 
</asp:Calendar> 
</div> 
<br /
> 
<!-- 
Buttons -
> 
<asp:Button 
ID="btnApply" 
runat="server" 
Text="Apply Leave" 
CssClass="btn apply" 
OnClick="btnApply_Click" /> 
<asp:Button 
ID="btnClear" 
runat="server" 
Text="Clear" 
CssClass="btn clear" 
OnClick="btnClear_Click" /> 
<!-- 
Message -
> 
<asp:Label 
ID="lblMessage" 
runat="server"> 
</asp:Label> 
<!-- 
Line -- -
> 
<div class="line"></div> 
<!
Academic Calendar 
<div class="academic
Academic Calendar 
</div> 
<asp:Calendar 
ID="calAcademic" 
runat="server" 
CssClass="academic-
> 
title"> 
calendar" 
BackColor="White" 
BorderColor="#9bc4ed" 
BorderWidth="1px" 
DayNameFormat="Short" 
Font
Names="Arial" 
Font
Size="10pt" 
ForeColor="#333333" 
ShowGridLines="True" 
Width="260px"> 
<SelectedDayStyle 
BackColor="#087ff5" 
ForeColor="White" 
Font
Bold="True" /> 
<TitleStyle BackColor="#dbeeff" 
                ForeColor="#174a7c" 
                Font-Bold="True" 
                Height="30px" /> 
            <TodayDayStyle 
                BackColor="#e8f2fc" 
                ForeColor="#174a7c" /> 
            <DayHeaderStyle 
                BackColor="#f2f2f2" 
                Font-Bold="True" /> 
        </asp:Calendar > 
        <!-- Session --> 
        <div class="session"> 
            <asp:Label 
                ID="lblSession" 
                runat="server" 
                Text="             Session: 2025 - 2026 (Active)"> 
            </asp:Label> 
        </div> 
    </div> 
</form> 
</body> 
</html> 
