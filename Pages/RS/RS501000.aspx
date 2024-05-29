<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="RS501000.aspx.cs" Inherits="Page_RS501000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="PhoneRepairShop.RSSVAssignProcess"
        PrimaryView="WorkOrders"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Inquire" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="WorkOrders">
			    <Columns>
				<px:PXGridColumn Type="CheckBox" AllowCheckAll="True" DataField="Selected" Width="60" ></px:PXGridColumn>
				<px:PXGridColumn DataField="OrderNbr" Width="140" />
				<px:PXGridColumn DataField="Description" Width="220" ></px:PXGridColumn>
				<px:PXGridColumn DataField="ServiceID" Width="140" ></px:PXGridColumn>
				<px:PXGridColumn DataField="DeviceID" Width="140" ></px:PXGridColumn>
				<px:PXGridColumn DataField="Priority" Width="70" ></px:PXGridColumn>
				<px:PXGridColumn DataField="Assignee" Width="140" ></px:PXGridColumn></Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
		<ActionBar >
		</ActionBar>
	</px:PXGrid>
</asp:Content>
