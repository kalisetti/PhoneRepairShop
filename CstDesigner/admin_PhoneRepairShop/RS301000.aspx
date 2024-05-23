<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="RS301000.aspx.cs" Inherits="Page_RS301000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="PhoneRepairShop.RSSVWorkOrderEntry"
        PrimaryView="WorkOrders"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="WorkOrders" Width="100%" Height="100px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit9" DataField="OrderNbr" ></px:PXTextEdit>
			<px:PXDropDown runat="server" ID="CstPXDropDown13" DataField="Status" ></px:PXDropDown>
			<px:PXCheckBox runat="server" ID="CstPXCheckBox7" DataField="Hold" ></px:PXCheckBox>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit4" DataField="DateCreated" ></px:PXDateTimeEdit>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit3" DataField="DateCompleted" ></px:PXDateTimeEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit5" DataField="Description" ></px:PXTextEdit>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule14" StartColumn="True" />
			<px:PXNumberEdit runat="server" ID="CstPXNumberEdit2" DataField="CustomerID" ></px:PXNumberEdit>
			<px:PXSelector runat="server" ID="CstPXSelector12" DataField="ServiceID" ></px:PXSelector>
			<px:PXSelector runat="server" ID="CstPXSelector6" DataField="DeviceID" ></px:PXSelector>
			<px:PXNumberEdit runat="server" ID="CstPXNumberEdit1" DataField="Assignee" ></px:PXNumberEdit>
			<px:PXDropDown runat="server" ID="CstPXDropDown11" DataField="Priority" ></px:PXDropDown>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule15" StartColumn="True" />
			<px:PXNumberEdit runat="server" ID="CstPXNumberEdit10" DataField="OrderTotal" ></px:PXNumberEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit8" DataField="InvoiceNbr" ></px:PXTextEdit></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="Tab item 1">
				<Template>
					
				</Template>
			</px:PXTabItem>
			<px:PXTabItem Text="Tab item 2">
				<Template>
					
				</Template>
			</px:PXTabItem>
		</Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
	</px:PXTab>
</asp:Content>
