<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="RS501000.aspx.cs" Inherits="Page_RS501000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="PhoneRepairShop.RSSVAssignProcess"
        PrimaryView="Filter">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" runat="Server">
    <px:PXFormView Width="100%" runat="server" ID="CstFormView1" DataMember="Filter">
        <Template>
            <px:PXLayoutRule LabelsWidth="XM" ControlSize="SM" runat="server" ID="CstPXLayoutRule5" StartRow="True" ColumnWidth=""></px:PXLayoutRule>
            <px:PXDropDown AllowEdit="True" runat="server" ID="CstPXDropDown2" DataField="Priority" CommitChanges="True"></px:PXDropDown>
            <px:PXNumberEdit CommitChanges="True" runat="server" ID="CstPXNumberEdit4" Size="SM" DataField="TimeWithoutAction"></px:PXNumberEdit>
            <px:PXLayoutRule LabelsWidth="M" ControlSize="SM" runat="server" ID="CstPXLayoutRule6" StartColumn="True" ColumnWidth=""></px:PXLayoutRule>
            <px:PXSelector CommitChanges="True" runat="server" ID="CstPXSelector3" DataField="ServiceID"></px:PXSelector>
        </Template>
    </px:PXFormView>
    <px:PXGrid SyncPosition="True" ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Inquire" AllowAutoHide="false">
        <Levels>
            <px:PXGridLevel DataMember="WorkOrders">
                <RowTemplate>
                    <px:PXSegmentMask runat="server" ID="CstPXSegmentMask8" DataField="Assignee" AutoRefresh="True"></px:PXSegmentMask>
                    <px:PXSegmentMask runat="server" ID="CstPXSegmentMask18" DataField="AssignTo" AutoRefresh="True"></px:PXSegmentMask>
                </RowTemplate>

                <Columns>
                    <px:PXGridColumn Type="CheckBox" AllowCheckAll="True" DataField="Selected" Width="60"></px:PXGridColumn>
                    <px:PXGridColumn DataField="OrderNbr" Width="140"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Description" Width="220"></px:PXGridColumn>
                    <px:PXGridColumn DataField="ServiceID" Width="140"></px:PXGridColumn>
                    <px:PXGridColumn DataField="DeviceID" Width="140"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Priority" Width="70"></px:PXGridColumn>
                    <px:PXGridColumn CommitChanges="False" DataField="Assignee" Width="140"></px:PXGridColumn>
                    <px:PXGridColumn DataField="TimeWithoutAction" Width="70"></px:PXGridColumn>
                    <px:PXGridColumn DataField="DefaultAssignee" Width="140" />
                    <px:PXGridColumn CommitChanges="True" DataField="AssignTo" Width="140"></px:PXGridColumn>
                    <px:PXGridColumn DataField="NbrOfAssignedOrders" Width="70" />
                </Columns>
            </px:PXGridLevel>
        </Levels>
        <AutoSize Container="Window" Enabled="True" MinHeight="150"></AutoSize>
        <ActionBar>
        </ActionBar>
    </px:PXGrid>
</asp:Content>
