﻿<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true"
	ValidateRequest="false" CodeFile="AU206004.aspx.cs" Inherits="Page_AU206004"
	 %>

<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>
<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
	<label class="projectLink transparent border-box">Dashboards</label>
	<pxa:AUDataSource ID="ds" runat="server" Width="100%" TypeName="PX.SM.ProjectDashboardsMaintenance" PrimaryView="Items" Visible="true">
		<CallbackCommands>
			<px:PXDSCallbackCommand CommitChanges="True" Name="Save" />
		</CallbackCommands>
	</pxa:AUDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" runat="Server">
    <px:PXGrid ID="grid"
               runat="server"
               Width="100%"
		       SkinID="Primary"
               AutoAdjustColumns="True"
               SyncPosition="True"
               FilesIndicator="False"
               NoteIndicator="False">
		<AutoSize Enabled="true" Container="Window" />
		<Mode AllowAddNew="False" />
		<ActionBar Position="Top" ActionsVisible="false">
			<Actions>
				<NoteShow MenuVisible="False" ToolBarVisible="False" />
				<AddNew MenuVisible="False" ToolBarVisible="False" />
				<ExportExcel MenuVisible="False" ToolBarVisible="False" />
				<AdjustColumns ToolBarVisible="False"/>
			</Actions>
		</ActionBar>
		<Levels>
			<px:PXGridLevel DataMember="Items">
				<RowTemplate>
					<px:PXLayoutRule runat="server" StartColumn="True" LabelsWidth="M" ControlSize="XM" />
					<px:PXTextEdit SuppressLabel="True" Height="100%" runat="server" ID="edSource" TextMode="MultiLine"
						DataField="Content" Font-Size="10pt" Font-Names="Courier New" Wrap="False" SelectOnFocus="False">
						<AutoSize Enabled="True" />
					</px:PXTextEdit>
				</RowTemplate>
				<Columns>
					<px:PXGridColumn DataField="Name" Width="250px"/>
					<px:PXGridColumn DataField="Description" Width="108px" />
					<px:PXGridColumn AllowUpdate="False" DataField="LastModifiedByID_Modifier_Username" Width="108px" />
					<px:PXGridColumn AllowUpdate="False" DataField="LastModifiedDateTime" Width="90px" />
				</Columns>
			</px:PXGridLevel>
		</Levels>
	</px:PXGrid>
    
    <px:PXSmartPanel runat="server"
                     ID="FilterSelectDasboards"
                     Width="700px"
                     Height="400px"
                     CaptionVisible="True"
		             Caption="Add Dashboards"
                     ShowMaximizeButton="True"
                     Key="ViewSelectDasboards"
                     ShowAfterLoad="True"
                     AutoRepaint="True">
        <px:PXGrid runat="server" 
		           ID="gridAdddasboard"
                   DataSourceID="ds" 
			       Width="100%"
                   BatchUpdate="True" 
			       CaptionVisible="False" 
			       Caption="Dashboards"
			       AutoAdjustColumns="True"
                   AllowPaging="False"
			       SkinID="Details"
                   FilesIndicator="False"
                   NoteIndicator="False">
		    <Levels>
				<px:PXGridLevel DataMember="ViewSelectDasboards">
					<Columns>
					    <px:PXGridColumn DataField="Selected" Type="CheckBox" AllowCheckAll="True" Width="100px"/>						
					    <px:PXGridColumn DataField="Name" Width="300px"/>				
                        <px:PXGridColumn DataField="ScreenID" Width="300px"/>				
					</Columns>
				</px:PXGridLevel>
			</Levels>
		    <AutoSize Enabled="True"/>
			<ActionBar Position="Top">
				<Actions>
					<AddNew MenuVisible="False" ToolBarVisible="False"/>
					<Delete MenuVisible="False" ToolBarVisible="False"/>
					<AdjustColumns  ToolBarVisible="False"/>
					<ExportExcel  ToolBarVisible="False"/>
				</Actions>
			</ActionBar>
		</px:PXGrid>			
        <px:PXPanel ID="PXPanel1" runat="server" SkinID="Buttons">
            <px:PXButton ID="PXButton1" runat="server" DialogResult="OK" Text="Save" />
            <px:PXButton ID="PXButton2" runat="server" DialogResult="No" Text="Cancel" CausesValidation="False" />
        </px:PXPanel>
	</px:PXSmartPanel>
</asp:Content>
